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

        protected List<Skills> _skills;

        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }
        public Units(string unitName)
        {
            UnitName = unitName;
        }
        public Units(string unitName, List<Skills> skillsData)
        {
            UnitName = unitName;
            foreach (Skills skill in skillsData)
            {
                _skills.Add(skill);
            }
        }
        public void setSkillByIndex(int index, Skills data)
        {
            _skills[index] = data;
            return;
        }
        public Skills getSkillByIndex(int index)
        {
            return _skills[index];
        }
        

    }
}
