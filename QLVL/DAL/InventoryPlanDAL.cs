using QLVL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLVL.DAL
{
    public class InventoryPlanDAL
    {
        private readonly string connectionString;

        public InventoryPlanDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Lấy tất cả kế hoạch nhập kho
        public List<InventoryPlan> GetAllPlans()
        {
            var plans = new List<InventoryPlan>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM InventoryPlans", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        plans.Add(new InventoryPlan
                        {
                            Plan_Id = reader.GetInt32(0),
                            PlannedQuantity = reader.GetInt32(1),
                            PlannedDate = reader.GetDateTime(2),
                            CreatedAt = reader.GetDateTime(3),
                            Material_Id = reader.GetInt32(4),
                            User_Id = reader.GetInt32(5)
                        });
                    }
                }
            }
            return plans;
        }

        // Thêm kế hoạch nhập kho mới
        public void AddPlan(InventoryPlan plan)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO InventoryPlans (PlannedQuantity, PlannedDate, CreatedAt, Material_Id, User_Id) VALUES (@PlannedQuantity, @PlannedDate, @CreatedAt, @Material_Id, @User_Id)", connection);
                command.Parameters.AddWithValue("@PlannedQuantity", plan.PlannedQuantity);
                command.Parameters.AddWithValue("@PlannedDate", plan.PlannedDate);
                command.Parameters.AddWithValue("@CreatedAt", plan.CreatedAt);
                command.Parameters.AddWithValue("@Material_Id", plan.Material_Id);
                command.Parameters.AddWithValue("@User_Id", plan.User_Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
