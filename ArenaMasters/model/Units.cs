using ArenaMasters.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMasters
{
    class Units
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
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }
        public Units(string unitName)
        {
            UnitName = unitName;
        }
        public Units( List<Skills> skillsData)
        {
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
