using System;

namespace QLVL.Entity
{
    public class InventoryPlan
    {
        // Constructor mặc định
        public InventoryPlan()
        {
            CreatedAt = DateTime.Now; // Gán giá trị mặc định cho CreatedAt
        }

        // Constructor đầy đủ
        public InventoryPlan(int plan_Id, int plannedQuantity, DateTime plannedDate, DateTime createdAt, int material_Id, int user_Id)
        {
            Plan_Id = plan_Id;
            PlannedQuantity = plannedQuantity;
            PlannedDate = plannedDate;
            CreatedAt = createdAt;
            Material_Id = material_Id;
            User_Id = user_Id;
        }

        // Properties
        public int Plan_Id { get; set; } // PK
        public int PlannedQuantity { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Giá trị mặc định

        // Foreign Keys
        public int Material_Id { get; set; } // FK to Material
        public int User_Id { get; set; } // FK to User
    }
}
