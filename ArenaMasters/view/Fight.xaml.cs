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
        List<Units> self = new List<Units>();
        List<Units> cpu = new List<Units>();
        Game _game;
        public Fight(int lvl, Game game)
        {
            GenerarPantalla(lvl);
            _game = game;
            InitializeComponent();
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
