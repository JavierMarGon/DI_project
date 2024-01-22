using ArenaMasters.model;
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
        int maxUnits = 0;
        int _gameId = 0;
        int space = 0;
        int level = 0;
        int rewards = 0;
        ArenaMastersManager manager = new ArenaMastersManager();
        Game game;
        Units[] units;
        Random random = new Random();
        MediaPlayer mediaPlayer = new MediaPlayer();

        public GameMenu(Game _game)
        {
            InitializeComponent();
            game = _game;
            namePj.Text = game.Name.ToString();
            currentMoney.Text = game.Money.ToString();
            initializeUnits();
            currentUnits.Text = maxUnits.ToString() + "/7";
            
        }


        public void initializeUnits()
        {
            playSimpleSound();
            
            String name;
            int val = 0;
            maxUnits = 7; //esto sere el count de las unidades de la partida
            units = new Units[maxUnits];
            for (int i = 0; i < maxUnits; i++)
            {
                val = random.Next(0, 1);
                name = "pj";
                name += i;
                units[i] = new Units(name);
                if (val == 0)
                {
                    val = random.Next(0, 5);
                    units[i].setSkill1(val);
                }
                val = random.Next(0, 1);
                if (val == 0)
                {
                    val = random.Next(0, 5);
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

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            // Cierra la ventana cuando la reproducción ha terminado
            Close();
        }

        private void playSimpleSound()
        {
            try
            {
                mediaPlayer.Open(new Uri("music/PantallaPrincipal.mp3", UriKind.Relative));
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        public void cementeryHide(object sender, RoutedEventArgs e)
        {
            setting.Visibility = Visibility.Visible;
            try
            {
                mediaPlayer.Close();
                playSimpleSound();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            cementery.Visibility = Visibility.Hidden;
        }

        public void cementeryShow(object sender, RoutedEventArgs e)
        {
            try
            {
                mediaPlayer.Close();
                mediaPlayer.Open(new Uri("music/Cementerio.mp3", UriKind.Relative));
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            settingsPanel.Visibility = Visibility.Collapsed;
            setting.Visibility = Visibility.Collapsed;
            cementery.Visibility = Visibility.Visible;
        }


        public void habShopShow(object sender, RoutedEventArgs e)
        {
            try
            {
                mediaPlayer.Close();
                mediaPlayer.Open(new Uri("music/Taberna.mp3", UriKind.Relative));
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            settingsPanel.Visibility = Visibility.Collapsed;
            setting.Visibility = Visibility.Collapsed;
            space = 0;
            habpjName.Text = units[space].getName();
            habpjSkill1.Text = units[space].getSkill1().ToString();
            habpjSkill2.Text = units[space].getSkill2().ToString();
            habpjSkill3.Text = units[space].getSkill3().ToString();
            habpjSkill4.Text = units[space].getSkill4().ToString();
            habShop.Visibility = Visibility.Visible;
        }
        public void habShopHide(object sender, RoutedEventArgs e)
        {
            setting.Visibility = Visibility.Visible;
            try
            {
                mediaPlayer.Close();
                playSimpleSound();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            habShop.Visibility = Visibility.Hidden;
        }

        public void habShopHide(object sender)
        {
            habShop.Visibility = Visibility.Collapsed;
        }
        public void pjShopShow(object sender, RoutedEventArgs e)
        {
            try
            {
                mediaPlayer.Close();
                mediaPlayer.Open(new Uri("music/Encrucijada.mp3", UriKind.Relative));
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            setting.Visibility = Visibility.Collapsed;
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
            if (space == 0) { space = maxUnits - 1; }
            else { space--; }
            habpjName.Text = units[space].getName();
            habpjSkill1.Text = units[space].getSkill1().ToString();
            habpjSkill2.Text = units[space].getSkill2().ToString();
            habpjSkill3.Text = units[space].getSkill3().ToString();
            habpjSkill4.Text = units[space].getSkill4().ToString();
        }
        public void habNextPj(object sender, RoutedEventArgs e)
        {
            if (space == maxUnits - 1) { space = 0; }
            else { space++; }
            habpjName.Text = units[space].getName();
            habpjSkill1.Text = units[space].getSkill1().ToString();
            habpjSkill2.Text = units[space].getSkill2().ToString();
            habpjSkill3.Text = units[space].getSkill3().ToString();
            habpjSkill4.Text = units[space].getSkill4().ToString();
        }
        public void pjShopHide(object sender, RoutedEventArgs e)
        {
            setting.Visibility = Visibility.Visible;
            try
            {
                mediaPlayer.Close();
                playSimpleSound();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            pjShop.Visibility = Visibility.Hidden;
        }

        public void pjShopHide(object sender)
        {
            setting.Visibility = Visibility.Visible;

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

        public void cautionMessageDeletHide(object sender, RoutedEventArgs e)
        {
            CautionMessage.Visibility = Visibility.Collapsed;
        }

        public void cautionMessageDeletShow(object sender, RoutedEventArgs e)
        {
            CautionMessage.Visibility = Visibility.Visible;
        }

        public void deletPj(object sender, RoutedEventArgs e/*int idPj*/)
        {
            MessageBox.Show("pj eliminado");
            CautionMessage.Visibility = Visibility.Collapsed;
        }

        public void levelSelected1(object sender, RoutedEventArgs e)
        {
            level = 1;
            rewards = 500;
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards, game);
            moneyDungeon.Show();
            this.Close();

        }
        public void levelSelected2(object sender, RoutedEventArgs e)
        {
            level = 2;
            rewards = 1500;
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards, game);
            this.Close();
            moneyDungeon.Show();
        }
        public void levelSelected3(object sender, RoutedEventArgs e)
        {
            level = 3;
            rewards = 2750;
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards, game);
            this.Close();
            moneyDungeon.Show();
        }
        public void levelSelected4(object sender, RoutedEventArgs e)
        {
            level = 4;
            rewards = 4000;
            MoneyDungeon moneyDungeon = new MoneyDungeon(level, rewards, game);
            this.Close();
            moneyDungeon.Show();
        }
        public void levelSelected5(object sender, RoutedEventArgs e)
        {
            level = 5;
            rewards = 10000;

            int actualMoney = Int32.Parse(currentMoney.Text.ToString());
            currentMoney.Text = (actualMoney += rewards).ToString();

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
            units[space].setSkill2(val);
            habpjSkill2.Text = units[space].getSkill2().ToString();
        }
        public void habChangeSkill3(object sender, RoutedEventArgs e)
        {
            int val = random.Next(0, 5);
            units[space].setSkill3(val);
            habpjSkill3.Text = units[space].getSkill3().ToString();
        }
        public void habChangeSkill4(object sender, RoutedEventArgs e)
        {
            int val = random.Next(0, 5);
            units[space].setSkill4(val);
            habpjSkill4.Text = units[space].getSkill4().ToString();
        }

        private void settingsPanelShow(object sender, RoutedEventArgs e)
        {
            habShopHide(sender);
            pjShopHide(sender);
            moneyDungeonHide(sender, e);
            if (settingsPanel.Visibility == Visibility.Visible)
            {
                settingsPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                settingsPanel.Visibility = Visibility.Visible;
            }

        }
        public void exitGame(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(game.IdUser, game.Name);
            this.Close();
            mainWindow.Show();

        }
    }
}
