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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oefening1CenterParcs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string[,] _houseWithPrice = new string[5, 2] {
        { "2 personen", "80" },
        { "4 personen", "120" } ,
        { "4 personen lux", "140" } ,
        { "6 personen", "180" },
        { "8 personen", "200"}};

        private readonly int[] _numberOfDays = new int[] { 1, 2, 5, 7, 8, 12, 14, 21 };

        public MainWindow()
        {
            InitializeComponent();
            // Wanneer het venster wordt aangemaakt.
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Wanneer het venster reeds is aangemaakt en getoond wordt.

            // 1d array inladen in ComboBoxItems
            for (int i = 0; i <  _numberOfDays.Length; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = _numberOfDays[i];
                aantalDagenComboBox.Items.Add(item);
            }

            // 2d array inladen in ComboBoxItems
            for (int i = 0; i < _houseWithPrice.GetLength(0); i++)
            {
                string houseToAddToComboBox = _houseWithPrice[i, 0];
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = houseToAddToComboBox;
                typeWoningComboBox.Items.Add(newItem);
            }
        }
    }
}
