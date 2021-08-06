using ProductCatalogDEMO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogDEMO.Services
{
    public class ProductsDAO : IProductDataService
    {
        //TO DO: add connection string to database
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(ProductModel product)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM dbo.Products Where Id=@Id";
            using SqlConnection conn = new(connStr);
            SqlCommand command = new(sqlStatement, conn);
            command.Parameters.AddWithValue("@Id", product.Id);

            try
            {
                conn.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return newIdNumber;
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new();

            string sqlStatement = "SELECT * FROM dbo.Products";
            using SqlConnection conn = new(connStr);
            SqlCommand command = new(sqlStatement, conn);

            try
            {

                conn.Open();

                //Get all data with a reader
                SqlDataReader rd = command.ExecuteReader();

                while (rd.Read())
                {
                    foundProducts.Add(new ProductModel { Id = (int)rd[0], Name = (string)rd[1], Price = (decimal)rd[2], Description = (string)rd[3] });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return foundProducts;

        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id=@Id";
            using SqlConnection conn = new(connStr);
            SqlCommand command = new(sqlStatement, conn);
            command.Parameters.AddWithValue("@Id", id);
            try
            {
                conn.Open();

                //Get all data with a reader
                SqlDataReader rd = command.ExecuteReader();

                while (rd.Read())
                {
                    foundProduct = new ProductModel { Id = (int)rd[0], Name = (string)rd[1], Price = (decimal)rd[2], Description = (string)rd[3] };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return foundProduct;

        }

        public int Insert(ProductModel product)
        {
            int newIdNumber = 1;

            string sqlStatement = "INSERT INTO dbo.Products (Name, Price, Description) VALUES (@Name, @Price, @Description)";
            using SqlConnection conn = new(connStr);
            SqlCommand command = new(sqlStatement, conn);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Id", product.Id);

            try
            {
                conn.Open();

                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return newIdNumber;
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new();

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";
            using SqlConnection conn = new(connStr);
            SqlCommand command = new(sqlStatement, conn);
            command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');
            try
            {
                conn.Open();

                //Get all data with a reader
                SqlDataReader rd = command.ExecuteReader();

                while (rd.Read())
                {
                    foundProducts.Add(new ProductModel { Id = (int)rd[0], Name = (string)rd[1], Price = (decimal)rd[2], Description = (string)rd[3] });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE dbo.Products SET Name=@Name, Price =@Price, Description=@Description WHERE Id=@Id";
            using SqlConnection conn = new(connStr);
            SqlCommand command = new(sqlStatement, conn);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Id", product.Id);

            try
            {
                conn.Open();

                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return newIdNumber;
        }
    }
}
