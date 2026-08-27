using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using System.Management;

namespace Mini_Market_Management_System
{
    public partial class LoginForm : Form
    {
        DBConnect dBcon = new DBConnect();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Seller WHERE SellerName='" + TextBox_username.Text + "' AND SellerPass='" + TextBox_pass.Text + "'";
            SqlCommand command = new SqlCommand(selectQuery, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                SellingForm selling = new SellingForm();
                selling.Show();
                selling.getTable();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong ID or Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {

            try
            {

                string insertQuery = "INSERT INTO Seller (SellerName, SellerPass) VALUES (@Name, @Password)";

                using (SqlCommand command = new SqlCommand(insertQuery, dBcon.GetCon()))
                {

                    command.Parameters.AddWithValue("@Name", TextBox_username.Text);
                    command.Parameters.AddWithValue("@Password", TextBox_pass.Text);

                    dBcon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account Creation Successful!", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBcon.CloseCon();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Hide();
        }
    }
}
