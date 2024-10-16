using QLVL.View;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLVL
{
    public partial class LoginForm : Form

    { 
      
        public LoginForm()
        {
            InitializeComponent();
        }

        // Sự kiện khi bấm nút đăng nhập
        private void btn_login_Click(object sender, EventArgs e)
        {
                string email = txtemail.Text;
                string password = txt_pass.Text;

                // Kiểm tra xem người dùng đã nhập email và mật khẩu chưa
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ email và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi hàm kiểm tra thông tin đăng nhập từ cơ sở dữ liệu
                if (CheckLogin(email, password))
                {
               
                                   // Lấy vai trò người dùng
                string role = GetUserRoleFromDatabase(email, password);
                    if (!string.IsNullOrEmpty(role))
                    {
                        MainForm mainForm = new MainForm(role,email);
                        mainForm.Show();
                        this.Hide(); // Ẩn form đăng nhập
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy vai trò người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        //lấy role từ database
        private string GetUserRoleFromDatabase(string email, string password)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Quanlyvatlieu_doantichhop;Integrated Security=True";
            string role = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Truy vấn cơ sở dữ liệu
                    string query = "SELECT Position FROM Users WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Thực thi truy vấn và lấy giá trị
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            role = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return role;
        }



        // Hàm kiểm tra thông tin đăng nhập từ cơ sở dữ liệu
        private bool CheckLogin(string email, string password)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Quanlyvatlieu_doantichhop;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Truy vấn cơ sở dữ liệu
                    string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Thực thi truy vấn
                        int count = (int)cmd.ExecuteScalar();

                        // Nếu count > 0 thì thông tin đăng nhập đúng
                        if (count > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        // Sự kiện khi bấm nút thoát
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            HomeForm tc= new HomeForm();
            tc.Show();
            this.Close();
        }
    }
}
