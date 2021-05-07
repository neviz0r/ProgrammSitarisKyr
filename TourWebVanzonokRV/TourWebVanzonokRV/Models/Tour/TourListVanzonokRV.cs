using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TourWebVanzonokRV.Models
{
    public interface ItourListVanzonokRV
    {
        void Create(TourModelVanzonokRV tour);
        void Delete(int tourID);
        TourModelVanzonokRV Get(int tourID);
        List<TourModelVanzonokRV> GetTours();
        void Update(TourModelVanzonokRV tour);
    }

    public class TourListVanzonokRV : ItourListVanzonokRV
    {
        string connectionString = null;

        public TourListVanzonokRV(string conn)
        {
            connectionString = conn;
        }

        public void Create(TourModelVanzonokRV tour)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Tour (Title, TotalSum, Description, TransportID, CountryID) VALUES(@title, @totalSum, @description, @transportID, @countryID)";
                db.Execute(sqlQuery, tour);
            }
        }

        public void Delete(int tourID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Tour WHERE TourID = @tourID";
                db.Execute(sqlQuery, new { tourID });
            }
        }

        public TourModelVanzonokRV Get(int tourID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<TourModelVanzonokRV>("SELECT * FROM Tour WHERE TourID = @tourID", new { tourID }).FirstOrDefault();
            }
        }

        public List<TourModelVanzonokRV> GetTours()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<TourModelVanzonokRV>("SELECT * FROM Tour").ToList();
            }
        }

        public void Update(TourModelVanzonokRV tour)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Tour SET Title = @title, TotalSum = @totalSum, Description = @description, TransportID = @transportID, CountryID = @countryID WHERE TourID = @tourID";
                db.Execute(sqlQuery, tour);
            }
        }
    }
}
