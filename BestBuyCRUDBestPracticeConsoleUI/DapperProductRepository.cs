using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    public class DapperProductRepositor : IProductRepository
    {
        //Constructor 10-13
        private readonly IDbConnection _connection;

        public DapperProductRepositor(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@productName, @price, @categoryID);",
                new { productName = name, price = price, categoryID = categoryID });
        }

        public void UpdateProductName(int productID, string updateName)
        {

            _connection.Execute("UPDATE products SET name = @updatedName WHERE ProductID = @productID;",
                new { updateName = updateName, productID = productID });
        }

        //Delete data **Bonus**
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = productID;",
               new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = productID;",
               new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = productID;",
               new { productID = productID });

        }

        //methods that I define here statis belong to the instance
        public IEnumerable<Product> GetAllProducts()
        {
            //dapper starts here
            //dapper extends ==> IDbConnection 
            return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        



    }

}
  
            


           
    










  
    

