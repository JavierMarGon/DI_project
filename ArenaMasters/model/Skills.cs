using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMasters.model
{
    class Skills
    {
        private int _id_skill;
        private string _name;
        private string _skill_type;
        private string _description;
        private bool _target_foe;
        private bool _multi_target;

        public int IdSkill
        {
            get { return _id_skill; }
            set { _id_skill = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string SkillType
        {
            get { return _skill_type; }
            set { _skill_type = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool TargetFoe
        {
            get { return _target_foe; }
            set { _target_foe = value; }
        }

        public bool MultiTarget
        {
            get { return _multi_target; }
            set { _multi_target = value; }
        }
    }
}
