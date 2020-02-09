using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Shop
{
    public static class Product
    {
        public static string name;
        public static int quantity;
        public static double price;
        public static string picture;
        public static Dictionary<int, int> quantityDict = new Dictionary<int, int>();
    }
}
