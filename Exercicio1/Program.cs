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

                try
                {
                    Console.Write("Digite sua opção: ");
                    int option = int.Parse(Console.ReadLine());

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
                catch (FormatException)
                {
                    Console.WriteLine("O valor digitado deve ser um número inteiro!");
                    Console.ReadKey();
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
            int productCode = 000;
            string name = "";
            decimal price = 0;
            int stock = 0;
            Category category = 0;

            Console.WriteLine("Adicionando produto...");
            Console.WriteLine("Digite as informações do produto abaixo");

            bool codeIsValid = false;
            bool nameIsValid = false;
            bool priceIsValid = false;
            bool stockIsValid = false;
            bool categoryIsValid = false;

            do 
            {
                try
                {
                    Console.Write("Código: ");
                    productCode = int.Parse(Console.ReadLine());
                    codeIsValid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("O código deve ser digitado somente com números inteiros! Tente novamente.");
                }
            } while (!codeIsValid);

            do
            {
                Console.Write("Nome: ");
                name = Console.ReadLine();
                nameIsValid = true;

                if (name.Length < 2)
                {
                    Console.WriteLine("Nome deve conter 2 (dois) ou mais caracteres! Tente novamente.");
                    nameIsValid = false;
                }
            } while (!nameIsValid);

            do
            {
                try
                {
                    Console.Write("Preço: R$");
                    price = decimal.Parse(Console.ReadLine());
                    priceIsValid = true;

                    if (price <= 0)
                    {
                        Console.WriteLine("Inválido! Valor não pode ser menor ou igual a zero! Tente novamente.");
                        priceIsValid = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("O preço deve ser digitado com número real! Tente novamente.");
                }
            } while (!priceIsValid);

            do
            {
                try
                {
                    Console.Write("Quantidade em estoque: ");
                    stock = int.Parse(Console.ReadLine());
                    stockIsValid = true;

                    if (stock <= 0)
                    {
                        Console.WriteLine("Quantidade em estoque não pode ser menor que 1 (um)! Tente novamente.");
                        stockIsValid = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("A quantidade em estoque deve ser digitada com um número inteiro! Tente novamente.");
                }
            } while (!stockIsValid);

            do
            {
                try
                {
                    Console.WriteLine("Escolha a categoria:");
                    Console.WriteLine("1 - Alimentos");
                    Console.WriteLine("2 - Eletrônicos");
                    Console.WriteLine("3 - Vestuário");
                    Console.Write("Opção: ");
                    category = (Category)int.Parse(Console.ReadLine());
                    categoryIsValid = true;

                    if (category <= 0 || category > Category.Vestuario)
                    {
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        categoryIsValid = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valor digitado incorreto! Tente novamente.");
                }
            } while (!categoryIsValid);

            Product product = new Product(productCode, name, price, stock, category);

            productService.AddProduct(product);
        }

        static void callRemoveProduct()
        {
            Console.Write("Insira o código do produto que deseja remover: ");
            int productCode = int.Parse(Console.ReadLine());

            Console.WriteLine("Removendo produto...");

            productService.RemoveProduct(productCode);
        }

        static void callUpdateStock()
        {
            Console.Write("Digite o código do produto que deseja atualizar: ");
            int productCode = int.Parse(Console.ReadLine());

            Console.Write("Insira a quantidade para qual deseja atualizar: ");
            int newStock = int.Parse(Console.ReadLine());

            productService.UpdateStock(productCode, newStock);

            Console.WriteLine("Estoque do produto atualizado com sucesso!");
        }

        static void callListProduct()
        {
            Console.WriteLine("Listagem dos produtos cadastrados...");
            productService.ListProducts();
        }
    }
}