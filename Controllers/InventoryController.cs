using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AceCareClinicSystem.Controllers
{
    public class InventoryController
    {
        private DbConnection db = new DbConnection();

        // ========== PAGINATION METHODS ==========

        public DataTable GetRecordsPaginated(string category, string search, int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;

            string query = @"SELECT Name, Quantity, WeeklyUsage, ExpiryDate 
                           FROM inventory 
                           WHERE Category = @cat";

            var param = new Dictionary<string, object> { { "@cat", category } };

            if (!string.IsNullOrEmpty(search))
            {
                query += " AND Name LIKE @search";
                param.Add("@search", "%" + search + "%");
            }

            query += " ORDER BY Name LIMIT @limit OFFSET @offset";
            param.Add("@limit", itemsPerPage);
            param.Add("@offset", offset);

            return db.ExecuteRead(query, param);
        }

        public int GetTotalCount(string category, string search)
        {
            string query = "SELECT COUNT(*) FROM inventory WHERE Category = @cat";
            var param = new Dictionary<string, object> { { "@cat", category } };

            if (!string.IsNullOrEmpty(search))
            {
                query += " AND Name LIKE @search";
                param.Add("@search", "%" + search + "%");
            }

            DataTable dt = db.ExecuteRead(query, param);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int GetTotalPages(string category, string search, int itemsPerPage)
        {
            int totalCount = GetTotalCount(category, search);
            return (int)Math.Ceiling((double)totalCount / itemsPerPage);
        }

        // ========== ORIGINAL METHODS (Keep for compatibility) ==========

        public DataTable GetRecords(string category, string search = "")
        {
            return GetRecordsPaginated(category, search, 1, 1000); // Return all for backward compatibility
        }

        // ========== CRUD OPERATIONS ==========

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
            return db.ExecuteWrite(query, param) > 0;
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
            return db.ExecuteWrite(query, param) > 0;
        }

        public bool DeleteItem(string name)
        {
            string query = "DELETE FROM inventory WHERE Name = @n";
            var param = new Dictionary<string, object> { { "@n", name } };
            return db.ExecuteWrite(query, param) > 0;
        }

        // ========== DASHBOARD STATS ==========

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