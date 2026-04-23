using AceCareClinicSystem.Controllers;
using System;

namespace AceCareClinicSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            DbConnection db = new DbConnection();
            try {
                db.ExecuteWrite("ALTER TABLE inventory ADD COLUMN BatchNumber VARCHAR(50) AFTER Name");
                Console.WriteLine("Added BatchNumber column successfully.");
            } catch (Exception ex) {
                Console.WriteLine("Error or column already exists: " + ex.Message);
            }
        }
    }
}
