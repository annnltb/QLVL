using QLVL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLVL.DAL
{
    public class TransactionDAL
    {
        private readonly string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=\"New Database\";Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public TransactionDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TransactionDAL()
        {
        }

        public List<Transaction> GetAllTransactions(String type)
        {
            var transactions = new List<Transaction>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Transactions WHERE TransactionType = @type", connection);
                command.Parameters.AddWithValue("@type", type);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new Transaction
                        {
                            Transaction_Id = reader.GetInt32(0),

                            Material_Id = reader.GetInt32(1),
                            Supplier_Id = reader.GetInt32(2),
                            User_Id = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            Quantity = reader.GetInt32(4),
                            TransactionType = reader.GetString(5),
                            TransactionDate = reader.GetDateTime(6),
                            Notes = reader.GetString(7)

                        });
                    }
                }

                // change id to name
                foreach (var transaction in transactions)
                {
                    transaction.Material_Name = GetMaterialNameById(transaction.Material_Id).ToString();
                    transaction.Supplier_Name = GetSupplierNameById(transaction.Supplier_Id).ToString();
                    transaction.User_Name = GetUserNameById(transaction
                        .User_Id ?? 0).ToString();
                }
            }
            return transactions;
        }

        public void AddTransaction(Transaction transaction)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Transactions (Quantity, TransactionType, TransactionDate, Notes, MaterialId, SupplierId, UserId) VALUES (@Quantity, @TransactionType, @TransactionDate, @Notes, @Material_Id, @Supplier_Id, @User_Id)", connection);
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

        internal object GetSupplierNameById(int v)
        {
            // get supplier name by id
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT SupplierName FROM Suppliers WHERE SupplierId = @SupplierId", connection);
                    command.Parameters.AddWithValue("@SupplierId", v);
                    return command.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal object GetMaterialNameById(int v)
        {
            // get material name by id
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT MaterialName FROM Materials WHERE MaterialId = @MaterialId", connection);
                    command.Parameters.AddWithValue("@MaterialId", v);
                    return command.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal object GetUserNameById(int v)
        {
            // get user name by id
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT UserName FROM Users WHERE UserId = @UserId", connection);
                    command.Parameters.AddWithValue("@UserId", v);
                    return command.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal object GetAllMaterials()
        {
            // get all materials
            var materials = new List<Material>();
            try
            {

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Materials", connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            materials.Add(new Material
                            {
                                Material_Id = reader.GetInt32(0),
                                Material_Name = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                Unit = reader.GetString(3),
                                Description = reader.GetString(4),
                            
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return materials;
        }

        internal object GetAllSuppliers()
        {
            // get all suppliers
            var suppliers = new List<Supplier>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Suppliers", connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
                            {
                                Supplier_Id = reader.GetInt32(0),
                                Supplier_Name = reader.GetString(1),
                                ContactInfo = reader.GetString(2),
                                Address = reader.GetString(3),
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return suppliers;
        }

        internal object GetAllUsers()
        {
            // get all users

            var users = new List<User>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Users", connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                            });
                        }
                    }
                }

            }
            catch (Exception)
            {
                return null;
            }

            return users;
        }
    }
}
