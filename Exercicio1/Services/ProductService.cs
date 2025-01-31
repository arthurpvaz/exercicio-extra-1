using System;
using System.Collections.Generic;
using Exercicio1.Entities;

namespace Exercicio1.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            if (products.Count > 0)
            {
                foreach (var item in products)
                {
                    if (item.Code == product.Code)
                    {
                        Console.WriteLine("Código já existe em outro produto! Tente adicionar novamente com um código diferente!");

                        return;
                    }
                }
            }

            products.Add(product);
            Console.WriteLine("Produto adicionado com sucesso!");
        }

        public void RemoveProduct(int productCode)
        {
            var product = products.Find(product => product.Code == productCode);

            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Não há produto com o código digitado!");
            }
        }

        public void UpdateStock(int productCode,  int newStock) {
            var product = products.Find(product => product.Code == productCode);

            if (product != null)
            {
                product.Stock = newStock;
            }
            else
            {
                Console.WriteLine("Não há produto com o código digitado!");
            }
        }

        public void ListProducts()
        {
            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Não existem produtos cadastrados!");
            }
        }
    }
}