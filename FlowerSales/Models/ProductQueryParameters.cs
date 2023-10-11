﻿namespace FlowerSales.Models
{
    public class ProductQueryParameters
    {

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
         
        public string Name { get; set; } = string.Empty;

        public string SearchTerm { get; set; } = string.Empty;
    }
}
