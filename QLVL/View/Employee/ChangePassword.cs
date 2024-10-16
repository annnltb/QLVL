using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLVL.View.Employee
{
    public partial class ChangePassword : Form
    {
        private string currentUsername; // Khai báo biến

        public ChangePassword()
        {
            InitializeComponent();
        //    currentUsername = username; // Gán giá trị cho biến

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string oldPassword = txt_oldpass.Text;
            string newPassword = txt_newpass.Text;
            string confirmNewPassword = txt_confirm.Text;

            // Kiểm tra xem mật khẩu mới và xác nhận có giống nhau không
            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            // Kiểm tra mật khẩu cũ
            if (!CheckOldPassword(oldPassword))
            {
                MessageBox.Show("Mật khẩu cũ không đúng.");
                return;
            }

            // Cập nhật mật khẩu mới vào cơ sở dữ liệu
            if (UpdatePassword(newPassword))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình đổi mật khẩu.");
            }
        }
        private bool CheckOldPassword(string oldPassword)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=doantichhop_hc;Integrated Security=True;Encrypt=True";
            string storedPassword = ""; // Khởi tạo biến để lưu trữ mật khẩu cũ

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Password FROM Users WHERE Username = @Username"; // Thay đổi Username theo yêu cầu
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", currentUsername); // currentUsername là tên người dùng hiện tại

                        // Đọc mật khẩu từ cơ sở dữ liệu
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                storedPassword = reader["Password"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kiểm tra mật khẩu cũ: {ex.Message}");
                    return false;
                }
            }

            // So sánh mật khẩu cũ
            return oldPassword == storedPassword; // Thay đổi cách kiểm tra theo yêu cầu của bạn
        }
        // Hàm cập nhật mật khẩu mới
        private bool UpdatePassword(string newPassword)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=doantichhop_hc;Integrated Security=True;Encrypt=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Users SET Password = @Password WHERE Username = @Username"; // Thay đổi bảng và cột theo yêu cầu
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Password", newPassword);
                        command.Parameters.AddWithValue("@Username", currentUsername); // Thay đổi để lấy tên người dùng hiện tại
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật mật khẩu mới: {ex.Message}");
                    return false;
                }
            }

            return true;
        }
    }
}
