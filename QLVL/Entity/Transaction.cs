using System;

namespace QLVL.Entity
{
    public class Transaction
    {
        // Constructor mặc định
        public Transaction()
        {
            TransactionDate = DateTime.Now; // Gán giá trị mặc định cho TransactionDate
        }

        // Constructor đầy đủ
        public Transaction(int transaction_Id, int quantity, string transactionType, DateTime transactionDate, string notes, int material_Id, int supplier_Id, int user_Id)
        {
            Transaction_Id = transaction_Id;
            Quantity = quantity;
            TransactionType = transactionType;
            TransactionDate = transactionDate;
            Notes = notes;
            Material_Id = material_Id;
            Supplier_Id = supplier_Id;
            User_Id = user_Id;
        }

        // Properties
        public int Transaction_Id { get; set; } // PK
        public int Quantity { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now; // Giá trị mặc định
        public string Notes { get; set; }

        // Foreign Keys
        public int Material_Id { get; set; } // FK to Material
        public int Supplier_Id { get; set; } // FK to Supplier
        public int? User_Id { get; set; } // FK to User
    }
}
