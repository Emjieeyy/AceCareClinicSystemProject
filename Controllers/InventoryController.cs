using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AceCareClinicSystem.Controllers
{
    public class InventoryController
    {
        private DbConnection db = new DbConnection();

        // 1. Fetch records based on Category and Search text
        public DataTable GetRecords(string category, string search = "")
        {
            string query = "SELECT Name, Quantity, WeeklyUsage, ExpiryDate FROM inventory WHERE Category = @cat";
            var param = new Dictionary<string, object> { { "@cat", category } };

            if (!string.IsNullOrEmpty(search))
            {
                query += " AND Name LIKE @search";
                param.Add("@search", "%" + search + "%");
            }
            return db.ExecuteRead(query, param);
        }

        public bool UpdateFullItem(string oldName, string newName, int qty, double usage, DateTime expiry)
        {
            string query = "UPDATE inventory SET Name=@n, Quantity=@q, WeeklyUsage=@u, ExpiryDate=@e WHERE Name=@old";
            var param = new Dictionary<string, object> {
        { "@n", newName },
        { "@q", qty },
        { "@u", usage },
        { "@e", expiry },
        { "@old", oldName }
    };
            return db.ExecuteWrite(query, param);
        }

        public bool AddItem(string name, int qty, string cat, DateTime expiry)
        {
            string query = "INSERT INTO inventory (Name, Quantity, Category, ExpiryDate) VALUES (@n, @q, @c, @e)";
            var param = new Dictionary<string, object> {
        { "@n", name },
        { "@q", qty },
        { "@c", cat },
        { "@e", expiry }
    };
            return db.ExecuteWrite(query, param);
        }

        // 4. Delete item logic
        public bool DeleteItem(string name)
        {
            string query = "DELETE FROM inventory WHERE Name = @n";
            var param = new Dictionary<string, object> { { "@n", name } };
            return db.ExecuteWrite(query, param);
        }


        public (string med, string sup, string low, string exp) GetDashboardStats()
        {
            string query = @"SELECT 
                (SELECT COUNT(*) FROM inventory WHERE Category = 'Medicine') as M,
                (SELECT COUNT(*) FROM inventory WHERE Category = 'Supply') as S,
                (SELECT COUNT(*) FROM inventory WHERE Quantity < 10) as L,
                (SELECT COUNT(*) FROM inventory WHERE ExpiryDate <= DATE_ADD(CURDATE(), INTERVAL 30 DAY)) as E";

            DataTable dt = db.ExecuteRead(query);

            if (dt.Rows.Count > 0)
            {
                return (
                    dt.Rows[0]["M"].ToString(),
                    dt.Rows[0]["S"].ToString(),
                    dt.Rows[0]["L"].ToString(),
                    dt.Rows[0]["E"].ToString()
                );
            }
            return ("0", "0", "0", "0");
        }
    }
}