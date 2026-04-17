using System;  // ADD THIS LINE
using System.Data;
using System.Collections.Generic;

namespace AceCareClinicSystem.Controllers
{
    public class InventoryController
    {
        private DbConnection db = new DbConnection();

        public DataTable GetRecordsPaginated(string category, string search, int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;

            string query = @"SELECT ItemID, Name, Quantity, WeeklyUsage, ExpiryDate 
                           FROM inventory 
                           WHERE Category = @cat";

            var parameters = new Dictionary<string, object>
            {
                { "@cat", category }
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                query += " AND Name LIKE @search";
                parameters.Add("@search", "%" + search + "%");
            }

            query += " ORDER BY Name LIMIT @limit OFFSET @offset";
            parameters.Add("@limit", itemsPerPage);
            parameters.Add("@offset", offset);

            return db.ExecuteRead(query, parameters);
        }

        public bool UpdateFullItem(int id, string name, int qty, double usage, DateTime expiry)
        {
            string query = @"UPDATE inventory 
                           SET Name = @name, 
                               Quantity = @qty, 
                               WeeklyUsage = @usage, 
                               ExpiryDate = @expiry 
                           WHERE ItemID = @id";

            var parameters = new Dictionary<string, object>
            {
                { "@id", id },
                { "@name", name },
                { "@qty", qty },
                { "@usage", usage },
                { "@expiry", expiry }
            };

            int rowsAffected = db.ExecuteWrite(query, parameters);
            return rowsAffected > 0;
        }

        public (string med, string sup, string low, string exp) GetDashboardStats()
        {
            string query = @"SELECT 
                (SELECT IFNULL(SUM(Quantity), 0) FROM inventory WHERE Category = 'Medicine') as MedicineTotalQty,
                (SELECT IFNULL(SUM(Quantity), 0) FROM inventory WHERE Category = 'Supply') as SupplyTotalQty,
                (SELECT COUNT(*) FROM inventory WHERE Quantity < 10) as LowStockCount,
                (SELECT COUNT(*) FROM inventory WHERE ExpiryDate <= DATE_ADD(CURDATE(), INTERVAL 30 DAY)) as ExpiringCount";

            DataTable dt = db.ExecuteRead(query, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                System.Diagnostics.Debug.WriteLine($"Medicine Sum: {row["MedicineTotalQty"]}");
                System.Diagnostics.Debug.WriteLine($"Supply Sum: {row["SupplyTotalQty"]}");

                return (
                    row["MedicineTotalQty"].ToString(),
                    row["SupplyTotalQty"].ToString(),
                    row["LowStockCount"].ToString(),
                    row["ExpiringCount"].ToString()
                );
            }

            return ("0", "0", "0", "0");
        }

        public int GetTotalPages(string category, string search, int itemsPerPage)
        {
            string query = "SELECT COUNT(*) FROM inventory WHERE Category = @cat";
            var parameters = new Dictionary<string, object>
            {
                { "@cat", category }
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                query += " AND Name LIKE @search";
                parameters.Add("@search", "%" + search + "%");
            }

            DataTable dt = db.ExecuteRead(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                int totalRecords = Convert.ToInt32(dt.Rows[0][0]);
                return (int)Math.Ceiling((double)totalRecords / itemsPerPage);
            }

            return 1;
        }

        public bool AddItem(string name, int qty, string category, DateTime expiry)
        {
            string query = @"INSERT INTO inventory (Name, Quantity, Category, ExpiryDate, WeeklyUsage) 
                           VALUES (@name, @qty, @cat, @expiry, 0)";

            var parameters = new Dictionary<string, object>
            {
                { "@name", name },
                { "@qty", qty },
                { "@cat", category },
                { "@expiry", expiry }
            };

            int rowsAffected = db.ExecuteWrite(query, parameters);
            return rowsAffected > 0;
        }

        public bool DeleteItem(int id)
        {
            string query = "DELETE FROM inventory WHERE ItemID = @id";
            var parameters = new Dictionary<string, object>
            {
                { "@id", id }
            };

            int rowsAffected = db.ExecuteWrite(query, parameters);
            return rowsAffected > 0;
        }
    }
}