using Org.BouncyCastle.Tls;
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
        Units[] units = new Units[5];
        public GameMenu()
        {
            InitializeComponent();
            initializeUnits();
            habpjName.Text = units[0].getName();
        }
        public void initializeUnits()
        {
            String name;
            for (int i = 0; i < 5; i++)
            {
                name = "pj";
                name += i;
                units[i] = new Units(name);
            }
        }
        public void habShopShow(object sender, RoutedEventArgs e)
        {
            habShop.Visibility = Visibility.Visible;
        }
        public void habShopHide(object sender, RoutedEventArgs e)
        {
            habpjName.Text = units[0].getName();
            habShop.Visibility = Visibility.Hidden;
        }
        public void pjShopShow(object sender, RoutedEventArgs e)
        {
            space = 0;
            habpjName.Text = units[space].getName();
            pjShop.Visibility = Visibility.Visible;
            
        }
        public void habAntPj(object sender, RoutedEventArgs e)
        {
            if (space == 0) { space = 4; }
            else { space--; }
            habpjName.Text = units[space].getName();
        }
        public void habNextPj(object sender, RoutedEventArgs e)
        {
            if (space == 4) { space = 0; }
            else { space++; }
            habpjName.Text = units[space].getName();
        }
        public void pjShopHide(object sender, RoutedEventArgs e)
        {
            pjShop.Visibility = Visibility.Hidden;
        }

        private void moneyDungeonShow(object sender, RoutedEventArgs e)
        {
            moneyDungeonLvSelector.Visibility = Visibility.Visible;
        }
        private void moneyDungeonHide(object sender, RoutedEventArgs e)
        {
            moneyDungeonLvSelector.Visibility = Visibility.Hidden;
        }
    }
}
