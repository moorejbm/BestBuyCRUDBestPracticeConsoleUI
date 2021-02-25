using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    public class Product
    {
        // Add each colunm from products tabe as properties
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double PriceID { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }
    }
}
