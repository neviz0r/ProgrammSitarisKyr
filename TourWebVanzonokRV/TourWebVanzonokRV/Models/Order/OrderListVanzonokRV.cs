using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TourWebVanzonokRV.Models
{
    public interface IorderListVanzonokRV
    {
        void CreateO(OrderModelVanzonokRV order);
        void DeleteO(int orderID);
        OrderModelVanzonokRV Get(int orderID);
        List<OrderModelVanzonokRV> GetOrders();
        void UpdateO(OrderModelVanzonokRV order);
    }

    public class OrderListVanzonokRV : IorderListVanzonokRV
    {
        string connectionString = null;

        public OrderListVanzonokRV(string conn)
        {
            connectionString = conn;
        }

        public void CreateO(OrderModelVanzonokRV order)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO [Vanzonok_R_V].[dbo].[Order] (Status, UserName, UserLastName, TourID, Telephone, Email) VALUES(@status, @userName, @userLastName, @tourID, @telephone, @email)";
                db.Execute(sqlQuery, order);
            }
        }

        public void DeleteO(int orderID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM [Vanzonok_R_V].[dbo].[Order] WHERE OrderID = @orderID";
                db.Execute(sqlQuery, new { orderID });
            }
        }

        public OrderModelVanzonokRV Get(int orderID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<OrderModelVanzonokRV>("SELECT * FROM [Vanzonok_R_V].[dbo].[Order] WHERE OrderID = @orderID", new { orderID }).FirstOrDefault();
            }
        }

        public List<OrderModelVanzonokRV> GetOrders()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<OrderModelVanzonokRV>("SELECT OrderID, Status, [Vanzonok_R_V].[dbo].[Order].TourID, UserName, UserLastName, Telephone, Email, Title, TotalSum FROM [Vanzonok_R_V].[dbo].[Order] INNER JOIN [Vanzonok_R_V].[dbo].[Tour] ON [Vanzonok_R_V].[dbo].[Order].TourID = [Vanzonok_R_V].[dbo].[Tour].TourID").ToList();
            }
        }

        public void UpdateO(OrderModelVanzonokRV order)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE [Vanzonok_R_V].[dbo].[Order] SET Status = @status, TourID = @tourID WHERE OrderID = @orderID";
                db.Execute(sqlQuery, order);
            }
        }
    }
}
