using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ArenaMasters
{
    internal class PlayableDungeonMovement
    {
        private double marginTop;
        private double marginBottom;
        private double marginLeft;
        private double marginRight;
        

        public PlayableDungeonMovement(int lvl)
        {

            InitializeParametersForLevel(lvl);

        }

        public double MarginTop
        {
            get { return marginTop; }
            set { marginTop = value; }
        }

        public double MarginBottom
        {
            get { return marginBottom; }
            set { marginBottom = value; }
        }


        public double MarginLeft
        {
            get { return marginLeft; }
            set { marginLeft = value; }
        }

        public double MarginRight
        {
            get { return marginRight; }
            set { marginRight = value; }
        }

        private void InitializeParametersForLevel(int level)
        {
            switch (level)
            {
                case 1:
                    marginLeft = 94;
                    marginTop = 364;
                    break;
                case 2:
                    marginLeft = 1189;
                    marginTop = 95;
                    break;
                case 3:
                    marginLeft = 166;
                    marginTop = 108;
                    break;
                case 4:
                    marginLeft = 1168;
                    marginTop = 465;
                    break;
                case 5:
                    marginLeft = 1197;
                    marginTop = 465;
                    break;
                case 6:
                    marginLeft = 112;
                    marginTop = 357;
                    break;
            }
        }
    }
}
