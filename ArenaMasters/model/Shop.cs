using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Input;

namespace ArenaMasters.model
{
    internal class Shop
    {
        private int _id_item;
        private int _id_game;
        private int _id_rol;
        private string _rol_name;
        private string _price_value;
        private string _image_source;
        private int _hp;
        private int _atk;
        private int _def;
        private int _hit_rate;
        private int _evasion;
        private int _price;
        private GameMenu _game_menu;
        private ArenaMastersManager _manager;
        protected List<Skills> _skills = new List<Skills>();
        public ICommand SelectedItemFromShop { get; set; }


        public int IdItem
        {
            get { return _id_item; }
            set { _id_item = value;
            }
        }
        public int IdRol
        {
            get { return _id_rol; }
            set { _id_rol = value; }
        }
        public string RolName
        {
            get { return _rol_name; }
            set { _rol_name = value; }
        }
        public int Hp
        {
            get { return _hp; }
            set { _hp = value;}
        }
        public int Atk
        {
            get { return _atk; }
            set { _atk = value; }
        }
        public int Def
        {
            get { return _def; }
            set { _def = value; }
        }
        public int HitRate
        {
            get { return _hit_rate; }
            set { _hit_rate = value; }
        }
        public int Evasion
        {
            get { return _evasion; }
            set { _evasion = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string PriceValue
        {
            get { return _price_value; }
            set { _price_value = value; }
        }
        public int IdGame
        {
            get { return _id_game; }
            set
            {
                _id_game = value;
            }
        }
        public string ImageSource
        {
            get { return _image_source; }
            set { _image_source = value; }
        }
        public GameMenu GameMenu
        {
            get { return _game_menu; }
            set { _game_menu = value; }
        }public ArenaMastersManager Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }
        private List<Skills> _allSkills;

        public List<Skills> AllSkills
        {
            get { return _allSkills; }
            set
            {
                if (_allSkills != value)
                {
                    _allSkills = value;
                }
            }
        }

        public Shop(int idItem, int idRol, int hp, int atk, int def, int hit, int eva, int price, GameMenu thisGameMenu, ArenaMastersManager manager, int id_game)
        {
            IdItem = idItem;
            IdRol = idRol;
            Hp = hp;
            Atk = atk; 
            Def = def; 
            HitRate = hit; 
            Evasion = eva; 
            Price = price;
            GetRolName();
            GameMenu = thisGameMenu;
            Manager = manager;
            PriceValue = Price.ToString();
            SelectedItemFromShop = new RelayCommand(GetSelectedItem);
            _skills = manager.fetchAllShopSkills(idItem);
            AllSkills = _skills;
            IdGame = id_game;
        }
        private void GetSelectedItem()
        {
            GameMenu.shopItemSelected = new Units(IdItem,IdRol,Hp,Atk,Def,HitRate,Evasion,0,Price, _skills, GameMenu, IdGame);
            GameMenu.DataContext = this;

            GameMenu.pjShopDetails.Visibility = Visibility.Visible;
        }
        private void GetRolName()
        {
            if(IdRol == 1)
            {
                RolName = "Damage";
                ImageSource = "/images/damagepj.png";
            }
            else if(IdRol == 2)
            {
                RolName = "Support";
                ImageSource = "/images/supportpj.png";
            }
            else if(IdRol == 3)
            {
                RolName = "Healer";
                ImageSource = "/images/healerpj.png";
            }
            else if( IdRol == 4)
            {
                RolName = "Control";
                ImageSource = "/images/controlpj.png";
            }
        }
    }
}
