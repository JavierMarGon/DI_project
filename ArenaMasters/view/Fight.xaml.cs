using ArenaMasters.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ArenaMasters
{
    /// <summary>
    /// Lógica de interacción para Fight.xaml
    /// </summary>
    public partial class Fight : Window
    {
        public List<Units> Units { get; set; } = new List<Units>();
        List<Units> cpu = new List<Units>();
        ArenaMastersManager manager = new ArenaMastersManager();
        Units unitSelect;
        Skills skillSelect;
        Game _game;
        int phase = 1;
        
        public Fight(int lvl, Game game, List<Units> _unitsSelected)
        {
            InitializeComponent();
            GenerarPantalla(lvl);
            _game = game;
            Units = _unitsSelected;
            DataContext = this;
            this.KeyDown += pressKey;
        }

        public void attackPhases(object sender, RoutedEventArgs e)
        {
            switch(phase)
            {
                case 1:         /*Fase de elección de personaje*/
                    selectUnit(sender, e); 
                    break;
                case 2:         /*Fase de elección de habilidades*/
                    selectSkill(sender, e);
                    break;
                /*case 3:         /*Fase de elección de enemigo*/
                    /*selectEnemy(sender, e);
                    break;*/
            }
        }

        

        public void pressKey(object sender, KeyEventArgs e)
        {
            if(phase == 1)
            {
                switch (e.Key)      //Elegir la unidad
                {
                    case Key.D1:
                        unitSelect = Units[0];
                        selectUnit(sender, e);
                        break;
                    case Key.D2:
                        unitSelect = Units[1];
                        break;
                    case Key.D3:
                        unitSelect = Units[2];
                        break;
                    case Key.D4:
                        unitSelect = Units[3];
                        break;
                }
            }
            if(phase == 3)
            {
                switch (e.Key)      //Habría que intercambiar los mensajes por la función Attack
                {
                    case Key.D1: 
                        MessageBox.Show("Se presionó la tecla 1");
                        break;
                    case Key.D2: 
                        MessageBox.Show("Se presionó la tecla 2");
                        break;
                    case Key.D3: 
                        MessageBox.Show("Se presionó la tecla 3");
                        break;
                    case Key.D4: 
                        MessageBox.Show("Se presionó la tecla 4");
                        break;
                }
                phase = 1;
            }
        }

        //private void selectEnemy(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void selectSkill(object sender, RoutedEventArgs e)
        {
            int id_character = unitSelect.IdCharacter;
            Button clickedButton = (Button)sender;
            if (clickedButton.DataContext is not null)
            {
                string buttonName = clickedButton.Name.ToString();
                
                char lastCharacter = buttonName[buttonName.Length - 1];
                int skillId;
                if (int.TryParse(lastCharacter.ToString(), out skillId))
                {
                    skillSelect = manager.getSkill(id_character, skillId);
                    spSkillsFight.Visibility = Visibility.Hidden;
                    phase = 3;
                }
                else
                {
                    Console.WriteLine("El último carácter no es un número válido.");
                }
            }
        }

        private void selectUnit(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            var unit = clickedButton.DataContext;
            
            if (unit is Units clickedUnit)
            {
                Button[] btnAtk = { btnAtk1, btnAtk2, btnAtk3, btnAtk4 };
                TextBlock[] typeSkill = { typeSkill1, typeSkill2, typeSkill3, typeSkill4 };
                TextBlock[] targetRange = { targetRange1, targetRange2, targetRange3, targetRange4 };
                unitNameAtk.Text = clickedUnit.IdCharacter.ToString(); 
                for (int i = 0; i < 4; i++)
                {
                    btnAtk[i].Content = clickedUnit.Skills[i].Name;
                    typeSkill[i].Text = clickedUnit.Skills[i].SkillType.ToString();
                    targetRange[i].Text = clickedUnit.Skills[i].MultiTargetString;

                    SetSkillTypeColor(typeSkill[i], clickedUnit.Skills[i].SkillType);
                    SetTargetRangeFormatting(targetRange[i], clickedUnit.Skills[i].MultiTarget);
                }
                phase = 2;
                unitSelect = clickedUnit;
            }
            spSkillsFight.Visibility = Visibility.Visible;
        }
        
        private void SetTargetRangeFormatting(TextBlock textBlock, bool isMultiTarget)
        {
            textBlock.FontWeight = isMultiTarget ? FontWeights.Bold : FontWeights.Normal;
        }

        

        private void backUnitAtk(object sender, RoutedEventArgs e)
        {
            resetPhase();
            spSkillsFight.Visibility = Visibility.Collapsed;
        }

        private void Attack(Units Active, List<Units> Passives,Skills AttackSkill) { 
            float multiplier =1;
            float trueMultiplier;
            Random random = new Random();
            bool boost= false;
            bool amp =false;
            int baseDamage=50;
            int hit = Active.HitRate;
            int eva;
            if(AttackSkill.Tier==4)
            {
                baseDamage=400;
            }else if(AttackSkill.Tier==3)
            {
                baseDamage=200;
            }else if (AttackSkill.Tier==2)
            {
                baseDamage=100;
            }
            foreach(Skills skill in Active.Skills) {
                if (skill.IdSkill==53) { 
                    boost = true;
                }
                if (skill.IdSkill==54)
                {
                    amp = true;
                }
            }
            if(boost)
            {
                multiplier *= 1.25f;
            }
            if(amp) 
            {
                multiplier *= 1.5f;
            }
            if (Active.Ailments.Atk)
            {
                multiplier -= 0.25f;
            }
            if (Active.Buff.Atk)
            {
                multiplier += 0.25f;
            }
            if (Active.Buff.HitEva)
            {
                hit += 25;
            }
            if (Active.Ailments.HitEva)
            {
                hit -= 25;
            }

            foreach(Units Passive in Passives) { 
                trueMultiplier=multiplier;
                eva=Passive.Evasion;
                if (Passive.Buff.HitEva)
                {
                    eva += 25;
                }
                if (Passive.Ailments.HitEva)
                {
                    eva -= 25;
                }
                if (random.Next(0, 100)<hit-eva)
                {
                    if (Passive.Ailments.Def)
                    {
                        trueMultiplier += 0.25f;
                    }
                    if (Passive.Buff.Def)
                    {
                        trueMultiplier -= 0.25f;
                    }
                    if (Passive.Buff.Aggro)
                    {
                        trueMultiplier *= 0.7f;
                    }
                    Passive.Hp-=(int)((baseDamage*trueMultiplier)*(Active.Atk/Passive.Def));
                }
                
                
            }
        }

        private void resetPhase()
        {
            unitSelect = null;
            phase = 1;
        }
        private void GenerarPantalla(int lvl)
        {
            switch (lvl)
            {
                case 1:
                    this.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/images/MapPhase1.jpg")));
                    break;
                case 2:
                    this.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/images/MapPhase2.jpg")));
                    break;
            }
        }

        private void SetSkillTypeColor(TextBlock textBlock, string skillType)
        {
            switch (skillType)
            {
                case "Attack":
                    textBlock.Foreground = Brushes.Red;
                    break;
                case "Heal":
                    textBlock.Foreground = Brushes.Green;
                    break;
                case "Debuff":
                    textBlock.Foreground = Brushes.Blue;
                    break;
                case "Boost":
                    textBlock.Foreground = Brushes.Purple;
                    break;
                case "Buff":
                    textBlock.Foreground = Brushes.Orange;
                    break;
                default:
                    textBlock.Foreground = Brushes.Gray;
                    break;
            }
        }


    }
}
