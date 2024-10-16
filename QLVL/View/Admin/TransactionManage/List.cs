using QLVL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVL.View.Admin.TransactionManage
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            // Load data from database
            TransactionDAL transactionDAL = new TransactionDAL();

            // Load materials
            comboBox_material.DataSource = transactionDAL.GetAllMaterials();
            comboBox_material.DisplayMember = "Material_Name";
            comboBox_material.ValueMember = "Material_Id";

            // Load suppliers
            comboBox_supplier.DataSource = transactionDAL.GetAllSuppliers();
            comboBox_supplier.DisplayMember = "Supplier_Name";
            comboBox_supplier.ValueMember = "Supplier_Id";

            // Load users
            comboBox_user.DataSource = transactionDAL.GetAllUsers();
            comboBox_user.DisplayMember = "Name";
            comboBox_user.ValueMember = "UserId";

            // Load transaction types
            string[] transactionTypes = { "Nhập hàng", "Xuất hàng" };
            comboBox_transactionType.DataSource = transactionTypes;


        }

        private void List_Load(object sender, EventArgs e)
        {
            // Load all transactions
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            // Load data from database
            TransactionDAL transactionDAL = new TransactionDAL();

            // Set data source
            dataGridView1.DataSource = transactionDAL.GetAllTransactions("Nhập hàng");

            string[] columnNames = { "ID", "Số lượng", "Loại giao dịch", "Ngày giao dịch", "Ghi chú", "Nguyên liệu", "Nhà cung cấp", "Người dùng" };
            for (int i = 0; i < columnNames.Length && i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText = columnNames[i];
            }

            dataGridView2.DataSource = transactionDAL.GetAllTransactions("Xuất hàng");

            for (int i = 0; i < columnNames.Length && i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].HeaderText = columnNames[i];
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            // Save changes
            TransactionDAL transactionDAL = new TransactionDAL();

            // Get data from form
            //int transactionId = Convert.ToInt32(txt_id.Text);
            int quantity = Convert.ToInt32(txt_quantity.Text);
            string transactionType = comboBox_transactionType.Text;
            DateTime transactionDate = dateTimePicker1.Value;
            string notes = txt_notes.Text;
            int materialId = Convert.ToInt32(comboBox_material.SelectedValue);
            int supplierId = Convert.ToInt32(comboBox_supplier.SelectedValue);

            int userId = Convert.ToInt32(comboBox_user.SelectedValue);

            // Create new transaction
            Entity.Transaction transaction = new Entity.Transaction();
            transaction.TransactionType = transactionType;
            transaction.TransactionDate = transactionDate;
            transaction.Notes = notes;
            transaction.Material_Id = materialId;
            transaction.Supplier_Id = supplierId;
            transaction.User_Id = userId;

            // Save to database
            transactionDAL.AddTransaction(transaction);

            // Reload data
            LoadTransactions();

        }
    }
}
