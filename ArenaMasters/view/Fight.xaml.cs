using ArenaMasters.model;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Math.EC.Multiplier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ArenaMasters
{
    /// <summary>
    /// Lógica de interacción para Fight.xaml
    /// </summary>
    public partial class Fight : Window
    {
        
        ArenaMastersManager manager = new ArenaMastersManager();
        Units playerUnitSelect;
        List<Units> passives = new List<Units>();
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
            if (manager.PlayerUnits != null)
            {
                manager.PlayerUnits.Clear();
            }
            manager.PlayerUnits = new ObservableCollection<Units>(_unitsSelected);
            if (manager.CPUUnits != null)
            {
                manager.CPUUnits.Clear();
            }
            manager.CPUUnits = new ObservableCollection<Units>(generateEnemy(lvl));
            DataContext = manager;
            phaseTxt.Text = "Phase " + phase.ToString();
            setKeyListener();
        }
        private void selectUnit(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            var unit = clickedButton.DataContext;
            if (phase == 1)
            {
                if (unit is Units clickedUnit)
                {
                    if (clickedUnit.AliveComprobation())
                    {
                        loadUnitInfo(clickedUnit);
                        nextPhase();
                    }
                }
            }
            if (phase == 3)
            {
                if (unit is Units clickedUnit)
                {
                    if (passives != null)
                    {
                        passives.Clear();
                        passives = new List<Units>();
                    }
                    if (skillSelect.TargetFoe)
                    {
                        if (skillSelect.MultiTarget)
                        {
                            passives = manager.CPUUnits.ToList();
                        }
                        else
                        {
                            passives.Add(clickedUnit);
                        }
                    }
                    else
                    {
                        if (skillSelect.IdSkill == 50 || skillSelect.IdSkill == 51)
                        {
                            if (!clickedUnit.AliveComprobation())
                            {
                                passives.Add(clickedUnit);
                            }
                        }
                        else
                        {
                            if (skillSelect.MultiTarget)
                            {
                                passives = manager.PlayerUnits.ToList();
                            }
                            else
                            {
                                passives.Add(clickedUnit);
                            }
                        }
                    }
                }

                selectSkillAction(playerUnitSelect, skillSelect, passives);
                lastUserSkillUsed.Text = "Has usado " + skillSelect.Name;
                resetPhase();

            }
            setKeyListener();
        }
        public void btnSkillSelector(object sender, RoutedEventArgs e)
        {
            int id_character = playerUnitSelect.IdCharacter;
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
                    preparationSelectPassives(skillSelect);
                }
                else
                {
                    Console.WriteLine("El último carácter no es un número válido.");
                }
            }
            setKeyListener();
        }

        private void selectPassivesClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            var unit = clickedButton.DataContext;
            if (phase == 3) {
                if (unit is Units clickedUnit)
                {
                    if (passives != null)
                    {
                        passives.Clear();
                        passives = new List<Units>();
                    }
                    if (skillSelect.TargetFoe)
                    {
                        if (skillSelect.MultiTarget)
                        {
                            passives = manager.CPUUnits.ToList();
                        }
                        else
                        {
                            passives.Add(clickedUnit);
                        }
                    }
                    else
                    {
                        if (skillSelect.IdSkill == 50 || skillSelect.IdSkill == 51)
                        {
                            if (!clickedUnit.AliveComprobation())
                            {
                                passives.Add(clickedUnit);
                            }
                        }
                        else
                        {
                            if (skillSelect.MultiTarget)
                            {
                                passives = manager.PlayerUnits.ToList();
                            }
                            else
                            {
                                passives.Add(clickedUnit);
                            }
                        }
                    }
                }

                selectSkillAction(playerUnitSelect, skillSelect, passives);
                lastUserSkillUsed.Text = "Has usado " + skillSelect.Name;
                setKeyListener();

                resetPhase();
            }
            
        }
        private void setKeyListener()
        {
            this.KeyDown += pressKey;
        }
        private List<Units> generateEnemy(int lvl)
        {
            List<Units> cpuUnits = new List<Units>();
            int auxLvl;
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
            auxLvl = lvl;
            if (auxLvl > 4)
            {
                auxLvl = 4;
            }
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
                    if (lvl >= 1)
                    {
                        skillset.Add(manager.fetchOneSkills(auxLvl, 1));
                    }
                    if (lvl >= 2)
                    {
                        skillset.Add(manager.fetchOneSkills(2, 2));
                    }
                    if (lvl >= 3)
                    {
                        skillset.Add(manager.fetchOneSkills(3, 2));
                    }

                    if (lvl >= 4)
                    {

                        skillset.Add(manager.fetchOneSkills(auxLvl, 1));
                    }
                }

                else if (rol == 2)
                {
                    hp = 190 + (10 * lvl);
                    ata = 4 + (1 * lvl);
                    def = 7 + (3 * lvl);
                    hit = 7 + (2 * lvl);
                    eva = 4 + (1 * lvl);
                    if (lvl >= 1)
                    {
                        skillset.Add(manager.fetchOneSkills(auxLvl, 1));
                    }
                    if (lvl >= 2)
                    {
                        skillset.Add(manager.fetchOneSkills(1+(lvl%2), 3));
                    }
                    if (lvl >= 3)
                    {
                        skillset.Add(manager.fetchOneSkills(1+(lvl % 2), 3));
                    }

                    if (lvl >= 4)
                    {
                        skillset.Add(manager.fetchOneSkills(auxLvl, 1));
                    }
                }

                else if (rol == 3)
                {
                    hp = 250 + (20 * lvl);
                    ata = 2 + (1 * lvl);
                    def = 5 + (1 * lvl);
                    hit = 3 + (1 * lvl); 
                    eva = 7 + (2 * lvl);
                    if (lvl >= 1)
                    {
                        skillset.Add(manager.fetchOneSkills(auxLvl, 1));
                    }
                    if (lvl >= 2)
                    {
                        skillset.Add(manager.fetchOneSkills(2, 4));
                    }
                    if (lvl >= 3)
                    {
                        skillset.Add(manager.fetchOneSkills(2, 4));
                    }

                    if (lvl >= 4)
                    {
                        skillset.Add(manager.fetchOneSkills(auxLvl, 1));
                    }
                }

                else if (rol == 4)
                {
                    hp = 200 + (15 * lvl);
                    ata = 5 + (2 * lvl);
                    def = 6 + (1 * lvl);
                    hit = 10 + (2 * lvl);
                    eva = 8 + (3 * lvl);
                    if (lvl >= 1)
                    {
                        skillset.Add(manager.fetchOneSkills(auxLvl, 1));
                    }
                    if (lvl >= 2)
                    {
                        skillset.Add(manager.fetchOneSkills(1+(lvl%2), 5));
                    }
                    if (lvl >= 3)
                    {
                        skillset.Add(manager.fetchOneSkills(1+(lvl % 2), 5));
                    }

                    if (lvl >= 4)
                    {
                        skillset.Add(manager.fetchOneSkills(auxLvl, 1));
                    }
                }


                generated = new Units(rol, hp, ata, def, hit, eva, skillset);
                cpuUnits.Add(generated);
            }
            return cpuUnits;
        }
        void enemyAction()
        {
            Random random = new Random();
            Units cpu;
            List<Units> pj = new List<Units>();
            Skills cpuSkill;
            int value = random.Next(0, manager.CPUUnits.Count());
            cpu = manager.CPUUnits[value];
            do
            {
                value = random.Next(0, cpu.Skills.Count());
            } while (cpu.Skills[value].SkillType == "Boost");
            cpuSkill = cpu.Skills[value];
            value= random.Next(0, manager.PlayerUnits.Count());
            if (cpuSkill.TargetFoe)
            {
                if (cpuSkill.MultiTarget)
                {       
                    pj= manager.PlayerUnits.ToList();
                }
                if (value <= manager.PlayerUnits.Count)
                {
                    pj.Add(manager.PlayerUnits[value]);                   
                }
            }
            else
            {
                if (cpuSkill.IdSkill == 50 || cpuSkill.IdSkill == 51)
                {
                    if (!manager.CPUUnits[value].AliveComprobation())
                    {
                        pj.Add(manager.CPUUnits[value]);
                    }
                }
                else
                {
                    if (cpuSkill.MultiTarget)
                    {
                        pj= manager.CPUUnits.ToList();
                    }
                    if (value <= manager.CPUUnits.Count)
                    {
                        pj.Add(manager.CPUUnits[value]);
                    }
                }

            }

            selectSkillAction(cpu,cpuSkill,pj);
            lastEnemySkillUsed.Text = "El enemigo usó " + cpuSkill.Name;
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
                case Key.Enter: 
                    value = 5;
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
                    if (manager.PlayerUnits[value-1].AliveComprobation())
                    {
                        playerUnitSelect = manager.PlayerUnits[value-1];
                        
                        loadUnitInfo(playerUnitSelect);
                        nextPhase();
                    }                 
                }
                catch { }
                return;           
            }
            if(phase == 2)
            {
                try
                {
                    if (value == 0) {
                        priorPhase();
                        spSkillsFight.Visibility = Visibility.Hidden;
                        return;
                    }
                    skillSelect = playerUnitSelect.getSkillByIndex(value);
                    if (skillSelect.SkillType != "Boost") {
                        spSkillsFight.Visibility = Visibility.Hidden;
                        preparationSelectPassives(skillSelect);
                    }
                    
                }
                catch { }
                return;
            }
            if (phase == 3)
            {
                try
                {
                    if (value == 0)
                    {
                        
                        priorPhase();
                        return;
                    }
                    if (passives!=null)
                    {
                        passives.Clear();
                    }
                    passives=selectPassives(skillSelect,value-1);
                }
                catch { }
                return;
            }
            if (phase == 4)
            {
                try
                {
                    if (value == 0)
                    {
                        priorPhase();
                    }
                    if (value == 5)
                    {
                        selectSkillAction(playerUnitSelect, skillSelect, passives);
                        lastUserSkillUsed.Text = "Has usado " + skillSelect.Name;

                        resetPhase();
                    }
                }
                catch { }
                return;
            }
            setKeyListener();
        }

        private void preparationSelectPassives(Skills skill)
        {
            spUnits.IsEnabled = true;
            spEnemy.IsEnabled = true;
            if (skill.TargetFoe)
            {
                spUnits.IsEnabled = false;
            }
            else
            {
                spEnemy.IsEnabled = false;
            }
            nextPhase();
        }
       
        private List<Units> selectPassives(Skills skill,int value)
        {
            List<Units> list = new List<Units>();
            if (skill.TargetFoe)
            {
                if (skill.MultiTarget)
                {
                    nextPhase();
                    return manager.CPUUnits.ToList();
                }
                if (value <= manager.CPUUnits.Count)
                {
                    list.Add(manager.CPUUnits[value]);
                    nextPhase();
                    return list;
                }
            }
            else
            {
                if(skill.IdSkill==50 || skill.IdSkill == 51)
                {
                    if (!manager.PlayerUnits[value].AliveComprobation()) 
                    {
                        list.Add(manager.PlayerUnits[value]);
                        nextPhase();
                        return list;
                    }
                }
                else
                {
                    if (skill.MultiTarget)
                    {
                        nextPhase();
                        return manager.PlayerUnits.ToList();
                    }
                    if (value <= manager.PlayerUnits.Count)
                    {
                        list.Add(manager.PlayerUnits[value]);
                        nextPhase();
                        return list;
                    }
                }
                
            }
            
            return null;
        }
        private void selectSkillAction(Units active,Skills skill,List<Units>passive)
        {
            switch (skill.SkillType)
            {
                case "Attack":
                    Attack(active, passive, skill);
                    break;
                case "Heal":
                    if (skill.IdSkill == 50 || skill.IdSkill == 51)
                    {
                        Revive(passive, skill);
                    }
                    else
                    {
                        Heal(active, passive, skill);
                    }
                    break;
                case "Debuff":
                        Debuff(active, passive, skill);
                    break;
                case "Buff":
                        Buff(passive, skill);
                    break ;
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
                btnAtk[i].IsEnabled = true;
                btnAtk[i].Content = unit.Skills[i].Name;
                typeSkill[i].Text = unit.Skills[i].SkillType.ToString();
                targetRange[i].Text = unit.Skills[i].MultiTargetString;
                if (unit.Skills[i].SkillType == "Boost")
                {
                    btnAtk[i].IsEnabled = false;
                }
                SetSkillTypeColor(typeSkill[i], unit.Skills[i].SkillType);
                SetTargetRangeFormatting(targetRange[i], unit.Skills[i].MultiTarget);
            }
            playerUnitSelect = unit;
            spSkillsFight.Visibility = Visibility.Visible;
        }
        
        private void SetTargetRangeFormatting(TextBlock textBlock, bool isMultiTarget)
        {
            textBlock.FontWeight = isMultiTarget ? FontWeights.Bold : FontWeights.Normal;
        }

        

        private void backUnitAtk(object sender, RoutedEventArgs e)
        {
            priorPhase();
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
                if (Passive.AliveComprobation())
                {
                    if (Passive.Buff.HitEva)
                    {
                        eva += 25;
                    }
                    if (Passive.Ailments.HitEva)
                    {
                        eva -= 25;
                    }
                    if (random.Next(0, 100) < (80 + (hit / 2) - eva))
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
                        Passive.Hp -= (int)(baseDamage * (trueMultiplier * (1+(Active.Atk - (Passive.Def / 2)/10))));
                    }
                }
            }
            //Comprobar si quedan unidades con vida
            if (AllPlayerUnitsDead())
            {
                MessageBox.Show("Has perdido");

                this.Close();
            }

        }

        public bool AllPlayerUnitsDead()
        {
            foreach (Units unit in manager.PlayerUnits)
            {
                // Comprueba si la unidad está viva
                if (unit.AliveComprobation())
                {
                    return false; // Si al menos una unidad está viva, retorna false
                }
            }
            return true; // Si todas las unidades están muertas, retorna true
        }

        private void Heal(Units Active, List<Units> Passives, Skills healSkill)
        {
            float baseValue;
            int finalValue;
            float multiplier = 1;
            bool boost = false;
            
            baseValue = Active.MaxHp;
            foreach (Skills skill in Active.Skills)
            {
                if (skill.IdSkill == 52)
                {
                    boost = true;
                }
                
            }
            switch (healSkill.IdSkill)
            {
                case 46 or 47:
                    baseValue *= 0.25f;
                    break;
                
                case 48 or 49:
                    baseValue *= 0.5f;
                    break;

            }
            if (boost)
            {
                multiplier *= 1.25f;
            }
            finalValue = (int)(baseValue * multiplier);
            foreach (Units Passive in Passives) 
            {
                Passive.Hp += finalValue;
                if (Passive.Hp>Passive.MaxHp) 
                {
                    Passive.Hp = Passive.MaxHp;
                }
            }
        }
        private void Revive(List<Units> Passives, Skills healSkill)
        {
            float resValue = 0f;
            int finalValue;
            if (healSkill.IdSkill == 50)
            {
                resValue = 0.5f;
            }
            if (healSkill.IdSkill == 51)
            {
                resValue = 1f;
            }

            foreach (Units Passive in Passives)
            {
                finalValue = (int)(Passive.MaxHp * resValue);
                Passive.Hp += finalValue;
                Passive.Alive = true;
                if (Passive.Hp > Passive.MaxHp)
                {
                    Passive.Hp = Passive.MaxHp;
                }
            }
        }
        private void Buff(List<Units> Passives, Skills buffSkill)
        {
            
            string type = buffSkill.Name;
            if (type.Contains("Ata"))
            {
                foreach (Units Passive in Passives)
                {
                    Passive.Buff.Atk=true;
                }
            } else if (type.Contains("Def"))
            {
                foreach (Units Passive in Passives)
                {
                    Passive.Buff.Def = true;

                }
            } else if (type.Contains("Eva"))
            {
                foreach (Units Passive in Passives)
                {
                    Passive.Buff.HitEva = true;

                }
            }
            else if (type.Contains("Aggro"))
            {
                foreach (Units Passive in Passives)
                {
                    Passive.Buff.Aggro = true;

                }
            }

        }
        private void Debuff(Units Active, List<Units> Passives, Skills buffSkill)
        {
            Random random = new Random();
            int hit =Active.HitRate;
            int eva;
            string type = buffSkill.Name;

            if (Active.Buff.HitEva)
            {
                hit += 25;
            }
            if (Active.Ailments.HitEva)
            {
                hit -= 25;
            }

            if (type.Contains("Ata"))
            {
                foreach (Units Passive in Passives)
                {
                    eva = Passive.Evasion;
                    if (Passive.Buff.HitEva)
                    {
                        eva += 25;
                    }
                    if (Passive.Ailments.HitEva)
                    {
                        eva -= 25;
                    }
                    if (random.Next(0, 100) < (50 + hit - eva))
                    {
                        Passive.Ailments.Atk = true;
                    }
                }
            }
            else if (type.Contains("Def"))
            {
                foreach (Units Passive in Passives)
                {
                    eva = Passive.Evasion;
                    if (Passive.Buff.HitEva)
                    {
                        eva += 25;
                    }
                    if (Passive.Ailments.HitEva)
                    {
                        eva -= 25;
                    }
                    if (random.Next(0, 100) < (50 + hit - eva))
                    {
                        Passive.Ailments.Def=true;
                    }
                }
            }
            else if (type.Contains("Eva"))
            {
                foreach (Units Passive in Passives)
                {
                    eva = Passive.Evasion;
                    if (Passive.Buff.HitEva)
                    {
                        eva += 25;
                    }
                    if (Passive.Ailments.HitEva)
                    {
                        eva -= 25;
                    }
                    if (random.Next(0, 100) < (50 + hit - eva))
                    {
                        Passive.Ailments.HitEva = true;
                    }
                }
            }
        }
        private void nextPhase() 
        {
            if (phase < 4)
            {
                phase++;
                phaseTxt.Text = "Phase " + phase.ToString();
            }
        }
        private void priorPhase()
        {
            if (phase > 1)
            {
                phase--;
                phaseTxt.Text = "Phase " + phase.ToString();
            }           
        }
        private bool deadCPUUnitsComprobation()
        {
            List<Units> aliveUnits= new List<Units>();
            foreach(Units unit in manager.CPUUnits)
            {
                if (unit.AliveComprobation())
                {
                    aliveUnits.Add(unit);
                }
            }
            manager.CPUUnits.Clear();
            if (aliveUnits.Count()>0) 
            {
                foreach (Units unit in aliveUnits)
                {
                    manager.CPUUnits.Add(unit);
                }
            }
            else
            {
                this.Close();
            }
            if (manager.CPUUnits.Count() > 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
            
        }
        private void resetPhase()
        {
            if (!deadCPUUnitsComprobation())
            {
                enemyAction();
                spEnemy.IsEnabled = true;
                spUnits.IsEnabled = true;
                DataContext = null;
                DataContext = manager;
                playerUnitSelect = null;
                phase = 1;
                phaseTxt.Text = "Phase " + phase.ToString();
            }
            
            
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
