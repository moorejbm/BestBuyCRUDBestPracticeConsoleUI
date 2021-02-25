using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.IO;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion
            IDbConnection conn = new MySqlConnection(connString);

            //Exercise 2
            IDbConnection connection = new MySqlConnection(connString);
            var repo = new DapperProductRepositor(connection);
            repo.CreateProduct("newStuff", 20, 1);

            // belongs to the instance of the DapperProductRepository class returns and IEnumerable of product
            var products = repo.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name}");
            }

            DapperDepartmentRepository reop = new DapperDepartmentRepository(conn);

            Console.WriteLine("Hello user, here are the current departments");
            Console.WriteLine("Please press enter...");
            Console.ReadLine();

            var depos = reop.GetAllDepartments();
            print(depos);
            

            Console.WriteLine("Do you want to add a department????");
            string userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new Department???");
                userResponse = Console.ReadLine();

                reop.InsertDepartment(userResponse);
                print(reop.GetAllDepartments());
            }

            Console.WriteLine("Have a great day.");
        }

        private static void print (IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
            }
        }
	}
    
    
}
