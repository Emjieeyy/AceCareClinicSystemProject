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

            string query = @"SELECT ItemID, Name, BatchNumber, Quantity, WeeklyUsage, ExpiryDate 
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

        public bool UpdateFullItem(int id, string name, string batch, int qty, double usage, DateTime expiry)
        {
            string query = @"UPDATE inventory 
                           SET Name = @name, 
                               BatchNumber = @batch,
                               Quantity = @qty, 
                               WeeklyUsage = @usage, 
                               ExpiryDate = @expiry 
                           WHERE ItemID = @id";

            var parameters = new Dictionary<string, object>
            {
                { "@id", id },
                { "@name", name },
                { "@batch", batch },
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

        public bool AddItem(string name, string batch, int qty, string category, DateTime expiry)
        {
            string query = @"INSERT INTO inventory (Name, BatchNumber, Quantity, Category, ExpiryDate, WeeklyUsage) 
                           VALUES (@name, @batch, @qty, @cat, @expiry, 0)";

            var parameters = new Dictionary<string, object>
            {
                { "@name", name },
                { "@batch", batch },
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

        public int GetTotalStock(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName)) return 0;
            string query = "SELECT IFNULL(SUM(Quantity), 0) FROM inventory WHERE Name = @name";
            var parameters = new Dictionary<string, object> { { "@name", itemName } };
            DataTable dt = db.ExecuteRead(query, parameters);
            return dt != null && dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        public bool DeductInventory(string itemName, int quantity)
        {
            if (string.IsNullOrWhiteSpace(itemName) || quantity <= 0) return false;

            // Check total availability first
            if (GetTotalStock(itemName) < quantity) return false;

            // FEFO Logic: Get all batches for this item, ordered by expiry date
            string selectQuery = "SELECT ItemID, Quantity FROM inventory WHERE Name = @name AND Quantity > 0 ORDER BY ExpiryDate ASC";
            var selectParams = new Dictionary<string, object> { { "@name", itemName } };
            DataTable batches = db.ExecuteRead(selectQuery, selectParams);

            if (batches == null || batches.Rows.Count == 0) return false;

            int remainingToDeduct = quantity;
            int totalDeducted = 0;

            foreach (DataRow batch in batches.Rows)
            {
                int batchId = Convert.ToInt32(batch["ItemID"]);
                int batchQty = Convert.ToInt32(batch["Quantity"]);

                int deductFromThisBatch = Math.Min(batchQty, remainingToDeduct);

                string updateQuery = "UPDATE inventory SET Quantity = Quantity - @qty WHERE ItemID = @id";
                var updateParams = new Dictionary<string, object> {
                    { "@id", batchId },
                    { "@qty", deductFromThisBatch }
                };
                db.ExecuteWrite(updateQuery, updateParams);

                remainingToDeduct -= deductFromThisBatch;
                totalDeducted += deductFromThisBatch;

                if (remainingToDeduct <= 0) break;
            }

            return totalDeducted > 0;
        }
    
        public DataTable GetInventoryReport(DateTime? fromDate = null, DateTime? toDate = null, string search = "")
        {
            string query = @"SELECT 
        DATE_FORMAT(ExpiryDate, '%d-%b-%y') AS LastVisit,
        COALESCE(BatchNumber, CONCAT('ITEM-', ItemID)) AS IDNumber,
        Name AS PatientName,
        Category AS PatientType,
        CONCAT('Batch: ', COALESCE(BatchNumber, 'N/A'), ' - Stock: ', Quantity, ' units') AS Description,
        CONCAT(Quantity, ' (', WeeklyUsage, '/week)') AS QtyDosage,
        'Inventory System' AS Personnel
        FROM inventory 
        WHERE 1=1";

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query += " AND Name LIKE @search";
                parameters.Add("@search", "%" + search + "%");
            }

            if (fromDate.HasValue && toDate.HasValue)
            {
                query += " AND ExpiryDate >= @from AND ExpiryDate <= @to";
                parameters.Add("@from", fromDate.Value.Date);
                parameters.Add("@to", toDate.Value.Date.AddDays(1).AddTicks(-1));
            }

            query += " ORDER BY ExpiryDate DESC";

            return db.ExecuteRead(query, parameters);
        }
    }
}