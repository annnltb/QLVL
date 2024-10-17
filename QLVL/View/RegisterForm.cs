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

namespace QLVL.View
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các trường
            string fullName = txt_fullname.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhonenumber.Text;
            string username = txtUsername.Text;
            string position = comboBox_position.SelectedItem.ToString();
            string password = txtpass.Text;
            string confirmPassword = txtconfirmpass.Text;

            // Kiểm tra nếu mật khẩu và xác nhận mật khẩu không khớp
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem các trường có bị trống không
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kết nối cơ sở dữ liệu và lưu thông tin đăng ký
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=doantichhop_hc;Integrated Security=True;Encrypt=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Name, Email, PhoneNumber, Username, Password, Position) VALUES (@FullName, @Email, @PhoneNumber, @Username, @Password, @Position)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password); // Nên mã hóa mật khẩu
                        command.Parameters.AddWithValue("@Position", position);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi đăng ký thành công
                    LoginForm login= new LoginForm();
                    login.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi đăng ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox Position chỉ có một mục "Nhân viên kho"
            comboBox_position.Items.Clear();
            comboBox_position.Items.Add("Nhân viên kho");
            comboBox_position.SelectedIndex = 0; // Đặt mục đầu tiên làm mặc định
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Close();
        }
    }
    }

