using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMasters.model
{
    public class Status
    {
        private bool _Atk =false;
        private bool _Def =false;
        private bool _HitEva =false;
        private bool _Aggro =false;
        private int _AtkTimer =0;
        private int _DefTimer =0;
        private int _HitEvaTimer =0;
        public bool Atk {
            set { _Atk = value;
                if (value) {
                    _AtkTimer=3;
                }
            }
            get { return _Atk; } 
        }
        public bool Def {
            set { _Def = value;
                if (value)
                {
                    _DefTimer=3;
                }
            }
            get { return _Def; } 
        }
        public bool HitEva {
            set { _HitEva = value;
                if (value)
                {
                    _HitEvaTimer=3;
                }
            }
            get { return _HitEva; } 
        }
        public bool Aggro {
            set { _Aggro = value; }
            get { return _Aggro; } 
        }
        public void ReduceTimer ()
        {
            if (_AtkTimer>0)
            {
                _AtkTimer--;
            }
            if (_DefTimer>0)
            {
                _DefTimer--;
            }
            if (_HitEvaTimer>0)
            {
                _HitEvaTimer--;
            }
            if (Aggro)
            {
                Aggro=false;
            }
        }

    }
}
