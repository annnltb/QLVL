using QLVL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLVL.DAL
{
    public class MaterialDAL
    {
       
       
            private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Quanlyvatlieu_doantichhop;Integrated Security=True"; // Thay bằng chuỗi kết nối của bạn

            public List<Material> GetAllMaterials()
            {
                List<Material> materials = new List<Material>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Materials", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        materials.Add(new Material
                        {
                            Material_Id = (int)reader["Material_Id"],
                            Material_Name = reader["Material_Name"].ToString(),
                            Quantity = (int)reader["Quantity"],
                            Unit = reader["Unit"].ToString(),
                            Description = reader["Description"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"]
                        });
                    }
                }
                return materials;
            }

            public Material GetMaterialById(int materialId)
            {
                Material material = null;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Materials WHERE Material_Id = @Material_Id", connection);
                    command.Parameters.AddWithValue("@Material_Id", materialId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        material = new Material
                        {
                            Material_Id = (int)reader["Material_Id"],
                            Material_Name = reader["Material_Name"].ToString(),
                            Quantity = (int)reader["Quantity"],
                            Unit = reader["Unit"].ToString(),
                            Description = reader["Description"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"]
                        };
                    }
                }
                return material;
            }

            public void AddMaterial(Material material)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Materials (Material_Name, Quantity, Unit, Description, CreatedAt) VALUES (@Material_Name, @Quantity, @Unit, @Description, @CreatedAt)", connection);
                    command.Parameters.AddWithValue("@Material_Name", material.Material_Name);
                    command.Parameters.AddWithValue("@Quantity", material.Quantity);
                    command.Parameters.AddWithValue("@Unit", material.Unit);
                    command.Parameters.AddWithValue("@Description", material.Description);
                    command.Parameters.AddWithValue("@CreatedAt", material.CreatedAt);
                    command.ExecuteNonQuery();
                }
            }

            public void UpdateMaterial(Material material)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Materials SET Material_Name = @Material_Name, Quantity = @Quantity, Unit = @Unit, Description = @Description WHERE Material_Id = @Material_Id", connection);
                    command.Parameters.AddWithValue("@Material_Id", material.Material_Id);
                    command.Parameters.AddWithValue("@Material_Name", material.Material_Name);
                    command.Parameters.AddWithValue("@Quantity", material.Quantity);
                    command.Parameters.AddWithValue("@Unit", material.Unit);
                    command.Parameters.AddWithValue("@Description", material.Description);
                    command.ExecuteNonQuery();
                }
            }

            public void DeleteMaterial(int materialId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Materials WHERE Material_Id = @Material_Id", connection);
                    command.Parameters.AddWithValue("@Material_Id", materialId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

