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
            for (int i = 0; i < _numberOfDays.Length; i++)
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check die controleert of beide comboboxen een item hebben geselecteerd
            // SelectedIndex (zie docs) (of SelectedItem (zie docs))
            if (typeWoningComboBox.SelectedIndex != -1 && aantalDagenComboBox.SelectedIndex != -1)
            {
                double price = 1;
                double aantalDagen = 0;

                // op basis van SelectedIndex (of SelectedItem) 
                // afleiden wat de prijs is van de accomodatie
                // vergeet niet te converteren van string naar double
                ComboBoxItem geselecteerdAantalDagenComboBoxItem = (ComboBoxItem)aantalDagenComboBox.SelectedItem;
                // of
                geselecteerdAantalDagenComboBoxItem = aantalDagenComboBox.SelectedItem as ComboBoxItem;

                string inhoudVanGeselecteerdAantalDagenComboBoxItem = geselecteerdAantalDagenComboBoxItem.Content.ToString();
                aantalDagen = Convert.ToDouble(inhoudVanGeselecteerdAantalDagenComboBoxItem);
                price = 1;

                // Gebruik SelectedIndex
                int indexGeselecteerdItemVanDeTypeWoning = typeWoningComboBox.SelectedIndex;
                ComboBoxItem selectedWoningType = (ComboBoxItem)typeWoningComboBox.Items[indexGeselecteerdItemVanDeTypeWoning];
                string benamingVanTypeWoning = selectedWoningType.Content.ToString();

                for (int i = 0; i < _houseWithPrice.GetLength(0); i++)
                {
                    if (_houseWithPrice[i, 0].Equals(benamingVanTypeWoning))
                    {
                        price = Convert.ToDouble(_houseWithPrice[i, 1]);
                    }
                }

                // Of 
                price = Convert.ToDouble(_houseWithPrice[typeWoningComboBox.SelectedIndex, 1]);

                double result = price * aantalDagen;

                prijsTextBox.Text = result.ToString("c");

            }
        }
    }
}