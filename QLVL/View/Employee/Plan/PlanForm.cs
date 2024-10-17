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

namespace QLVL.View.Employee
{
    public partial class PlanForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Quanlyvatlieu_doantichhop;Integrated Security=True";

        public PlanForm()
        {
            InitializeComponent();
        }

        private void Plan_Load(object sender, EventArgs e)
        {
            LoadInventoryPlans();
        }

        private void LoadInventoryPlans()
        {
            string query = "SELECT * FROM InventoryPlans";
            DataTable plansTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                connection.Open();
                adapter.Fill(plansTable);
                dataGridViewPlans.DataSource = plansTable;

                // Đặt tên cột cho DataGridView
                string[] columnNames = { "Mã Kế Hoạch", "Mã Vật Liệu", "Mã người dùng", "Số lượng", "Ngày tạo kế hoạch", "Ngày Dự Kiến Hoàn Thành" };
                for (int i = 0; i < columnNames.Length && i < dataGridViewPlans.Columns.Count; i++)
                {
                    dataGridViewPlans.Columns[i].HeaderText = columnNames[i];
                }
            }
        }
    }
    }
