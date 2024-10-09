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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите значения через пробел.");
                return;
            }

            int[] numbers;
            try
            {
                numbers = input.Split(' ')
                               .Select(int.Parse)
                               .ToArray();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные значения, разделённые пробелами.");
                return;
            }

            SortDelegate sortMethod = null;
            var selectedItem = SortMethodComboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                switch (selectedItem.Tag.ToString())
                {
                    case "BubbleSort":
                        sortMethod = Sorter.BubbleSort;
                        break;
                    case "QuickSort":
                        sortMethod = Sorter.QuickSort;
                        break;
                }
            }

            if (sortMethod != null)
            {
                var sortedNumbers = sortMethod(numbers);
                ResultTextBlock.Text = "Отсортированные числа: " + string.Join(", ", sortedNumbers);
            }
            else
            {
                MessageBox.Show("Выберите методы сортировки.");
            }
        }
    }
}
