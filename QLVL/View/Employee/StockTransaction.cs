using QLVL.DAL;
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
    public partial class StockTransaction : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Quanlyvatlieu_doantichhop;Integrated Security=True";
        
        public StockTransaction()
        {
            InitializeComponent();
            
        }

        public void LoadTransaction()
        {

            string query = "SELECT * FROM Transactions";
            DataTable transactionsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adapter.Fill(transactionsTable);



                    // Gán DataTable cho DataGridView
                    dataGridViewTransaction.DataSource = transactionsTable;

                    // Đặt tên cột bằng mảng
                    string[] columnNames = { "Mã giao dịch", "Mã vật liệu", "Mã nhà cung cấp", "Mã người dùng", "Số lượng", "Loại giao dịch", "Thời gian", "Mô tả" }; // Thay đổi tên cột theo nhu cầu của bạn
                    for (int i = 0; i < columnNames.Length && i < dataGridViewTransaction.Columns.Count; i++)
                    {
                        dataGridViewTransaction.Columns[i].HeaderText = columnNames[i];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void StockTransaction_Load(object sender, EventArgs e)
        {
            LoadTransaction();
            comboBox_type.Items.Add("Nhập");
            comboBox_type.Items.Add("Xuất");

        }

        private void btn_sx_Click(object sender, EventArgs e)
        {
            if (comboBox_type.SelectedItem != null)
    {
        string transactionType = comboBox_type.SelectedItem.ToString();
        DataTable transactionTable = new DataTable();

        // Câu truy vấn để lấy giao dịch theo loại
        string query = "SELECT * FROM Transactions WHERE TransactionType = @TransactionType";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TransactionType", transactionType);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            try
            {
                connection.Open();
                adapter.Fill(transactionTable);

                // Gán DataTable cho DataGridView
                dataGridViewTransaction.DataSource = transactionTable;

                // Đặt tên cột bằng mảng
                string[] columnNames = { "Mã giao dịch", "Mã vật liệu", "Mã nhà cung cấp", "Mã người dùng", "Số lượng", "Loại giao dịch", "Thời gian", "Mô tả" }; // Thay đổi tên cột theo nhu cầu của bạn
                for (int i = 0; i < columnNames.Length && i < dataGridViewTransaction.Columns.Count; i++)
                {
                    dataGridViewTransaction.Columns[i].HeaderText = columnNames[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
    }
    else
    {
        MessageBox.Show("Vui lòng chọn loại giao dịch trước!");
    }

        }

        private void dataGridViewTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
