using QLVL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLVL.DAL
{
    public class SupplierDAL
    {
        private readonly string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=\"New Database\";Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public SupplierDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SupplierDAL()
        {
        }

        // Lấy tất cả nhà cung cấp
        public List<Supplier> GetAllSuppliers()
        {
            var suppliers = new List<Supplier>();
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
                            CreatedAt = reader.GetDateTime(4)
                        });
                    }
                }
            }
            return suppliers;
        }

        // Thêm nhà cung cấp mới
        public void AddSupplier(Supplier supplier)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Suppliers (SupplierName, ContactInfo, Address, CreatedAt) VALUES (@Supplier_Name, @ContactInfo, @Address, @CreatedAt)", connection);
                command.Parameters.AddWithValue("@Supplier_Name", supplier.Supplier_Name);
                command.Parameters.AddWithValue("@ContactInfo", supplier.ContactInfo);
                command.Parameters.AddWithValue("@Address", supplier.Address);
                command.Parameters.AddWithValue("@CreatedAt", supplier.CreatedAt);
                command.ExecuteNonQuery();
            }
        }

        public Supplier GetSupplierById(int v)
        {
            // get supplier by id
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Suppliers WHERE SupplierId = @Supplier_Id", connection);
                command.Parameters.AddWithValue("@Supplier_Id", v);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Supplier
                        {
                            Supplier_Id = reader.GetInt32(0),
                            Supplier_Name = reader.GetString(1),
                            ContactInfo = reader.GetString(2),
                            Address = reader.GetString(3),
                            CreatedAt = reader.GetDateTime(4)
                        };
                    }
                }
            }

            return null;
        }

        public void UpdateSupplier(Supplier supplier1)
        {
            // update supplier
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Suppliers SET SupplierName = @Supplier_Name, ContactInfo = @ContactInfo, Address = @Address WHERE SupplierId = @Supplier_Id", connection);
                command.Parameters.AddWithValue("@Supplier_Id", supplier1.Supplier_Id);
                command.Parameters.AddWithValue("@Supplier_Name", supplier1.Supplier_Name);
                command.Parameters.AddWithValue("@ContactInfo", supplier1.ContactInfo);
                command.Parameters.AddWithValue("@Address", supplier1.Address);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteSupplier(int v)
        {
            // delete supplier
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Suppliers WHERE SupplierId = @Supplier_Id", connection);
                command.Parameters.AddWithValue("@Supplier_Id", v);
                command.ExecuteNonQuery();
            }
        }
    }
}
