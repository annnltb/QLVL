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

namespace QLVL.View.Admin
{
    public partial class MaterialList : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Quanlyvatlieu_doantichhop;Integrated Security=True";

        public MaterialList()
        {
            InitializeComponent();
            LoadMaterials();
        }


        private void LoadMaterials()
        {
            string query = "SELECT * FROM Materials";
            DataTable materialsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adapter.Fill(materialsTable);


                    
                    // Gán DataTable cho DataGridView
                    dataGridViewMaterials.DataSource = materialsTable;

                    // Đặt tên cột bằng mảng
                    string[] columnNames = { "Mã vật liệu", "Tên vật liệu", "Đơn vị", "Số lượng","Mô tả", "Thời gian" }; // Thay đổi tên cột theo nhu cầu của bạn
                    for (int i = 0; i < columnNames.Length && i < dataGridViewMaterials.Columns.Count; i++)
                    {
                        dataGridViewMaterials.Columns[i].HeaderText = columnNames[i];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void MaterialList_Load(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {


        }
    }
}

