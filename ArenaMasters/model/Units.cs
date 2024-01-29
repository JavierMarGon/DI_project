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
        String _unitName = "";
        int _skill1 = 0;
        int _skill2 = 0;
        int _skill3 = 0;
        int _skill4 = 0;
        List<Skills> Skills { get; set; }
        public Units() {
            
        }
        public Units(String unitName)
        {
            _unitName = unitName;
        }
        public Units(String unitName, int skill1)
        {
            _unitName = unitName;
            _skill1 = skill1;
        }
        public Units(String unitName, int skill1, int skill2)
        {
            _unitName = unitName;
            _skill1 = skill1;
            _skill2 = skill2;  
        }
        public Units(String unitName, int skill1, int skill2, int skill3)
        {
            _unitName = unitName;
            _skill1 = skill1;
            _skill2 = skill2;
            _skill3 = skill3;
        }
        public Units(String unitName, int skill1, int skill2, int skill3, int skill4)
        {
            _unitName = unitName;
            _skill1 = skill1;
            _skill2 = skill2;
            _skill3 = skill3;
            _skill4 = skill4;
        }
        public void setName(string unitName)
        {
            _unitName = unitName;
            return;
        }
        public String getName()
        {
            return _unitName;
        }
        public void setSkill1(int skill)
        {
            _skill1 = skill;
            return;
        }
        public int getSkill1()
        {
            return _skill1;
        }
        public void setSkill2(int skill)
        {
            _skill2 = skill;
            return;
        }
        public int getSkill2()
        {
            return _skill2;
        }
        public void setSkill3(int skill)
        {
            _skill3 = skill;
            return;
        }
        public int getSkill3()
        {
            return _skill3;
        }
        public void setSkill4(int skill)
        {
            _skill4 = skill;
            return;
        }
        public int getSkill4()
        {
            return _skill4;
        }

    }
}
