using ArenaMasters.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ArenaMasters
{
    public class Units
    {
        private string _unitName = "";
        private int _id_character;
        private int _id_rol;
        private string _rol_name;
        private int _hp;
        private int _atk;
        private int _def;
        private int _hit_rate;
        private int _evasion;
        private int _greed;
        private int _price;
        protected List<Skills> _skills = new List<Skills>();
        public int IdCharacter
        {
            get { return _id_character; }
            set { _id_character = value; }
        }
        public int IdRol
        {
            set { _id_rol = value; }
            get { return _id_rol; }
        }
        public int Hp
        { 
            set { _hp = value; } 
            get { return _hp; } 
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
        public Units(string unitName)
        {
            UnitName = unitName;
        }
        public Units(int id,int idRol, int hp, int atk , int def, int hitRate, int evasion, int greed, int price, List<Skills> skillsData)
        {
            IdCharacter = id;
            IdRol = idRol;
            Hp = hp;
            Atk = atk;
            Def = def;
            HitRate = hitRate;
            Evasion = evasion;
            Greed = greed;
            Price = price;

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
        

    }
}
