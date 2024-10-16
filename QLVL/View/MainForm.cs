using QLVL.Entity;
using QLVL.View.Admin;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLVL.View
{
    public partial class MainForm : Form

    {
        

        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=doantichhop_hc;Integrated Security=True;Encrypt=True";

        public MainForm(string position,string email)
        {
            InitializeComponent();
            LoadMenuForUserRole(position);
           
        }

        private void LoadMenuForUserRole(string position)
        {
            đăngXuấtToolStripMenuItem.Enabled = true;
            đổiMậtKhẩuToolStripMenuItem.Enabled= true;
            if (position == "Admin")
            {
                // Admin không có "Chức năng"
                chứcNăngToolStripMenuItem.Visible = false;
                quảnLýToolStripMenuItem.Visible = true;
                lậpBáoCáoVàPhânTíchToolStripMenuItem.Visible = true;
            }
            else if (position == "Nhân viên kho")
            {
                // Nhân viên kho không có "Quản lý" và "Lập báo cáo"
                quảnLýToolStripMenuItem.Visible = false;
                lậpBáoCáoVàPhânTíchToolStripMenuItem.Visible = false;
                chứcNăngToolStripMenuItem.Visible = true;
            }
        }

        // Hàm lấy vai trò người dùng từ cơ sở dữ liệu
        private string GetUserRoleFromDatabase(string email, string password)
        {
            string position = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Position FROM Users WHERE Email = @email AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    position = reader["Role"].ToString();
                }
                conn.Close();
            }
            return position;
        }

        // Xử lý sự kiện khi form được load
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Có thể thêm mã xử lý khi form load, nếu cần
        }

        // hiển thị các chức năng
        private void quảnLýDanhMụcVậtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialList materialList = new MaterialList();
            materialList.Show();
            
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
