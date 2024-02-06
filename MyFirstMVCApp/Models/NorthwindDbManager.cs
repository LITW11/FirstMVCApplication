using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFirstMVCApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
    }

    public class NorthwindDbManager
    {
        private string _connectionString;

        public NorthwindDbManager(string connectionString)
        {
            _connectionString = connectionString;    
        }

        public List<Product> GetProducts()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products ORDER BY ProductId DESC";
            connection.Open();
            List<Product> products = new List<Product>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["ProductId"],
                    Name = (string)reader["ProductName"],
                    QuantityPerUnit = (string)reader["QuantityPerUnit"],
                    UnitPrice = (decimal)reader["UnitPrice"]
                });
            }

            return products;
        }

        public int GetCategoryCount()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Categories";
            connection.Open();
            return (int)cmd.ExecuteScalar();
        }
    }

    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public int CategoryCount { get; set; }
    }
}