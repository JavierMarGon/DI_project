using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMasters.model
{
    public class Game
    {
        ArenaMastersManager manager = new ArenaMastersManager();
        public int IdGame { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }    
        public int Round { get; set; }
        public int Refresh { get; set; }
        public int Money { get; set; }

        public Game(int _idGame, int _idUser, string _name, int _round, int _money, int _refresh)
        {
            IdGame = _idGame;
            IdUser = _idUser;
            Name = _name;
            Round = _round;
            Refresh = _refresh;
            Money = _money;
        }

    }
}
