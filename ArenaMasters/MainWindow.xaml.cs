using ArenaMasters.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
        ArenaMastersManager manager = new ArenaMastersManager();
        Game game;
        int id_user;
        string userName;
        MediaPlayer mediaPlayer = new MediaPlayer();
        public MainWindow()
        {
            
            InitializeComponent();
            playSimpleSound();
        }
        public MainWindow(int user)
        {
            InitializeComponent();
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
                mediaPlayer.Open(new Uri("music/InicioSesion.mp3", UriKind.Relative));
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void click_register(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
            menu_login.Visibility = Visibility.Hidden;
            menu_register.Visibility = Visibility.Visible;


        }
        private void click_create_register(object sender, RoutedEventArgs e)
        {
            if (reg_password.Password.ToString() == reg_password_check.Password.ToString()) {
                if (manager.Register(reg_username.Text.ToString(),reg_password.Password.ToString()) == 1)
                {
                    menu_login.Visibility = Visibility.Visible;
                    menu_register.Visibility = Visibility.Hidden;
                }
            }
            limpiarCampos();
        }

        private void click_login(object sender, RoutedEventArgs e)
        {
            id_user = manager.Login(tb_user.Text.ToString(), psw_user.Password.ToString());
            if (id_user > 0)
            {
                userName = tb_user.Text.ToString();
                menu_login.Visibility = Visibility.Collapsed;
                menu_user.Visibility = Visibility.Visible;
            }
            limpiarCampos();

        }

        private void click_cerrarVentana(object sender, RoutedEventArgs e)
        {
            menu_login.Visibility = Visibility.Visible;
            menu_register.Visibility = Visibility.Hidden;
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            tb_user.Text = "";
            psw_user.Password = "";
            reg_username.Text = "";
            reg_password.Password = "";
            reg_password_check.Password = "";
        }

        private void click_continue(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Close();
            int id_game = manager.ContinueGame(id_user);
            game = manager.GetGame(id_game, userName);
            GameMenu menu = new GameMenu(game);
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
