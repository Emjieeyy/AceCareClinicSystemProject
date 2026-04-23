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

            string query = @"SELECT 
                                i.ItemID, 
                                i.Name, 
                                COALESCE(b.batch_no, '') AS BatchNumber, 
                                COALESCE(b.quantity, i.Quantity) AS Quantity, 
                                i.WeeklyUsage, 
                                COALESCE(b.expiry_date, i.ExpiryDate) AS ExpiryDate 
                           FROM inventory i
                           LEFT JOIN inventory_batches b ON i.ItemID = b.item_id
                           WHERE i.Category = @cat";

            var parameters = new Dictionary<string, object>
            {
                { "@cat", category }
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                query += " AND i.Name LIKE @search";
                parameters.Add("@search", "%" + search + "%");
            }

            query += " ORDER BY i.Name LIMIT @limit OFFSET @offset";
            parameters.Add("@limit", itemsPerPage);
            parameters.Add("@offset", offset);

            return db.ExecuteRead(query, parameters);
        }

        public bool UpdateFullItem(int id, string name, string batch, int qty, double usage, DateTime expiry)
        {
            // 1. Update main inventory table
            string invQuery = @"UPDATE inventory 
                           SET Name = @name, 
                               WeeklyUsage = @usage 
                           WHERE ItemID = @id";

            var invParams = new Dictionary<string, object>
            {
                { "@id", id },
                { "@name", name },
                { "@usage", usage }
            };
            db.ExecuteWrite(invQuery, invParams);

            // 2. Update or Insert Batch record if batch string is provided
            if (!string.IsNullOrWhiteSpace(batch))
            {
                string batchQuery = @"INSERT INTO inventory_batches (item_id, batch_no, quantity, expiry_date)
                                      VALUES (@id, @batch, @qty, @expiry)
                                      ON DUPLICATE KEY UPDATE quantity = @qty, expiry_date = @expiry";
                
                var batchParams = new Dictionary<string, object>
                {
                    { "@id", id },
                    { "@batch", batch },
                    { "@qty", qty },
                    { "@expiry", expiry }
                };
                db.ExecuteWrite(batchQuery, batchParams);
            }
            else
            {
                // If they edit the root item without a batch, update the root quantity and expiry
                string baseQuery = "UPDATE inventory SET Quantity = @qty, ExpiryDate = @expiry WHERE ItemID = @id";
                var baseParams = new Dictionary<string, object> { { "@id", id }, { "@qty", qty }, { "@expiry", expiry } };
                db.ExecuteWrite(baseQuery, baseParams);
            }

            // Sync total quantity in base inventory
            SyncInventoryTotal(id);
            return true;
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
            string query = @"SELECT COUNT(*) FROM (
                                SELECT i.ItemID FROM inventory i
                                LEFT JOIN inventory_batches b ON i.ItemID = b.item_id
                                WHERE i.Category = @cat";

            var parameters = new Dictionary<string, object>
            {
                { "@cat", category }
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                query += " AND i.Name LIKE @search";
                parameters.Add("@search", "%" + search + "%");
            }

            query += ") AS result";

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
            // First check if an item with this name already exists in inventory
            string checkQuery = "SELECT ItemID FROM inventory WHERE Name = @name LIMIT 1";
            var checkParams = new Dictionary<string, object> { { "@name", name } };
            DataTable dt = db.ExecuteRead(checkQuery, checkParams);

            int itemId;

            if (dt != null && dt.Rows.Count > 0)
            {
                itemId = Convert.ToInt32(dt.Rows[0]["ItemID"]);
            }
            else
            {
                // Insert new inventory item
                string invQuery = @"INSERT INTO inventory (Name, Quantity, Category, ExpiryDate, WeeklyUsage) 
                                   VALUES (@name, @qty, @cat, @expiry, 0)";
                var invParams = new Dictionary<string, object>
                {
                    { "@name", name },
                    { "@qty", qty },
                    { "@cat", category },
                    { "@expiry", expiry }
                };
                db.ExecuteWrite(invQuery, invParams);

                // Get new ItemID
                DataTable idDt = db.ExecuteRead("SELECT LAST_INSERT_ID()", null);
                itemId = Convert.ToInt32(idDt.Rows[0][0]);
            }

            // Insert into batches if batch is provided
            if (!string.IsNullOrWhiteSpace(batch))
            {
                string batchQuery = @"INSERT INTO inventory_batches (item_id, batch_no, quantity, expiry_date)
                                      VALUES (@id, @batch, @qty, @expiry)
                                      ON DUPLICATE KEY UPDATE quantity = quantity + @qty, expiry_date = @expiry";
                
                var batchParams = new Dictionary<string, object>
                {
                    { "@id", itemId },
                    { "@batch", batch },
                    { "@qty", qty },
                    { "@expiry", expiry }
                };
                db.ExecuteWrite(batchQuery, batchParams);
            }
            else
            {
                 // Update the total quantity explicitly if no batch
                 string updateQuery = "UPDATE inventory SET Quantity = Quantity + @qty WHERE ItemID = @id";
                 var updateParams = new Dictionary<string, object> { { "@id", itemId }, { "@qty", qty } };
                 db.ExecuteWrite(updateQuery, updateParams);
            }

            SyncInventoryTotal(itemId);
            return true;
        }

        public bool DeleteItem(int id)
        {
            // Delete batches related to this item
            db.ExecuteWrite("DELETE FROM inventory_batches WHERE item_id = @id", new Dictionary<string, object> { { "@id", id } });
            
            string query = "DELETE FROM inventory WHERE ItemID = @id";
            var parameters = new Dictionary<string, object> { { "@id", id } };
            int rowsAffected = db.ExecuteWrite(query, parameters);
            return rowsAffected > 0;
        }

        public int GetTotalStock(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName)) return 0;
            string query = "SELECT IFNULL(Quantity, 0) FROM inventory WHERE Name = @name";
            var parameters = new Dictionary<string, object> { { "@name", itemName } };
            DataTable dt = db.ExecuteRead(query, parameters);
            return dt != null && dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        private void SyncInventoryTotal(int itemId)
        {
            string query = @"
                UPDATE inventory i 
                SET Quantity = COALESCE((SELECT SUM(quantity) FROM inventory_batches WHERE item_id = @id), Quantity) 
                WHERE ItemID = @id";
            db.ExecuteWrite(query, new Dictionary<string, object> { { "@id", itemId } });
        }

        public bool DeductInventory(string itemName, int quantity)
        {
            if (string.IsNullOrWhiteSpace(itemName) || quantity <= 0) return false;

            // Check total availability first
            if (GetTotalStock(itemName) < quantity) return false;

            // Get Item ID
            string idQuery = "SELECT ItemID FROM inventory WHERE Name = @name LIMIT 1";
            var idParams = new Dictionary<string, object> { { "@name", itemName } };
            DataTable idDt = db.ExecuteRead(idQuery, idParams);
            if (idDt == null || idDt.Rows.Count == 0) return false;
            int itemId = Convert.ToInt32(idDt.Rows[0]["ItemID"]);

            // FEFO Logic: Get all batches for this item from inventory_batches
            string selectQuery = "SELECT batch_id, quantity FROM inventory_batches WHERE item_id = @id AND quantity > 0 ORDER BY expiry_date ASC";
            var selectParams = new Dictionary<string, object> { { "@id", itemId } };
            DataTable batches = db.ExecuteRead(selectQuery, selectParams);

            int remainingToDeduct = quantity;
            int totalDeducted = 0;

            if (batches != null && batches.Rows.Count > 0)
            {
                foreach (DataRow batch in batches.Rows)
                {
                    int batchId = Convert.ToInt32(batch["batch_id"]);
                    int batchQty = Convert.ToInt32(batch["quantity"]);

                    int deductFromThisBatch = Math.Min(batchQty, remainingToDeduct);

                    string updateQuery = "UPDATE inventory_batches SET quantity = quantity - @qty WHERE batch_id = @id";
                    var updateParams = new Dictionary<string, object> {
                        { "@id", batchId },
                        { "@qty", deductFromThisBatch }
                    };
                    db.ExecuteWrite(updateQuery, updateParams);

                    remainingToDeduct -= deductFromThisBatch;
                    totalDeducted += deductFromThisBatch;

                    if (remainingToDeduct <= 0) break;
                }
            }

            // If still remaining, deduct from the base inventory (for legacy items without batches)
            if (remainingToDeduct > 0)
            {
                string baseUpdateQuery = "UPDATE inventory SET Quantity = Quantity - @qty WHERE ItemID = @id";
                var baseUpdateParams = new Dictionary<string, object> {
                    { "@id", itemId },
                    { "@qty", remainingToDeduct }
                };
                db.ExecuteWrite(baseUpdateQuery, baseUpdateParams);
                totalDeducted += remainingToDeduct;
            }

            SyncInventoryTotal(itemId);

            return totalDeducted > 0;
        }
    
        public DataTable GetInventoryReport(DateTime? fromDate = null, DateTime? toDate = null, string search = "")
        {
            string query = @"SELECT 
                DATE_FORMAT(COALESCE(b.expiry_date, i.ExpiryDate), '%d-%b-%y') AS LastVisit,
                COALESCE(b.batch_no, CONCAT('ITEM-', i.ItemID)) AS IDNumber,
                i.Name AS PatientName,
                i.Category AS PatientType,
                CONCAT('Batch: ', COALESCE(b.batch_no, 'N/A'), ' - Stock: ', COALESCE(b.quantity, i.Quantity), ' units') AS Description,
                CONCAT(COALESCE(b.quantity, i.Quantity), ' (', i.WeeklyUsage, '/week)') AS QtyDosage,
                'Inventory System' AS Personnel
                FROM inventory i
                LEFT JOIN inventory_batches b ON i.ItemID = b.item_id
                WHERE 1=1";

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query += " AND i.Name LIKE @search";
                parameters.Add("@search", "%" + search + "%");
            }

            if (fromDate.HasValue && toDate.HasValue)
            {
                query += " AND COALESCE(b.expiry_date, i.ExpiryDate) >= @from AND COALESCE(b.expiry_date, i.ExpiryDate) <= @to";
                parameters.Add("@from", fromDate.Value.Date);
                parameters.Add("@to", toDate.Value.Date.AddDays(1).AddTicks(-1));
            }

            query += " ORDER BY COALESCE(b.expiry_date, i.ExpiryDate) DESC";

            return db.ExecuteRead(query, parameters);
        }
    }
}