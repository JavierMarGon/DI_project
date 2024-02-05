using ArenaMasters.model;
using Org.BouncyCastle.Tls;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace ArenaMasters
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class GameMenu : Window
    {
        int maxUnits;
        int space = 0;
        int level = 0;
        int rewards = 0;
        ArenaMastersManager manager = new ArenaMastersManager();
        Game game;
        List<Units> units ;
        Units shopItemSelected;
        Random random = new Random();
        MediaPlayer mediaPlayer = new MediaPlayer();

        public GameMenu(Game _game)
        {
            InitializeComponent();
            game = _game;
            namePj.Text = game.Name.ToString();
            currentMoney.Text = game.Money.ToString();
            playSimpleSound();
            initializeUnits();
            
            currentUnits.Text = maxUnits.ToString() + "/7";
            
        }

        public void initializeShop()
        {
            List<int> shopInventory = new List<int>();
            ////esto sere el count de las unidades de la partida
            //units = new List<Units>();
            //unitsIds = manager.GetAllShopCharactersId(game.IdGame);
            //foreach (int id in unitsIds)
            //{
            //    units.Add(new Units(id, manager.fetchAllSkills(id)));
            //}
        }
        public void refreshShop()
        {
            //List<int> unitsIds = new List<int>();
            ////esto sere el count de las unidades de la partida
            //units = new List<Units>();
            //unitsIds = manager.GetAllCharactersId(game.IdGame);
            //foreach (int id in unitsIds)
            //{
            //    units.Add(new Units(id, manager.fetchAllSkills(id)));
            //}
            //maxUnits = manager.CountCharacters(game.IdGame);
        }

        
        public void initializeUnits()
        {
            List<int> unitsIds = new List<int>();
            //esto sere el count de las unidades de la partida
            units = new List<Units>();
            unitsIds=manager.GetAllCharactersId(game.IdGame); 
            foreach (int id in unitsIds )
            {
                units.Add(new Units(id,manager.fetchAllSkills(id)));  
            }
            maxUnits = manager.CountCharacters(game.IdGame);
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
            habpjName.Text = "";
            habpjSkill1.Text = units[space].getSkillByIndex(1).Name.ToString();
            habpjSkill2.Text = units[space].getSkillByIndex(2).Name.ToString();
            habpjSkill3.Text = units[space].getSkillByIndex(3).Name.ToString();
            habpjSkill4.Text = units[space].getSkillByIndex(4).Name.ToString();
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
            habpjName.Text = units[space].UnitName;
            habpjSkill1.Text = units[space].getSkillByIndex(1).Name.ToString();
            habpjSkill2.Text = units[space].getSkillByIndex(2).Name.ToString();
            habpjSkill3.Text = units[space].getSkillByIndex(3).Name.ToString();
            habpjSkill4.Text = units[space].getSkillByIndex(4).Name.ToString();
            pjShop.Visibility = Visibility.Visible;

        }
        public void habAntPj(object sender, RoutedEventArgs e)
        {
            if (space == 0) { space = maxUnits - 1; }
            else { space--; }
            habpjName.Text = units[space].UnitName;
            habpjSkill1.Text = units[space].getSkillByIndex(1).Name.ToString();
            habpjSkill2.Text = units[space].getSkillByIndex(2).Name.ToString();
            habpjSkill3.Text = units[space].getSkillByIndex(3).Name.ToString();
            habpjSkill4.Text = units[space].getSkillByIndex(4).Name.ToString();
        }
        public void habNextPj(object sender, RoutedEventArgs e)
        {
            if (space == maxUnits - 1) { space = 0; }
            else { space++; }
            habpjName.Text = units[space].UnitName;
            habpjSkill1.Text = units[space].getSkillByIndex(1).Name.ToString();
            habpjSkill2.Text = units[space].getSkillByIndex(2).Name.ToString();
            habpjSkill3.Text = units[space].getSkillByIndex(3).Name.ToString();
            habpjSkill4.Text = units[space].getSkillByIndex(4).Name.ToString();
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
            Skills skill_data = manager.SetRandomSkill(units[space].IdCharacter, 1);
            if (skill_data != null)
            {
                units[space].setSkillByIndex(1, skill_data);
                habpjSkill1.Text = units[space].getSkillByIndex(1).Name.ToString();
            }
        }
        public void habChangeSkill2(object sender, RoutedEventArgs e)
        {

            Skills skill_data = manager.SetRandomSkill(units[space].IdCharacter, 2);
            if (skill_data != null)
            {
                units[space].setSkillByIndex(2, skill_data);
                habpjSkill2.Text = units[space].getSkillByIndex(2).Name.ToString();
            }
        }
        public void habChangeSkill3(object sender, RoutedEventArgs e)
        {
            
            Skills skill_data = manager.SetRandomSkill(units[space].IdCharacter, 3);
            if (skill_data != null)
            {
                units[space].setSkillByIndex(3, skill_data);
                habpjSkill3.Text = units[space].getSkillByIndex(3).Name.ToString();
            }
        }
        public void habChangeSkill4(object sender, RoutedEventArgs e)
        {

            Skills skill_data = manager.SetRandomSkill(units[space].IdCharacter, 4);
            if (skill_data != null)
            {
                units[space].setSkillByIndex(4, skill_data);
                habpjSkill4.Text = units[space].getSkillByIndex(4).Name.ToString();
            }
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
