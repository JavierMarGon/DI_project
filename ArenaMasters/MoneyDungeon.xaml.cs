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
    /// Lógica de interacción para MoneyDungeon.xaml
    /// </summary>
    public partial class MoneyDungeon : Window
    {
        int lv;
        int profit;
        public MoneyDungeon(int level, int rewards)
        {
            InitializeComponent();
            lv = level;
            profit = rewards;
        }
    }
}
