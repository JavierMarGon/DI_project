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
        private int phase = 1;
        private int _lvl;
        
        public Fight(int lvl, Game game, List<Units> _unitsSelected)
        {
            _lvl = lvl;
            InitializeComponent();
            GenerarPantalla(lvl);
            _game = game;
            Units = _unitsSelected;
            DataContext = this;
            generateEnemy(lvl);
            this.KeyDown += pressKey;
        }
        private void generateEnemy(int lvl)
        {
            cpu.Clear();
            Units generated;
            Random random = new Random();
            int rol = 0;
            int hp = 0;
            int ata = 0;
            int def = 0;
            int hit = 0;
            int eva = 0;
            List<Skills> skillset;
            int value = random.Next(3, 5);
            for (int i = 0; i < value; i++)
            {
                skillset = new List<Skills>();
                skillset.Clear();
                rol = random.Next(1, 5);
                if (rol == 1)
                {
                    hp = 140 + (10 * lvl);
                    ata = 6 + (2 * lvl);
                    def = 3 + (1 * lvl);
                    hit = 5 + (2 * lvl);
                    eva = 5 + (2 * lvl);
                    if (lvl >= 2)
                    {
                        skillset.Add(manager.fetchOneSkills(lvl, rol));
                    }
                    if (lvl >= 3)
                    {
                        skillset.Add(manager.fetchOneSkills(lvl, rol));
                    }
                }

                else if (rol == 2)
                {
                    hp = 190 + (10 * lvl);
                    ata = 4 + (1 * lvl);
                    def = 7 + (3 * lvl);
                    hit = 4 + (2 * lvl);
                    eva = 4 + (1 * lvl);
                }

                else if (rol == 3)
                {
                    hp = 250 + (20 * lvl);
                    ata = 2 + (1 * lvl); ;
                    def = 5 + (1 * lvl); ;
                    hit = 5 + (1 * lvl); ;
                    eva = 15 + (2 * lvl); ;
                }

                else if (rol == 4)
                {
                    hp = 200 + (15 * lvl);
                    ata = 5 + (2 * lvl);
                    def = 6 + (1 * lvl);
                    hit = 10 + (2 * lvl);
                    eva = 8 + (3 * lvl);
                }
                if (lvl >= 1)
                {
                    skillset.Add(manager.fetchOneSkills(lvl, rol - 1));
                }
               
                if (lvl >= 4)
                {
                    skillset.Add(manager.fetchOneSkills(lvl, rol - 1));
                }

                generated = new Units(rol, hp, ata, def, hit, eva, skillset);
            }
        }
        public void btnSkillSelector(object sender, RoutedEventArgs e)
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
                }
                else
                {
                    Console.WriteLine("El último carácter no es un número válido.");
                }
            }
        }

        private int getKeyValue(Key key)
        {
            int value = -1;
            
            switch (key)
            {
                case Key.D1: 
                    value = 1;
                    break;
                case Key.D2:
                    value = 2;
                    break;
                case Key.D3:
                    value = 3;
                    break;
                case Key.D4:
                    value = 4;
                    break;
                case Key.Escape:
                    value = 0;
                    break;
            }
            return value;       
        }

        public void pressKey(object sender, KeyEventArgs e)
        {
            int value = 0;
            value = getKeyValue(e.Key);
            if (phase == 1)
            {
                try {
                    if (Units[value-1].Alive())
                    {
                        unitSelect = Units[value-1];
                        
                        loadUnitInfo(unitSelect);
                    }                 
                }
                catch { }
                return;           
            }
            if(phase == 2)
            {
                try
                {
                    skillSelect = unitSelect.getSkillByIndex(value);
                    nextPhase();
                }
                catch { }
                return;
            }
        }

        //private void selectEnemy(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void selectSkill(Skills skill)
        {
            if (skill.TargetFoe) 
            {
                //inhabilitar botones de muñecos propios
            }
            else
            {
                //inhabilitar botones de muñecos ajenos
            }
            if (skill.MultiTarget)
            {
                //seleccionar todos los muñecos
            }
        }
        private void loadUnitInfo(Units unit)
        {
            Button[] btnAtk = { btnAtk1, btnAtk2, btnAtk3, btnAtk4 };
            TextBlock[] typeSkill = { typeSkill1, typeSkill2, typeSkill3, typeSkill4 };
            TextBlock[] targetRange = { targetRange1, targetRange2, targetRange3, targetRange4 };
            unitNameAtk.Text = unit.IdCharacter.ToString();
            for (int i = 0; i < 4; i++)
            {
                btnAtk[i].Content = unit.Skills[i].Name;
                typeSkill[i].Text = unit.Skills[i].SkillType.ToString();
                targetRange[i].Text = unit.Skills[i].MultiTargetString;

                SetSkillTypeColor(typeSkill[i], unit.Skills[i].SkillType);
                SetTargetRangeFormatting(targetRange[i], unit.Skills[i].MultiTarget);
            }
            unitSelect = unit;
            nextPhase();
            spSkillsFight.Visibility = Visibility.Visible;
        }
        private void selectUnit(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            var unit = clickedButton.DataContext;
            
            if (unit is Units clickedUnit)
            {
                loadUnitInfo(clickedUnit);
            }
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
        private void nextPhase() 
        {
            phase++;
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
