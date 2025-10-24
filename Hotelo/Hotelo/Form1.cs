using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotelo
{
    public partial class Form1 : Form
    {
        private static HoteloDBEntities HoteloDatabase = new HoteloDBEntities();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void LoadData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("User ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Room", typeof(string));

            dataGridView1.DataSource = dt;

            var Customer = HoteloDatabase.Customer.ToList();

            foreach (var Customers in Customer)
            {

                dt.Rows.Add(Customers.CustomerID, Customers.CustomerName, Customers.CustomerEmail, Customers.Room.RoomType);
            }
            var Room = HoteloDatabase.Room.ToList();
                
            comboBox1.Items.Clear();

            foreach (var Rooms in Room)
            {
                comboBox1.Items.Add(Rooms.RoomType);

            }
        }

        private void ReserveBtn_Click(object sender, EventArgs e)
        {
            var Customer = new Customer()
            {
                CustomerName = CustNameTxt.Text,
                CustomerEmail = CustEmailTxt.Text,
                RoomID = comboBox1.SelectedIndex + 1
            };
            
            HoteloDatabase.Customer.Add(Customer);

            HoteloDatabase.SaveChanges();

            LoadData();

            MessageBox.Show("Room Reserved Succesfully!", "Sucess");
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}