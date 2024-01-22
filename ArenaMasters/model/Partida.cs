using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMasters.model
{
    internal class Partida
    {
        private int _id_game;
        private int _money;
        private int _round;
        private DateTime _lastPlay;

        public int IdGame
        {
            get { return _id_game; }
            set { _id_game = value; }
        }

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public int Round
        {
            get { return _round; }
            set { _round = value; }
        }

        public DateTime LastPlay
        {
            get { return _lastPlay; }
            set { _lastPlay = value; }
        }

        public Partida(int id_game, int money, int round, DateTime lastPlay)
        {
            IdGame = id_game;
            Money = money;
            Round = round;
            LastPlay = lastPlay;
        }
    }
}
