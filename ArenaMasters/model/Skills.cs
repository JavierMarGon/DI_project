using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMasters.model
{
    public class Skills
    {
        private int _id_skill;
        private string _name;
        private string _description;
        private string _skill_type;
        private int _tier;
        private bool _target_foe;
        private bool _multi_target;
        private string _multi_target_string;

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
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string SkillType
        {
            get { return _skill_type; }
            set { _skill_type = value; }
        }
        public int Tier
        {
            get { return _id_skill; }
            set { _id_skill = value; }
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
        public string MultiTargetString
        {
            get { return _multi_target_string; }
            set { _multi_target_string = value; }
        }

        public Skills(int idSkill, string name, string description, string skillType, int tier, bool targetFoe, bool multiTarget)
        {
            IdSkill = idSkill;
            Name = name;
            Description = description;
            SkillType = skillType;
            Tier = tier;
            TargetFoe = targetFoe;
            MultiTarget = multiTarget;
            MultiTargetString = multiTargeToString(multiTarget);
        }

        private string multiTargeToString(bool multiTarget)
        {
            return multiTarget ? "Multiple" : "Individual";
        }


    }
}
