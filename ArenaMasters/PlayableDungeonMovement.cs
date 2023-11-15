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
        

        public PlayableDungeonMovement(double _marginTop, double _marginLeft)
        {
            
            marginLeft = _marginLeft;  
            marginTop = _marginTop;

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
    }
}
