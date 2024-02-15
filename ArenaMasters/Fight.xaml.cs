using ArenaMasters.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ArenaMasters
{
    /// <summary>
    /// Lógica de interacción para Fight.xaml
    /// </summary>
    public partial class Fight : Window
    {
        Game _game;
        public Fight(int lvl, Game game)
        {
            GenerarPantalla(lvl);
            _game = game;
            InitializeComponent();
        }


        private void GenerarPantalla(int lvl)
        {
            switch(lvl)
            {
                case 1:
                    this.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/images/MapPhase1.jpg")));
                    break;
                case 2:
                    this.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/images/MapPhase2.jpg")));
                    break;
            }
        }


    }
}
