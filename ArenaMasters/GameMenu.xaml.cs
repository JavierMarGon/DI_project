using Org.BouncyCastle.Tls;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class GameMenu : Window
    {
        int space = 0;
        int level = 0;
        int rewards = 0;
        Units[] units = new Units[5];
        Random random = new Random();
        public GameMenu()
        {
            InitializeComponent();
            initializeUnits();
            habpjName.Text = units[0].getName();
        }
        public void initializeUnits()
        {
            String name;
            int val=0;
            for (int i = 0; i < 5; i++)
            {
                val= random.Next(0,1);
                name = "pj";
                name += i;
                units[i] = new Units(name);
                if (val == 0)
                {
                    val = random.Next(0,5);
                    units[i].setSkill1(val);
                }
                val = random.Next(0, 1);
                if (val == 0)
                {
                    val = random.Next(0,5);
                    units[i].setSkill2(val);
                }
                val = random.Next(0, 1);
                if (val == 0)
                {
                    val = random.Next(0, 5);
                    units[i].setSkill3(val);
                }
                val = random.Next(0, 1);
                if (val == 0)
                {
                    val = random.Next(0, 5);
                    units[i].setSkill4(val);
                }
            }
        }
        public void habShopShow(object sender, RoutedEventArgs e)
        {
            settingsPanel.Visibility = Visibility.Collapsed;
            space =0;
            habpjName.Text = units[space].getName();
            habpjSkill1.Text = units[space].getSkill1().ToString();
            habpjSkill2.Text = units[space].getSkill2().ToString();
            habpjSkill3.Text = units[space].getSkill3().ToString();
            habpjSkill4.Text = units[space].getSkill4().ToString();
            habShop.Visibility = Visibility.Visible;
        }
        public void habShopHide(object sender, RoutedEventArgs e)
        {
            
            habShop.Visibility = Visibility.Hidden;
        }
        public void pjShopShow(object sender, RoutedEventArgs e)
        {
            settingsPanel.Visibility = Visibility.Collapsed;
            space = 0;
            habpjName.Text = units[space].getName();
            habpjSkill1.Text = units[space].getSkill1().ToString();
            habpjSkill2.Text = units[space].getSkill2().ToString();
            habpjSkill3.Text = units[space].getSkill3().ToString();
            habpjSkill4.Text = units[space].getSkill4().ToString();
            pjShop.Visibility = Visibility.Visible;
            
        }
        public void habAntPj(object sender, RoutedEventArgs e)
        {
            if (space == 0) { space = 4; }
            else { space--; }
            habpjName.Text = units[space].getName();
            habpjSkill1.Text = units[space].getSkill1().ToString();
            habpjSkill2.Text = units[space].getSkill2().ToString();
            habpjSkill3.Text = units[space].getSkill3().ToString();
            habpjSkill4.Text = units[space].getSkill4().ToString();
        }
        public void habNextPj(object sender, RoutedEventArgs e)
        {
            if (space == 4) { space = 0; }
            else { space++; }
            habpjName.Text = units[space].getName();
            habpjSkill1.Text = units[space].getSkill1().ToString();
            habpjSkill2.Text = units[space].getSkill2().ToString();
            habpjSkill3.Text = units[space].getSkill3().ToString();
            habpjSkill4.Text = units[space].getSkill4().ToString();
        }
        public void pjShopHide(object sender, RoutedEventArgs e)
        {
            pjShop.Visibility = Visibility.Hidden;
        }

        private void moneyDungeonShow(object sender, RoutedEventArgs e)
        {
            settingsPanel.Visibility = Visibility.Collapsed;
            moneyDungeonLvSelector.Visibility = Visibility.Visible;
        }
        private void moneyDungeonHide(object sender, RoutedEventArgs e)
        {
            moneyDungeonLvSelector.Visibility = Visibility.Hidden;
        }
        public void levelSelected1(object sender, RoutedEventArgs e)
        {
            level = 1;
            rewards = 500;
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards);
            moneyDungeon.Show();
            this.Close();
            
        }
        public void levelSelected2(object sender, RoutedEventArgs e)
        {
            level = 2;
            rewards = 1500;
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards);
            this.Close();
            moneyDungeon.Show();
        }
        public void levelSelected3(object sender, RoutedEventArgs e)
        {
            level = 3;
            rewards = 2750;
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards);
            this.Close();
            moneyDungeon.Show();
        }
        public void levelSelected4(object sender, RoutedEventArgs e)
        {
            level = 4;
            rewards = 4000;
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards);
            this.Close();
            moneyDungeon.Show();
        }
        public void levelSelected5(object sender, RoutedEventArgs e)
        {
            level = 5;
            rewards = 10000;

            int actualMoney = Int32.Parse(currentMoney.Text.ToString());
            currentMoney.Text = (actualMoney+=rewards).ToString();
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards);
            this.Close();
            moneyDungeon.Show();
        }
        public void habChangeSkill1(object sender, RoutedEventArgs e)
        {
            int val = random.Next(0, 5);
            units[space].setSkill1(val);
            habpjSkill1.Text = units[space].getSkill1().ToString();
        }
        public void habChangeSkill2(object sender, RoutedEventArgs e)
        {
            int val = random.Next(0, 5);
            units[space].setSkill1(val);
            habpjSkill2.Text = units[space].getSkill1().ToString();
        }
        public void habChangeSkill3(object sender, RoutedEventArgs e)
        {
            int val = random.Next(0, 5);
            units[space].setSkill1(val);
            habpjSkill3.Text = units[space].getSkill1().ToString();
        }
        public void habChangeSkill4(object sender, RoutedEventArgs e)
        {
            int val = random.Next(0, 5);
            units[space].setSkill1(val);
            habpjSkill4.Text = units[space].getSkill1().ToString();
        }

        private void settingsPanelShow(object sender, RoutedEventArgs e)
        {
            settingsPanel.Visibility = Visibility.Visible;
        }
    }
}
