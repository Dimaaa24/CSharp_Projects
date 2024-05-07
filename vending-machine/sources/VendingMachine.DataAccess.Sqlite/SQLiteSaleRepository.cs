using Microsoft.Data.Sqlite;
using Nagarro.VendingMachine.DataAccess;
using System.Data;
using VendingMachine.Business.Models;
using VendingMachine.Business.SerializedObjects;

namespace VendingMachine.DataAccess.Sqlite
{
    internal class SQLiteSaleRepository : ISaleRepository, IDisposable
    {
        private readonly SqliteConnection connection;

        public SQLiteSaleRepository(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            connection = new SqliteConnection(connectionString);

            connection.Open();
        }

        public void CreateNewSale(Sale sale)
        {
            string Name = sale.ProductName;
            string paymentMethod = sale.PaymentType;
            decimal price = sale.Price;
            string date = sale.Date.ToString("yyyy-MM-dd HH:mm:ss");

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                @"
                    INSERT INTO Sales VALUES ($Name,$price,$paymentMethod,$date)
                 ";
                command.Parameters.AddWithValue("$Name", Name);
                command.Parameters.AddWithValue("$price", price);
                command.Parameters.AddWithValue("$paymentMethod", paymentMethod);
                command.Parameters.AddWithValue("$date", date);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Sale> GetAllInAPeriod(DateTime startDate, DateTime endDate)
        {
            string startDateString = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            string endDateString = endDate.ToString("yyyy-MM-dd HH:mm:ss");
            List<Sale> sales = new List<Sale>();
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                @"
                    SELECT * FROM Sales
                    WHERE Date >= $startDateString AND Date <= $endDateString
                 ";
                command.Parameters.AddWithValue("$startDateString", startDateString);
                command.Parameters.AddWithValue("$endDateString", endDateString);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sales.Add(ConvertDataRecordToSale(reader));
                    }
                }
            }
            return sales;
        }

        public List<ProductQuantity> GetVolumeInAPeriod(DateTime startDate, DateTime endDate)
        {
            string startDateString = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            string endDateString = endDate.ToString("yyyy-MM-dd HH:mm:ss");
            List<ProductQuantity> volume = new List<ProductQuantity>();
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                @"
                    SELECT ProductName, COUNT(*) AS totalSales
                    FROM Sales
                    WHERE Date >= $startDate AND Date <= $endDate
                    GROUP BY ProductName
                 ";
                command.Parameters.AddWithValue("$startDate", startDateString);
                command.Parameters.AddWithValue("$endDate", endDateString);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        volume.Add(new ProductQuantity { Name = reader.GetString(0), Quantity = reader.GetInt32(1)});
                    }
                }
            }
            return volume;
        }

        private static Sale ConvertDataRecordToSale(IDataRecord dataRecord)
        {
            return new Sale { ProductName = (string)dataRecord[0], Price = Convert.ToDecimal(dataRecord[1]), PaymentType = (string)dataRecord[2], Date = Convert.ToDateTime(dataRecord[3]) };
        }

        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
        }
    }
}
