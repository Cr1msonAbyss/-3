using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Item
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
    public delegate bool ItemFilter(Item item);

    public class FilterManager
    {
        public static List<Item> FilterItems(List<Item> items, ItemFilter filter)
        {
            return items.Where(item => filter(item)).ToList();
        }
    }
}