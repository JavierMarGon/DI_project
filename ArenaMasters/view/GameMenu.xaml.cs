﻿using ArenaMasters.model;
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
        List<Units> units;
        public Units shopItemSelected;
        MusicController controller= new MusicController();

        public GameMenu(Game _game)
        {
            InitializeComponent();
            game = _game;
            namePj.Text = game.Name.ToString();
            currentMoney.Text = game.Money.ToString();
            controller.stop();
            playSimpleSound();
            initializeUnits();
            DataContext = manager;
            manager.GameMenu = this;
        }
        public GameMenu(Game _game,int reward)
        {
            InitializeComponent();     
            game = _game;
            manager.NextRound(game.IdGame);
            Beneficio(reward);
            namePj.Text = game.Name.ToString();
            currentMoney.Text = game.Money.ToString();
            controller.stop();
            playSimpleSound();
            initializeUnits();
            DataContext = manager;
            manager.GameMenu = this;
        }

        public void initializeShop()
        {
            RefreshStoreValue.Text = (1000+(500*game.Refresh)).ToString();
            manager.GetAllShopItems(game.IdGame);
        }
        public void initializeUnits()
        {
            //esto sere el count de las unidades de la partida
            units = new List<Units>();
            foreach (Units item in manager.GetAllCharacters(game.IdGame))
            {
                units.Add(item);
            }
            maxUnits = manager.CountCharacters(game.IdGame);
            currentUnits.Text = maxUnits.ToString() + "/7";
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
                controller.playPrincipal();
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
                controller.restoreVolume();
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
                controller.switchVolume();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            initializeUnits();
            settingsPanel.Visibility = Visibility.Collapsed;
            setting.Visibility = Visibility.Collapsed;
            cementery.Visibility = Visibility.Visible;
        }


        public void habShopShow(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.switchVolume();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            settingsPanel.Visibility = Visibility.Collapsed;
            setting.Visibility = Visibility.Collapsed;
            space = 0;
            habShopItemImage.Source = new BitmapImage(new Uri(units[space].ImageSource, UriKind.Relative));
            habpjName.Text = units[space].UnitName.ToString();
            greedLvl.Text = units[space].Greed.ToString();
            newHabPrice.Text = (units[space].Greed * 150).ToString();
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
                controller.restoreVolume();
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
                controller.switchVolume();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            initializeShop();
            setting.Visibility = Visibility.Collapsed;
            settingsPanel.Visibility = Visibility.Collapsed;
            pjShop.Visibility = Visibility.Visible;

        }
        public bool Comprar(int valor)
        {
            if (game.Money >= Math.Abs(valor))
            {
                manager.updateMoney(game.IdGame, valor);
                game.Money += valor;
                currentMoney.Text = game.Money.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Beneficio(int valor)
        {
            manager.updateMoney(game.IdGame, valor);
            game.Money += valor;
            currentMoney.Text = game.Money.ToString();
        }
        private void ClickBuyUnitShop(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            Shop selectedUnit = (Shop)btn.DataContext;

            int id_item = selectedUnit.IdItem;
            if (maxUnits < 7 && selectedUnit.Price < game.Money)
            {

                Comprar(-selectedUnit.Price);
                int buy = manager.BuyUnit(id_item);
                if (buy > 0 && maxUnits < 7)
                {
                    MessageBox.Show("Comprado correctamente");
                    initializeUnits();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                DataContext = manager;
                initializeShop();
                pjShopDetails.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Excedido");
            }

        }

        public void habAntPj(object sender, RoutedEventArgs e)
        {
            if (space == 0) { space = maxUnits - 1; }
            else { space--; }
            greedLvl.Text = units[space].Greed.ToString();
            newHabPrice.Text = (units[space].Greed * 150).ToString();
            habShopItemImage.Source = new BitmapImage(new Uri(units[space].ImageSource, UriKind.Relative));
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
            greedLvl.Text = units[space].Greed.ToString();
            newHabPrice.Text = (units[space].Greed * 150).ToString();
            habShopItemImage.Source = new BitmapImage(new Uri(units[space].ImageSource, UriKind.Relative));
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
                controller.restoreVolume();
                //controller.stop();
                //playSimpleSound();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            pjShop.Visibility = Visibility.Hidden;
        }
        public void pjShopDetailsHide(object sender, RoutedEventArgs e)
        {
            pjShopDetails.Visibility = Visibility.Collapsed;
            DataContext = manager;
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
            ShowUnitSelectionGrid();
        }

        public void levelSelected2(object sender, RoutedEventArgs e)
        {
            level = 2;
            ShowUnitSelectionGrid();
        }

        public void levelSelected3(object sender, RoutedEventArgs e)
        {
            level = 3;
            ShowUnitSelectionGrid();
        }

        public void levelSelected4(object sender, RoutedEventArgs e)
        {
            level = 4;
            ShowUnitSelectionGrid();
        }

        public void levelSelected5(object sender, RoutedEventArgs e)
        {
            level = 5;
            ShowUnitSelectionGrid();
        }

        private void ShowUnitSelectionGrid()
        {
            gridSelectedUnits.Visibility = Visibility.Visible;
        }

        private void BackSelectUnits(object sender, RoutedEventArgs e)
        {
            gridSelectedUnits.Visibility = Visibility.Hidden;

        }

        private void SelectUnitsAndProceed(object sender, RoutedEventArgs e)
        {
            if (listBoxUnits.SelectedItems.Count > 0)
            {
                List<Units> unitsSelected = new List<Units>();
                // Proceed to MoneyDungeon with the selected level and units
                foreach (Units unit in listBoxUnits.SelectedItems)
                {
                    unitsSelected.Add(unit);
                }
                controller.stop();
                MoneyDungeon moneyDungeon = new MoneyDungeon(level, game, unitsSelected,false);
                moneyDungeon.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select at least one unit before proceeding.");
            }
        }
        private void finalDungeonShow(object sender, RoutedEventArgs e)
        {
            gridFinalSelectedUnits.Visibility = Visibility.Visible;
            finalDungeonSelector.Visibility = Visibility.Visible;
        }
        private void SelectUnitsAndProceedEnding(object sender, RoutedEventArgs e)
        {
            if (listBoxFinalUnits.SelectedItems.Count > 0)
            {
                List<Units> unitsSelected = new List<Units>();
                // Proceed to MoneyDungeon with the selected level and units
                foreach (Units unit in listBoxFinalUnits.SelectedItems)
                {
                    unitsSelected.Add(unit);
                }
                controller.stop();
                MoneyDungeon moneyDungeon = new MoneyDungeon(1, game, unitsSelected, true);
                moneyDungeon.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select at least one unit before proceeding.");
            }
        }
        private void BackSelectUnitsEnding(object sender, RoutedEventArgs e)
        {
            gridFinalSelectedUnits.Visibility = Visibility.Hidden;
            finalDungeonSelector.Visibility = Visibility.Hidden;


        }
        public void habChange(int val)
        {
            Skills skill_data = manager.SetRandomSkill(units[space].IdCharacter, val);
            if (skill_data != null)
            {
                if (game.Money > units[space].Greed * 150)
                {
                    TextBlock textBlock = (TextBlock)FindName("habpjSkill"+val);
                    Comprar(-units[space].Greed * 150);
                    units[space].setSkillByIndex(val, skill_data);
                    textBlock.Text = units[space].getSkillByIndex(val).Name.ToString();
                    initializeUnits();
                    greedLvl.Text = units[space].Greed.ToString();
                    newHabPrice.Text = (units[space].Greed * 150).ToString();
                }

            }
        }
        public void habChangeSkill1(object sender, RoutedEventArgs e)
        {
            habChange(1);
        }
        public void habChangeSkill2(object sender, RoutedEventArgs e)
        {
            habChange(2);

        }
        public void habChangeSkill3(object sender, RoutedEventArgs e)
        {
            habChange(3);

        }
        public void habChangeSkill4(object sender, RoutedEventArgs e)
        {
            habChange(4);

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
            controller.stop();
            this.Close();
            mainWindow.Show();
        }

        private void refreshShop(object sender, RoutedEventArgs e)
        {
            if (Comprar(-(1000 + (500 * game.Refresh))))
            {
                manager.refreshShop(game.IdGame);
                game.Refresh += 1;
                initializeShop();
            }
            
        }

        
    }
}
