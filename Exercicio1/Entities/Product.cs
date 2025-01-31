using System;
using System.Globalization;

namespace Exercicio1.Entities
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }

        public Product(int code, string name, decimal price, int stock, Category category)
        {
            Code = code;
            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} ({Code}) | {Price.ToString("C", CultureInfo.CurrentCulture)} | Estoque: {Stock} un | Categoria: {Category}";
        }
    }
}
