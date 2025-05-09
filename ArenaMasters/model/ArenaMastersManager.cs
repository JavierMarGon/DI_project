﻿using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace ArenaMasters.model
{

    class ArenaMastersManager : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private DataAccess _ad = new DataAccess();


        //Campos privados

        ObservableCollection<Shop> _shopInventory;
        ObservableCollection<Units> _Inventory;
        ObservableCollection<Units> _PlayerUnits;
        ObservableCollection<Units> _UnitsSelected;
        ObservableCollection<Units> _CPUUnits;
        private ObservableCollection<Partida> _gameList;
        private int _id_User;
        private string _userName;
        List<Units> units;
        private List<int> _killedCharactersID;
        private MainWindow _mainWindow;
        private GameMenu _gameWindow;
        //Propiedades (campos publicos)
        public MainWindow MainWindow
        {
            get { return _mainWindow; }
            set { _mainWindow = value; }
        }
        public List<int> KilledCharactersID
        {
            get { return _killedCharactersID; }
            set { _killedCharactersID = value; }
        }
        public GameMenu GameMenu
        {
            get { return _gameWindow; }
            set { _gameWindow = value; }
        }
        public int id_User
        {
            get { return _id_User; }
            set { _id_User = value; }
        }
        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public ObservableCollection<Partida> GameList
        {
            get { return _gameList; }
            set
            {
                _gameList = value;
                OnPropertyChanged("GameList");
            }
        }
        public ObservableCollection<Shop> ShopInventory
        {
            get { return _shopInventory; }
            set
            {
                _shopInventory = value;
                OnPropertyChanged("ShopInventory");
            }
        }
        public ObservableCollection<Units> Inventory
        {
            get { return _Inventory; }
            set
            {
                _Inventory = value;
                OnPropertyChanged("Inventory");
            }
        }
        public ObservableCollection<Units> PlayerUnits
        {
            get { return _PlayerUnits; }
            set
            {
                _PlayerUnits = value;
                OnPropertyChanged("PlayerUnits");
            }
        }
        
        public ObservableCollection<Units> CPUUnits
        {
            get { return _CPUUnits; }
            set
            {
                _CPUUnits = value;
                OnPropertyChanged("CPUUnits");
            }
        }
        public ObservableCollection<Units> UnitsSelected
        {
            get { return _UnitsSelected; }
            set
            {
                _UnitsSelected = value;
                OnPropertyChanged("UnitsSelected");
            }
        }
        //Constructor(es)
        public ArenaMastersManager()
        {
            _shopInventory = new ObservableCollection<Shop>();
            _gameList = new ObservableCollection<Partida>();
            _Inventory = new ObservableCollection<Units>();
            _PlayerUnits = new ObservableCollection<Units>();
            _CPUUnits = new ObservableCollection<Units>();
            _UnitsSelected = new ObservableCollection<Units>();
        }
        //Metodos (de Negocio)

        public int Login(string usuario, string pass)
        {
            //Comprobaciones previas
            int id_user = _ad.PA_Login(usuario, pass);
            if (id_user > 0)
            {
                return id_user;
            }
            else
            {
                return -1;
            }
        }
        public int Register(string nombre, string pass)
        {
            //Comprobaciones previas

            if (_ad.PA_Register(nombre, pass) == 1)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int GetUser(string name, string psw)
        {
            int id_user = _ad.PA_FindUser(name, psw);
            if (id_user > 0)
            {
                return id_user;
            }
            else
            {
                MessageBox.Show("Error GetUser");
                return -1;
            }
        }

        public int ContinueGame(int id_user)
        {
            int id_game = _ad.PA_ContinueGame(id_user);
            if (id_game > 0)
            {
                return id_game;
            }
            else
            {
                MessageBox.Show("Error ContinueGame");
                return -1;
            }
        }

        public int NewGame(int id_user)
        {
            if (_ad.PA_NewGame(id_user) > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public int NextRound(int id_game)
        {
            if (_ad.PA_NextRound(id_game) > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Game GetGame(int id_game, string name, int id_user)
        {
            string jsonResult = _ad.PA_GetGameData(id_game);   //Obtengo los datos de la partida
            var gameData = JsonConvert.DeserializeAnonymousType(jsonResult, new
            {
                Res = 0,
                Money = 0,
                Round = 0,
                Refresh = 0
            });

            if (gameData != null)
            {
                return new Game(
                                id_game,
                                id_user,
                                name,
                                gameData.Round,
                                gameData.Refresh,
                                gameData.Money
                                );
            }

            return null;
        }

        public Skills SetRandomSkill(int id_character, int placement)
        {
            if (_ad.PA_RandomSkill(id_character, placement) > 0)
            {

                string jsonResult = _ad.PA_GetSkillData(id_character, placement);
                var skillData = JsonConvert.DeserializeAnonymousType(jsonResult, new
                {
                    IdSkill = 0,
                    Name = "",
                    Description = "",
                    Type = "",
                    Tier = 0,
                    Target = false,
                    TargetRange = false
                });
                return new Skills(
                                    skillData.IdSkill,
                                    skillData.Name,
                                    skillData.Description,
                                    skillData.Type,
                                    skillData.Tier,
                                    skillData.Target,
                                    skillData.TargetRange
                                    );
            }
            else
            {
                MessageBox.Show("cagada");
                return null;       //No tiene partidas guardadas
            }
        }

        public List<Skills> fetchAllSkills(int id_character)
        {
            
            List<Skills> skillsData = new List<Skills>();
            for (int i = 1; i < 5; i++)
            {
                string jsonResult = _ad.PA_GetSkillData(id_character, i);
                var skillData = JsonConvert.DeserializeAnonymousType(jsonResult, new
                {
                    IdSkill = 0,
                    Name = "",
                    Description = "",
                    Type = "",
                    Tier = 0,
                    Target = false,
                    TargetRange = false
                });
                if (skillData != null)
                {
                    Skills temp =new Skills
                                    (skillData.IdSkill,
                                    skillData.Name,
                                    skillData.Description,
                                    skillData.Type,
                                    skillData.Tier,
                                    skillData.Target,
                                    skillData.TargetRange
                                    );
                    skillsData.Add(temp);
                }
            }
            return skillsData;

        }

        public Skills getSkill(int id_character, int place)
        {
            Skills skill;
            string jsonResult = _ad.PA_GetSkillData(id_character, place);
            var skillData = JsonConvert.DeserializeAnonymousType(jsonResult, new
            {
                IdSkill = 0,
                Name = "",
                Description = "",
                Type = "",
                Tier = 0,
                Target = false,
                TargetRange = false
            });
            if (skillData != null)
            {
                return skill = new Skills(
                                    skillData.IdSkill,
                                    skillData.Name,
                                    skillData.Description,
                                    skillData.Type,
                                    skillData.Tier,
                                    skillData.Target,
                                    skillData.TargetRange
                                    );
            }
            return null;
        }

        public List<Skills> fetchAllShopSkills(int id_character)
        {
            List<Skills> skillsData = new List<Skills>();
            for (int i = 1; i < 5; i++)
            {
                string jsonResult = _ad.PA_GetItemSkillData(id_character, i);
                var skillData = JsonConvert.DeserializeAnonymousType(jsonResult, new
                {
                    IdSkill = 0,
                    Name = "",
                    Description = "",
                    Type = "",
                    Tier = 0,
                    Target = false,
                    TargetRange = false
                });
                if (skillData != null)
                {
                    skillsData.Add(new Skills(
                                    skillData.IdSkill,
                                    skillData.Name,
                                    skillData.Description,
                                    skillData.Type,
                                    skillData.Tier,
                                    skillData.Target,
                                    skillData.TargetRange
                                    ));
                }
            }
            return skillsData;

        }
        public Skills fetchOneSkills(int tier, int type)
        {
            Skills skill;
            string jsonResult = _ad.PA_GetRandomSkill(tier, type);
            var skillData = JsonConvert.DeserializeAnonymousType(jsonResult, new
            {
                IdSkill = 0,
                Name = "",
                Description = "",
                Type = "",
                Tier = 0,
                Target = false,
                TargetRange = false
            });
            if (skillData != null)
            {
                return skill = new Skills(
                                    skillData.IdSkill,
                                    skillData.Name,
                                    skillData.Description,
                                    skillData.Type,
                                    skillData.Tier,
                                    skillData.Target,
                                    skillData.TargetRange
                                    );
            }
            return null;

        }
        public void GetAllGames(int id_user)
        {
            GameList.Clear();

            DataSet dataGames = new DataSet();
            dataGames = _ad.PA_GetAllGames(id_user);
            try
            {
                foreach (DataRow dr in dataGames.Tables[0].Rows)
                {
                    Partida p;
                    p = new Partida(id_User,
                                    userName,
                                    int.Parse(dr.ItemArray[0].ToString()),
                                    int.Parse(dr.ItemArray[1].ToString()),
                                    int.Parse(dr.ItemArray[2].ToString()),
                                    DateTime.Parse(dr.ItemArray[3].ToString()),
                                    MainWindow,
                                    this);
                    GameList.Add(p);
                }
                OnPropertyChanged("GameList");
            }
            catch (Exception e)
            {
                MainWindow.menu_loadGames.Visibility = Visibility.Collapsed;
                MainWindow.menu_user.Visibility = Visibility.Visible;
                MainWindow.EnablingMenu();
            }

        }
        public void GetAllShopItems(int id_game)
        {
            ShopInventory.Clear();

            DataSet dataGames = new DataSet();
            dataGames = _ad.PA_GetAllShopItems(id_game);
            try
            {
                foreach (DataRow dr in dataGames.Tables[0].Rows)
                {
                    Shop s;
                    s = new Shop(int.Parse(dr.ItemArray[0].ToString()),
                                    int.Parse(dr.ItemArray[1].ToString()),
                                    int.Parse(dr.ItemArray[2].ToString()),
                                    int.Parse(dr.ItemArray[3].ToString()),
                                    int.Parse(dr.ItemArray[4].ToString()),
                                    int.Parse(dr.ItemArray[5].ToString()),
                                    int.Parse(dr.ItemArray[6].ToString()),
                                    int.Parse(dr.ItemArray[7].ToString()),
                                    GameMenu,
                                    this,
                                    id_game);
                    ShopInventory.Add(s);
                }
                OnPropertyChanged("ShopInventory");
            }
            catch (Exception e)
            {

            }

        }
        public List<Units> GetAllCharacters(int id_game)
        {

            List<Units> uds = new List<Units>();
            DataSet dataUnits = new DataSet();
            dataUnits = _ad.PA_GetAllCharacters(id_game);
            try
            {
                foreach (DataRow dr in dataUnits.Tables[0].Rows)
                {
                    uds.Add(new Units(
                        int.Parse(dr.ItemArray[0].ToString()),
                        int.Parse(dr.ItemArray[1].ToString()),
                        int.Parse(dr.ItemArray[2].ToString()),
                        int.Parse(dr.ItemArray[3].ToString()),
                        int.Parse(dr.ItemArray[4].ToString()),
                        int.Parse(dr.ItemArray[5].ToString()),
                        int.Parse(dr.ItemArray[6].ToString()),
                        int.Parse(dr.ItemArray[7].ToString()),
                        int.Parse(dr.ItemArray[8].ToString()),
                        fetchAllSkills(int.Parse(dr.ItemArray[0].ToString())),
                        GameMenu,
                        id_game
                        ));
                }
                Inventory = new ObservableCollection<Units>();
                foreach (Units unit in uds)
                {
                    Inventory.Add(unit);
                }

                OnPropertyChanged("Inventory");
                return uds;
            }
            catch (Exception e)
            {
                return uds;
            }
        }

        public void GetAllUnitsSelected(List<Units> unitsSelected)
        {
            UnitsSelected.Clear();
            foreach(Units unit in unitsSelected)
            {
                UnitsSelected.Add(unit);
            }
            OnPropertyChanged("UnitsSelected");
        }


        public int updateMoney(int idgame, int profit)
        {
            if (_ad.PA_UpdateMoney(idgame, profit) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int refreshShop(int id_game)
        {
            if (_ad.PA_eraseShop(id_game) > 0)
            {
                return 1;       //Tiene partidas guardadas
            }
            else
            {
                return 0;       //No tiene partidas guardadas
            }
        }
        public int CountGames(int id_user)
        {
            if (_ad.PA_CountGames(id_User) > 0)
            {
                return 1;       //Tiene partidas guardadas
            }
            else
            {
                return 0;       //No tiene partidas guardadas
            }
        }
        public int CountCharacters(int id_game)
        {
            int val = _ad.PA_CountCharacters(id_game);
            if (val > 0)
            {
                return val;       //Tiene partidas guardadas
            }
            else
            {
                return 0;       //No tiene partidas guardadas
            }
        }

        public int DeleteGame(int id_game)
        {
            if (_ad.PA_deleteGame(id_game) > 0)
            {
                OnPropertyChanged("GameList");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int BuyUnit(int thisShopUnit)
        {
            if (_ad.PA_BuyUnit(thisShopUnit) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int SoldUnit(int thisUnit)
        {
            if (_ad.PA_SoldUnit(thisUnit) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
