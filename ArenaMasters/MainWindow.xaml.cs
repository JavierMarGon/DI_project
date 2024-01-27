using ArenaMasters.model;
using CommunityToolkit.Mvvm.Input;
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
        
        MediaPlayer mediaPlayer = new MediaPlayer();
        public MainWindow()
        {
            
            InitializeComponent();
            playSimpleSound();
            DataContext = manager;
            manager.MainWindow= this;
            if (manager.id_User > 0)
            {
                menu_login.Visibility = Visibility.Collapsed;
                menu_user.Visibility = Visibility.Visible;
            }
        }
        public MainWindow(int user, string username)
        {
            InitializeComponent();
            DataContext = manager;
            manager.MainWindow = this;
            manager.id_User = user;
            manager.userName = username;
            noGame(false);
            menu_login.Visibility = Visibility.Collapsed;
            menu_user.Visibility = Visibility.Visible;
            playSimpleSound();
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
            manager.id_User = manager.Login(tb_user.Text.ToString(), psw_user.Password.ToString());
            if (manager.id_User > 0)
            {
                if(manager.CountGames(manager.id_User) < 1)
                {
                    noGame(true);
                }
                manager.userName = tb_user.Text.ToString();
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
            int id_game = manager.ContinueGame(manager.id_User);
            game = manager.GetGame(id_game, manager.userName, manager.id_User);
            GameMenu menu = new GameMenu(game);
            this.Close();
            menu.Show();
        }
        private void click_newGame(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Close();
            if(manager.NewGame(manager.id_User) > 0)
            {
                int id_game = manager.ContinueGame(manager.id_User);
                game = manager.GetGame(id_game, manager.userName, manager.id_User);
                GameMenu menu = new GameMenu(game);
                this.Close();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Error al crear nueva partida");
            }

        }
        private void click_loadGame(object sender, RoutedEventArgs e)
        {
            menu_user.Visibility = Visibility.Collapsed;
            manager.GetAllGames(manager.id_User);
            menu_loadGames.Visibility = Visibility.Visible;
            sp_loadGames.Visibility = Visibility.Visible;
        }
        private void click_close(object sender, RoutedEventArgs e)
        {
            menu_user.Visibility = Visibility.Collapsed;
            menu_login.Visibility = Visibility.Visible;
        }

        private void click_exit_loadGames(object sender, RoutedEventArgs e)
        {
            menu_loadGames.Visibility = Visibility.Collapsed;
            sp_loadGames.Visibility = Visibility.Collapsed;
            menu_user.Visibility = Visibility.Visible;
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            // Obtén la Partida seleccionada
            if (sender is FrameworkElement element && element.DataContext is Partida partida)
            {
                int idPartida = partida.IdGame;
                // Ahora, puedes usar idPartida para realizar otras operaciones.
                MessageBox.Show($"Clicaste en la partida con ID: {idPartida}");
            }
        }

        private void noGame(bool x)
        {
            if (x)
            {
                btnContinue.IsEnabled = false;
                btnContinue.Opacity = 0.5;
                btnLoadGame.IsEnabled = false;
                btnLoadGame.Opacity = 0.5;
            }
            else
            {
                btnContinue.IsEnabled = true;
                btnContinue.Opacity = 1;
                btnLoadGame.IsEnabled = true;
                btnLoadGame.Opacity = 1;
            }
        }

    }
}
