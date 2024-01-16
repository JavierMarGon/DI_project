using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMasters.model
{
    internal class Game
    {
        ArenaMastersManager manager = new ArenaMastersManager();
        public string IdGame { get; set; }
        public string IdUser { get; set; }
        public int Round { get; set; }
        public string Refresh { get; set; }
        public string Money { get; set; }

    }
}
