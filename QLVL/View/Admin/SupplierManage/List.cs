using QLVL.BLL;
using QLVL.DAL;
using QLVL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVL.View.Admin.SupplierManage
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Load data from database
            SupplierDAL supplierDAL = new SupplierDAL();

            // Set data source
            dataGridViewSuppliers.DataSource = supplierDAL.GetAllSuppliers();

            string[] columnNames = { "ID", "Tên nhà cung cấp", "Thông tin liên lạc", "Địa chỉ", "Thời gian" };
            for (int i = 0; i < columnNames.Length && i < dataGridViewSuppliers.Columns.Count; i++)
            {
                dataGridViewSuppliers.Columns[i].HeaderText = columnNames[i];
            }


        }

        private void Btn_save_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                SupplierDAL supplierDAL1 = new SupplierDAL();

                Supplier supplier1 = supplierDAL1.GetSupplierById(id);

                if (supplier1 != null)
                {
                    supplier1.Supplier_Name = textBox2.Text;
                    supplier1.ContactInfo = textBox3.Text;
                    supplier1.Address = textBox4.Text;

                    supplierDAL1.UpdateSupplier(supplier1);

                    LoadData();
                    ClearTextboxes();
                    return;
                }
            }



            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }


            // Get data from textboxes
            string supplierName = textBox2.Text;
            string contactInfo = textBox3.Text;
            string address = textBox4.Text;

            // log data
            Console.WriteLine(supplierName);
            Console.WriteLine(contactInfo);
            Console.WriteLine(address);



            // Create new supplier
            Supplier supplier = new Supplier
            {
                Supplier_Name = supplierName,
                ContactInfo = contactInfo,
                Address = address,
                CreatedAt = DateTime.Now
            };

            // Add supplier to database
            SupplierDAL supplierDAL = new SupplierDAL();
            supplierDAL.AddSupplier(supplier);

            // Reload data
            LoadData();
            // Clear textboxes
            ClearTextboxes();

        }

        private void ClearTextboxes()
        {
            // Clear textboxes
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void DataGridViewSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get selected row
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewSuppliers.Rows[index];
            // Set data to textboxes

            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[3].Value.ToString();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ClearTextboxes();
        }

        private void DataGridViewSuppliers_CellContentClick(object sender, MouseEventArgs e)
        {
            // Get selected row
            int index = dataGridViewSuppliers.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridViewSuppliers.Rows[index];
            // Set data to textboxes

            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[3].Value.ToString();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // get id from textbox
            int id = int.Parse(textBox1.Text);

            // delete supplier
            SupplierDAL supplierDAL = new SupplierDAL();
            supplierDAL.DeleteSupplier(id);

            // reload data
            LoadData();
            // clear textboxes
            ClearTextboxes();


        }
    }
}
