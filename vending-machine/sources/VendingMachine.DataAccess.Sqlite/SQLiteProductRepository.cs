using Microsoft.Data.Sqlite;
using Nagarro.VendingMachine.Exceptions;
using Nagarro.VendingMachine.Models;
using System.Data;

namespace Nagarro.VendingMachine.DataAccess.Sqlite
{
    internal class SQLiteProductRepository : IProductRepository, IDisposable
    {
        private readonly SqliteConnection connection;

        public SQLiteProductRepository(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            connection = new SqliteConnection(connectionString);

            connection.Open();
        }

        public void DecrementStock(int id)
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                @"
                    UPDATE Products
                    SET Quantity = Quantity-1
                    WHERE Id = $id;
                 ";
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                @"
                    SELECT * FROM Products
                 ";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(ConvertDataRecordToProduct(reader));
                    }
                }
            }
            return products;
        }

        public Product GetById(int id)
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                @"
                    SELECT * FROM Products
                    WHERE id = $id
                 ";
                command.Parameters.AddWithValue("$id", id);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    if (!reader.HasRows)
                    {
                        return null;
                    }

                    return ConvertDataRecordToProduct(reader);
                }
            }
        }

        private static Product ConvertDataRecordToProduct(IDataRecord dataRecord)
        {
            return new Product { Id = Convert.ToInt32(dataRecord[0]), Name = (string)dataRecord[1], Price = Convert.ToDecimal(dataRecord[2]), Quantity = Convert.ToInt32(dataRecord[3]) };
        }

        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
        }
    }
}