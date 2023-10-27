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
        public Units() {
            
        }
        public Units(String unitName)
        {
            _unitName = unitName;
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
    }
}
