using System;

namespace QLVL.Entity
{
    public class Supplier
    {
        // Constructor đầy đủ
        public Supplier(int supplier_Id, string supplier_Name, string contactInfo, string address, DateTime createdAt)
        {
            Supplier_Id = supplier_Id;
            Supplier_Name = supplier_Name;
            ContactInfo = contactInfo;
            Address = address;
            CreatedAt = createdAt;
        }

        // Constructor mặc định
        public Supplier()
        {
            CreatedAt = DateTime.Now; // Gán giá trị mặc định cho CreatedAt
        }

        // Properties
        public int Supplier_Id { get; set; } // PK
        public string Supplier_Name { get; set; }
        public string ContactInfo { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Giá trị mặc định
    }
}
