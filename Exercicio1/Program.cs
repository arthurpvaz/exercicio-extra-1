using System;
using System.Text;
using Exercicio1.Entities;
using Exercicio1.Services;

namespace Exercicio1
{
    class Program
    {
        static ProductService productService = new ProductService();
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                showMenu();


                int option = ReadPositiveInt("Digite sua opção: ");

                switch (option)
                {
                    case 1:
                        callAddProduct();
                        Console.ReadKey();
                        break;

                    case 2:
                        callRemoveProduct();
                        Console.ReadKey();
                        break;

                    case 3:
                        callUpdateStock();
                        Console.ReadKey();
                        break;

                    case 4:
                        callListProduct();
                        Console.ReadKey();
                        break;

                    case 5:
                        running = false;
                        Console.WriteLine("Programa finalizado!");
                        break;

                    default:
                        Console.WriteLine("Opção digitada inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void showMenu()
        {
            StringBuilder menu = new StringBuilder();

            menu.AppendLine("-----------------------");
            menu.AppendLine("Gerenciador de Produtos");
            menu.AppendLine("-----------------------");

            menu.AppendLine("");
            menu.AppendLine("Opções");
            menu.AppendLine("--------------------------------");
            menu.AppendLine("1 - Adicionar novo produto");
            menu.AppendLine("2 - Remover produto pelo código");
            menu.AppendLine("3 - Atualizar estoque do produto");
            menu.AppendLine("4 - Listar produtos cadastrados");
            menu.AppendLine("5 - Sair do programa");

            Console.WriteLine(menu);
        }

        static void callAddProduct()
        {
            Console.WriteLine("Adicionando produto...");
            Console.WriteLine("Digite as informações do produto abaixo");

            int productCode = ReadPositiveInt("Código: ");
            string name = ReadString("Nome: ");
            decimal price = ReadDecimal("Preço: ");
            int stock = ReadPositiveInt("Quantidade em estoque: ");
            Category category = ReadCategory();

            Product product = new Product(productCode, name, price, stock, category);

            productService.AddProduct(product);
        }

        static void callRemoveProduct()
        {
            int productCode = ReadPositiveInt("Insira o código do produto que deseja remover: ");

            Console.WriteLine("Removendo produto...");

            productService.RemoveProduct(productCode);
        }

        static void callUpdateStock()
        {
            int productCode = ReadPositiveInt("Digite o código do produto que deseja atualizar: ");

            int newStock = ReadInt("Insira a quantidade para qual deseja atualizar: ");

            productService.UpdateStock(productCode, newStock);

            Console.WriteLine("Estoque do produto atualizado com sucesso!");
        }

        static void callListProduct()
        {
            Console.WriteLine("Listagem dos produtos cadastrados...");
            productService.ListProducts();
        }

        static int ReadInt(string message)
        {
            int value;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("Entrada inválida! Digite um número inteiro.");
            }
        }

        static int ReadPositiveInt(string message)
        {
            int value;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Entrada inválida! Digite um número inteiro positivo.");
            }
        }

        static decimal ReadDecimal(string message)
        {
            decimal value;

            while (true)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Entrada inválida! Digite um número decimal maior que zero.");
            }
        }

        static string ReadString(string message, int minLength = 2)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine().Trim();

                if (input.Length >= minLength)
                {
                    return input;
                }

                Console.WriteLine($"Entrada inválida! O valor deve ter pelo menos {minLength} caracteres.");
            }
        }

        static Category ReadCategory()
        {
            while (true)
            {
                Console.WriteLine("Escolha a categoria:");
                Console.WriteLine("1 - Alimentos");
                Console.WriteLine("2 - Eletrônicos");
                Console.WriteLine("3 - Vestuário");
                Console.Write("Opção: ");
                Category value;

                if (Category.TryParse(Console.ReadLine(), out value) && value > 0 && value <= Category.Vestuario)
                {
                    return value;
                }

                Console.WriteLine("Entrada inválida! Digite um número correspondente a uma categoria.");
            }
        }
    }
}