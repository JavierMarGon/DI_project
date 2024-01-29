using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ArenaMasters.model
{
    internal class Partida
    {
        private int _id_user;
        private string _uname;
        private int _id_game;
        private int _money;
        private int _round;
        private DateTime _lastPlay;
        ArenaMastersManager manager;
        MainWindow window;
        Game game;
        public ICommand MyCommand { get; set; }
        public ICommand MyCommandDelete { get; set; }

        public int IdGame
        {
            get { return _id_game; }
            set { _id_game = value; }
        }
        public int IdUser
        {
            get { return _id_user; }
            set { _id_user = value; }
        }
        public string UserName
        {
            get { return _uname; }
            set { _uname = value; }
        }


        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public int Round
        {
            get { return _round; }
            set { _round = value; }
        }

        public DateTime LastPlay
        {
            get { return _lastPlay; }
            set { _lastPlay = value; }
        }

        public Partida(int _idUser,string _userName, int id_game, int money, int round, DateTime lastPlay, MainWindow win,ArenaMastersManager man)
        {
            manager = man;
            UserName = _userName;
            IdUser = _idUser;
            window = win;
            MyCommand = new RelayCommand(GetFromListGame);
            MyCommandDelete = new RelayCommand(DeleteGame);
           
            IdGame = id_game;
            Money = money;
            Round = round;
            LastPlay = lastPlay;
        }
        private void GetFromListGame()
        {
            game = manager.GetGame(IdGame, UserName, IdUser);
            GameMenu menu = new GameMenu(game);
            window.Close();
            menu.Show();

        }

        private void DeleteGame()
        {
            manager.DeleteGame(IdGame);
            manager.GetAllGames(IdUser);
            window.menu_loadGames.Visibility = Visibility.Collapsed;
            window.menu_user.Visibility = Visibility.Visible;
            window.EnablingMenu();
        }
    }
}
