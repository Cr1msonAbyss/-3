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
        private List<Item> items;

        public MainWindow()
        {
            InitializeComponent();
            LoadItems();
            UpdateItemList();
        }

        private void LoadItems()
        {
            items = new List<Item>
            {
                new Item { Name = "Item 1", Date = DateTime.Now.AddDays(-1) },
                new Item { Name = "Item 255", Date = DateTime.Now.AddDays(-6) },
                new Item { Name = "какой-то элемент", Date = DateTime.Now.AddDays(-3) },
                new Item { Name = "Item 4", Date = DateTime.Now.AddDays(-5) },
                new Item { Name = "Task", Date = DateTime.Now.AddDays(-4) },
                new Item { Name = "чиваува", Date = DateTime.Now.AddDays(-1) }
            };
        }

        private void UpdateItemList(List<Item> filteredItems = null)
        {
            ItemList.Items.Clear();
            var itemsToDisplay = filteredItems ?? items;
            foreach (var item in itemsToDisplay)
            {
                ItemList.Items.Add(item.Name);
            }
        }

        private void FilterSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = FilterSelector.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            switch (selectedItem.Tag.ToString())
            {
                case "все":
                    UpdateItemList();
                    KeywordTextBox.Visibility = Visibility.Collapsed;
                    break;
                case "недавние":
                    var recentFilter = new ItemFilter(item => item.Date >= DateTime.Now.AddDays(-2));
                    var recentItems = FilterManager.FilterItems(items, recentFilter);
                    UpdateItemList(recentItems);
                    KeywordTextBox.Visibility = Visibility.Collapsed;
                    break;
                case "ключевое слово":
                    KeywordTextBox.Visibility = Visibility.Visible;
                    KeywordTextBox.TextChanged -= KeywordTextBox_TextChanged; 
                    KeywordTextBox.TextChanged += KeywordTextBox_TextChanged; 
                    break;
            }
        }

        private void KeywordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = KeywordTextBox.Text.ToLower();
            var keywordFilter = new ItemFilter(item => item.Name.ToLower().Contains(keyword));
            var filteredItems = FilterManager.FilterItems(items, keywordFilter);
            UpdateItemList(filteredItems);
        }
    }
}
