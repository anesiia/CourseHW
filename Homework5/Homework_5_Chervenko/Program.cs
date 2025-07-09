using Homework_5_Chervenko.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Homework_5_Chervenko
{
    public class Program
    {
        static void Main(string[] args)
        {
            // я не була впевнена як краще це продемонструвати,
            // тому зробила все окремими методами

            ReadOrdersWithReader();
            ReadOrdersWithDataSet();
            ReadOrdersWithEF();

            CreateOrderWithCommand();
            UpdateOrderWithCommand();
            DeleteOrderWithCommand();

            CreateOrderWithEF();
            UpdateOrderWithEF();
            DeleteOrderWithEF();

        }
        private static SqlConnection GetOpenConnection()
        {
            var connectionString = "Server=ANESIA;Database=LabolatoryDB;Trusted_Connection=True;TrustServerCertificate=True;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // Метод виводу усіх замовлень за рік з використанням SqlCommand SqlDataReader
        public static void ReadOrdersWithReader()
        {
            using var connection = GetOpenConnection();

            var command = new SqlCommand("SELECT * FROM Orders WHERE ord_datetime >= DATEADD(YEAR, -1, GETDATE())", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["ord_id"]}, Date: {reader["ord_datetime"]}, Analysis: {reader["ord_an"]} (SqlDataReader)");
            }
        }

        //  Метод виводу усіх замовлень за рік з використанням SqlDataAdapter, DataSet
        public static void ReadOrdersWithDataSet()
        {
            using var connection = GetOpenConnection();

            var adapter = new SqlDataAdapter("SELECT * FROM Orders WHERE ord_datetime >= DATEADD(YEAR, -1, GETDATE())", connection);
            var ds = new DataSet();
            adapter.Fill(ds, "Orders");

            foreach (DataRow row in ds.Tables["Orders"].Rows)
            {
                Console.WriteLine($"ID: {row["ord_id"]}, Date: {row["ord_datetime"]}, Analysis: {row["ord_an"]} (DataSet)");
            }
        }

        //  Метод виводу усіх замовлень за рік з використанням EF Core
        public static void ReadOrdersWithEF()
        {
            using var context = new MyDbContext();
            var orders = context.Orders
                .Where(o => o.ord_datetime >= DateTime.Now.AddYears(-1))
                .ToList();

            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.ord_id}, Date: {order.ord_datetime}, Analysis: {order.ord_an} (EF Core)");
            }
        }

        // Створення, оновлення, видалення записів у таблиці Orders з SqlCommand
        public static void CreateOrderWithCommand()
        {
            using var connection = GetOpenConnection();

            var command = new SqlCommand("INSERT INTO Orders (ord_datetime, ord_an) VALUES (@date, @an)", connection);
            command.Parameters.AddWithValue("@date", DateTime.Now);
            command.Parameters.AddWithValue("@an", 1); // айді аналізу для замовлення

            int rows = command.ExecuteNonQuery();
        }

        public static void UpdateOrderWithCommand()
        {
            using var connection = GetOpenConnection();

            var command = new SqlCommand("UPDATE Orders SET ord_an = @newAn WHERE ord_id = @id", connection);
            command.Parameters.AddWithValue("@newAn", 2); // передаємо айді іншого аналізу
            command.Parameters.AddWithValue("@id", 1);    // айді замовлення яке треба змінити

            int rows = command.ExecuteNonQuery();
        }

        public static void DeleteOrderWithCommand()
        {
            using var connection = GetOpenConnection();

            var command = new SqlCommand("DELETE FROM Orders WHERE ord_id = @id", connection);
            command.Parameters.AddWithValue("@id", 14); // айді того замовлення, яке хочемо видалити

            int rows = command.ExecuteNonQuery();
        }

        // з EF Core
        public static void CreateOrderWithEF()
        {
            using var context = new MyDbContext();
            var newOrder = new Order
            {
                ord_datetime = DateTime.Now,
                ord_an = 1
            };
            context.Orders.Add(newOrder);
            context.SaveChanges();
        }

        public static void UpdateOrderWithEF()
        {
            using var context = new MyDbContext();
            var order = context.Orders.FirstOrDefault(o => o.ord_id == 1);
            if (order != null)
            {
                order.ord_an = 2;
                context.SaveChanges();
            }
        }

        public static void DeleteOrderWithEF()
        {
            using var context = new MyDbContext();
            var order = context.Orders.FirstOrDefault(o => o.ord_id == 1);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }
    }
}