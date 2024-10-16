using QLVL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLVL.DAL
{
    public class SupplierDAL
    {
        private readonly string connectionString;

        public SupplierDAL(string connectionString)
        {
            this.connectionString = connectionString;
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
                var command = new SqlCommand("INSERT INTO Suppliers (Supplier_Name, ContactInfo, Address, CreatedAt) VALUES (@Supplier_Name, @ContactInfo, @Address, @CreatedAt)", connection);
                command.Parameters.AddWithValue("@Supplier_Name", supplier.Supplier_Name);
                command.Parameters.AddWithValue("@ContactInfo", supplier.ContactInfo);
                command.Parameters.AddWithValue("@Address", supplier.Address);
                command.Parameters.AddWithValue("@CreatedAt", supplier.CreatedAt);
                command.ExecuteNonQuery();
            }
        }
    }
}
