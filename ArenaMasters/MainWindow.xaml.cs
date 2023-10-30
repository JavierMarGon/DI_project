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
            limpiarCampos();
            GameMenu menu = new GameMenu();
            this.Close();
            menu.Show();
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
    }
}
