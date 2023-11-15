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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArenaMasters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void click_register(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
            menu_login.Visibility = Visibility.Hidden;
            menu_register.Visibility = Visibility.Visible;


        }
        private void click_create_register(object sender, RoutedEventArgs e)
        {
            menu_login.Visibility = Visibility.Visible;
            menu_register.Visibility = Visibility.Hidden;
            limpiarCampos();
        }

        private void click_login(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                menu_login.Visibility = Visibility.Collapsed;
                menu_user.Visibility = Visibility.Visible;
            }
            limpiarCampos();

        }

        private void click_cerrarVentana(object sender, RoutedEventArgs e)
        {
            menu_login.Visibility = Visibility.Visible;
            menu_register.Visibility = Visibility.Hidden;
        }

        private void limpiarCampos()
        {
            tb_user.Text = "";
            psw_user.Password = "";
        }

        private void click_continue(object sender, RoutedEventArgs e)
        {
            GameMenu menu = new GameMenu(0);
            this.Close();
            menu.Show();
        }
        private void click_newGame(object sender, RoutedEventArgs e)
        {

        }
        private void click_loadGame(object sender, RoutedEventArgs e)
        {

        }
        private void click_close(object sender, RoutedEventArgs e)
        {
            menu_user.Visibility = Visibility.Collapsed;
            menu_login.Visibility = Visibility.Visible;
        }
    }
}
