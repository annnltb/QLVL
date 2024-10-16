using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            // Thêm đoạn code kết nối cơ sở dữ liệu để lưu thông tin đăng ký tại đây
            // Ví dụ:
            // UserDAL.AddUser(new User { FullName = fullName, Email = email, PhoneNumber = phoneNumber, Username = username, Password = password, Position = position });

            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Đóng form sau khi đăng ký thành công
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

