using System;

namespace QLVL.Entity
{
    public class Material
    {
        // Constructor mặc định
        public Material()
        {
            CreatedAt = DateTime.Now; // Gán giá trị mặc định cho CreatedAt
        }

        // Constructor đầy đủ
        public Material(int material_Id, string material_Name, int quantity, string unit, string description, DateTime createdAt)
        {
            Material_Id = material_Id;
            Material_Name = material_Name;
            Quantity = quantity;
            Unit = unit;
            Description = description;
            CreatedAt = createdAt;
        }

        // Properties
        public int Material_Id { get; set; } // PK
        public string Material_Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Giá trị mặc định
    }
}
