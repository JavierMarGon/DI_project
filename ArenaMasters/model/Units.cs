using ArenaMasters.model;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace ArenaMasters
{
    public class Units
    {
        private string _unitName = "";
        private int _id_character;
        private int _id_rol;
        private string _rol_name;
        private string _image_source;
        private int _hp;
        private int _maxHp;
        private int _atk;
        private int _def;
        private int _hit_rate;
        private int _evasion;
        private int _greed;
        private int _price;
        private int _id_game;
        private bool _alive;
        protected Status _ailments = new Status();
        protected Status _buff = new Status();
        protected List<Skills> _skills = new List<Skills>();

        private ArenaMastersManager _manager = new ArenaMastersManager();
        private GameMenu _game_menu;
        public ICommand SelectedSoldUnit { get; set; }

        public int IdCharacter
        {
            get { return _id_character; }
            set { _id_character = value; }
        }
        public int IdRol
        {
            set { 
                _id_rol = value;
                switch (value)
                {
                    case 1:
                        _rol_name = "Damage";
                        _image_source = "/images/damagepj.png";
                        break;
                    case 2:
                        _rol_name = "Support";
                        _image_source = "/images/supportpj.png";
                        break;
                    case 3:
                        _rol_name = "Healer";
                        _image_source = "/images/healerpj.png";

                        break;
                    case 4:
                        _rol_name = "Control";
                        _image_source = "/images/controlpj.png";
                        break;
                    default:
                        _rol_name = "None";
                        break;
                }
            }
            get { return _id_rol; }
        }
        public int Hp
        { 
            set { _hp = value; } 
            get { return _hp; } 
        }
        public int MaxHp
        {
            set{ _maxHp = value; }
            get { return _maxHp; }
        }
        public int Atk
        {
            set { _atk = value; }
            get { return _atk; }
        }
        public int Def
        { 
            set { _def = value; } 
            get { return _def; } 
        }
        public int HitRate
        {
            set { _hit_rate = value; }
            get { return _hit_rate; }
        }
        public int Evasion
        {
            set { _evasion = value; }
            get { return _evasion; }
        }
        public int Greed
        { 
            set { _greed = value; } 
            get { return _greed; } 
        }
        public int Price
        {
            set { _price = value; }
            get { return _price; }
        }

        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }
        public string ImageSource
        {
            get { return _image_source; }
            set { _image_source = value; }
        }
        public string RolName
        {
            get { return _rol_name; }
            set { _rol_name = value; }
        }
        public bool Alive
        {
            get { return _alive; }
            set { _alive = value; }
        }
        public List<Skills> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }
        public Status Ailments
        {
            get { return _ailments; }
        }
        public Status Buff
        {
            get { return _buff; }
            
        }
        public GameMenu GameMenu
        {
            get { return _game_menu; }
            set { _game_menu = value; }
        }
        public int IdGame
        {
            get { return _id_game; }
            set { _id_game = value; }
        }
        
        public Units(string unitName)
        {
            UnitName = unitName;
        }
        public Units(int id,int idRol, int hp, int atk , int def, int hitRate, int evasion, int greed, int price, List<Skills> skillsData, GameMenu thisGameMenu, int id_game)
        {
            IdCharacter = id;
            IdRol = idRol;
            Hp = hp;
            MaxHp = hp;         //Para obtener el maximo de Hp, esto no se va a modificar nunca
            Atk = atk;
            Def = def;
            HitRate = hitRate;
            Evasion = evasion;
            Greed = greed;
            Price = price;
            GameMenu = thisGameMenu;
            IdGame = id_game;
            UnitName = RolName;
            SelectedSoldUnit = new RelayCommand(DeleteSelectedItem);
            
            foreach (Skills skill in skillsData)
            {
                _skills.Add(skill);
            }
        }
        public Units(int idRol, int hp, int atk, int def, int hitRate, int evasion, List<Skills> skillsData)
        {
            IdRol = idRol;
            Hp = hp;
            MaxHp = hp;         //Para obtener el maximo de Hp, esto no se va a modificar nunca
            Atk = atk;
            Def = def;
            HitRate = hitRate;
            Evasion = evasion;
            UnitName = RolName;
            Alive = AliveComprobation();
            foreach (Skills skill in skillsData)
            {
                _skills.Add(skill);
            }
        }
        public void setSkillByIndex(int index, Skills data)
        {
            _skills[index-1] = data;
            return;
        }
        public Skills getSkillByIndex(int index)
        {
            return _skills[index-1];
        }
        public bool AliveComprobation()
        {
            if (Hp > 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DeleteSelectedItem()
        {
            //tengo que obtener el numero de units
            if (_manager.CountCharacters(IdGame) > 1)
            {
                GameMenu.Beneficio(Price);
                int delete = _manager.SoldUnit(IdCharacter);
                if (delete > 0)
                {
                    GameMenu.initializeUnits();
                    MessageBox.Show("Eliminado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar");
                }
            }
            else
            {
                MessageBox.Show("No puedes eliminar más personajes");
            }
            
        }
        

    }
}
