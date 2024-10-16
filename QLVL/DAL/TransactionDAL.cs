using QLVL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLVL.DAL
{
    public class TransactionDAL
    {
        private readonly string connectionString;

        public TransactionDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Transaction> GetAllTransactions()
        {
            var transactions = new List<Transaction>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Transactions", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new Transaction
                        {
                            Transaction_Id = reader.GetInt32(0),
                            Quantity = reader.GetInt32(1),
                            TransactionType = reader.GetString(2),
                            TransactionDate = reader.GetDateTime(3),
                            Notes = reader.GetString(4),
                            Material_Id = reader.GetInt32(5),
                            Supplier_Id = reader.GetInt32(6),
                            User_Id = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7)
                        });
                    }
                }
            }
            return transactions;
        }

        public void AddTransaction(Transaction transaction)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Transactions (Quantity, TransactionType, TransactionDate, Notes, Material_Id, Supplier_Id, User_Id) VALUES (@Quantity, @TransactionType, @TransactionDate, @Notes, @Material_Id, @Supplier_Id, @User_Id)", connection);
                command.Parameters.AddWithValue("@Quantity", transaction.Quantity);
                command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                command.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                command.Parameters.AddWithValue("@Notes", transaction.Notes);
                command.Parameters.AddWithValue("@Material_Id", transaction.Material_Id);
                command.Parameters.AddWithValue("@Supplier_Id", transaction.Supplier_Id);
                command.Parameters.AddWithValue("@User_Id", (object)transaction.User_Id ?? DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        // Các phương thức khác như Update và Delete có thể thêm vào tương tự
    }
}
