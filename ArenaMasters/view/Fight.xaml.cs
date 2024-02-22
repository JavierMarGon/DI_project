using ArenaMasters.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
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
        Game _game;
        public Fight(int lvl, Game game, List<Units> _unitsSelected)
        {
            InitializeComponent();
            GenerarPantalla(lvl);
            _game = game;
            Units = _unitsSelected;
            DataContext = this;
        }


        private void GenerarPantalla(int lvl)
        {
            switch(lvl)
            {
                case 1:
                    this.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/images/MapPhase1.jpg")));
                    break;
                case 2:
                    this.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/images/MapPhase2.jpg")));
                    break;
            }
        }

        private void clickUnitFight(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.DataContext is Units clickedUnit)
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

            }
            spSkillsFight.Visibility = Visibility.Visible;
        }
        
        private void SetTargetRangeFormatting(TextBlock textBlock, bool isMultiTarget)
        {
            textBlock.FontWeight = isMultiTarget ? FontWeights.Bold : FontWeights.Normal;
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

        private void backUnitAtk(object sender, RoutedEventArgs e)
        {
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

        
    }
}
