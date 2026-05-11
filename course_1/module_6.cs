using System;
using System.Collections.Generic;

namespace Course1.Modules
{
    class Product
    {
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required int Stock { get; set; }
    }

    class ProductList
    {
        static List<Product> products = new List<Product>();

        // Rename Main to Run if you want to call it from Program.cs
        // Or keep it as Main if you plan to run this file specifically
        public static void Run()
        {
            string action = "";
            while (true)
            {
                Console.WriteLine("\nWhat action would you like to perform? (add/view/delete/update/exit)");
                action = (Console.ReadLine() ?? "").ToLower().Trim();

                if (action == "exit")
                {
                    Console.WriteLine("Exiting program...");
                    break; 
                }

                switch (action)
                {
                    case "add":
                        NewProduct();
                        break;
                    case "view":
                        ViewProducts();
                        break;
                    case "delete":
                        DeleteProduct();
                        break;
                    case "update":
                        UpdateStock();
                        break;
                    default:
                        Console.WriteLine("No valid action selected");
                        break;
                }
            }
        }

        static void UpdateStock()
        {
            Console.WriteLine("Name of the product you want to update?");
            string? searchName = Console.ReadLine();

            Product? findProduct = products.Find(p => p.Name == searchName);

            if (findProduct == null)
            {
                Console.WriteLine("Product not found");
                return;
            }

            Console.WriteLine("Found the item");
            int newStock = GetProductStock();

            findProduct.Stock = newStock;
            Console.WriteLine("Stock updated");
        }

        static void DeleteProduct()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            foreach (var prod in products)
            {
                Console.WriteLine($"Available: {prod.Name}");
            }

            Console.WriteLine("Which product would you like to delete?");
            string? target = Console.ReadLine();
            int removedCount = products.RemoveAll(p => p.Name == target);
            Console.WriteLine($"Deleted {target}, count: {removedCount}");
        }

        static void ViewProducts()
        {
            Console.WriteLine("--- Inventory View ---");
            if (products.Count == 0)
            {
                Console.WriteLine("No products in inventory");
                return;
            }

            foreach (var p in products)
            {
                Console.WriteLine($"Name: {p.Name} | Price: ${p.Price} | Stock: {p.Stock}");
            }
        }

        static void NewProduct()
        {
            string name = GetProductName();
            double price = GetProductPrice();
            int stock = GetProductStock();

            Product p = new Product
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            products.Add(p);
            Console.WriteLine("Product successfully added!");
        }

        static double GetProductPrice()
        {
            double price = 0;
            while (price <= 0)
            {
                Console.WriteLine("Price of the product?");
                if (double.TryParse(Console.ReadLine(), out double posPrice))
                {
                    price = posPrice;
                }
            }
            return price;
        }

        static int GetProductStock()
        {
            int stock = 0;
            while (stock <= 0)
            {
                Console.WriteLine("Stock of the product?");
                if (int.TryParse(Console.ReadLine(), out int posStock))
                {
                    stock = posStock;
                }
            }
            return stock;
        }

        static string GetProductName()
        {
            string? name = "";
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name of the product?");
                name = Console.ReadLine();
            }
            return name;
        }
    }
}