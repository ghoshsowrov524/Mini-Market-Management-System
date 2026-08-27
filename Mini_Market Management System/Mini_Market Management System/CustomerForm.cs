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

namespace Mini_Market_Management_System
{
    public partial class CustomerForm : Form
    {
        DBConnect dBcon = new DBConnect();
        public CustomerForm()
        {
            InitializeComponent();
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            getTable();
            dataGridView_customer.Refresh();
        }
        public void getTable()
        {
            string selectQuerry = "SELECT * FROM Seller";
            SqlCommand command = new SqlCommand(selectQuerry, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView_customer.DataSource = table;
            
        }

        private void clear()
        {
            
            TextBox_name.Clear();
            TextBox_pass.Clear();
            
            
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {

                string insertQuery = "INSERT INTO Seller (SellerName, SellerPass) VALUES (@Name, @Password)";

                using (SqlCommand command = new SqlCommand(insertQuery, dBcon.GetCon()))
                {
                  
                    command.Parameters.AddWithValue("@Name", TextBox_name.Text);
                    command.Parameters.AddWithValue("@Password", TextBox_pass.Text);

                    dBcon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("User Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBcon.CloseCon();

                    getTable(); 
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (string.IsNullOrWhiteSpace(TextBox_name.Text) || string.IsNullOrWhiteSpace(TextBox_pass.Text))
                {
                    MessageBox.Show("Missing Information", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

   
                int userId;
                if (!int.TryParse(Textbox_id.Text, out userId))
                {
                    MessageBox.Show("Please enter a valid User ID.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                string updateQuery = "UPDATE Seller SET SellerName = @SellerName, SellerPass = @SellerPass WHERE SellerId = @SellerId";

                using (SqlCommand command = new SqlCommand(updateQuery, dBcon.GetCon()))
                {
                   
                    command.Parameters.AddWithValue("@SellerName", TextBox_name.Text);
                    command.Parameters.AddWithValue("@SellerPass", TextBox_pass.Text);
                    command.Parameters.AddWithValue("@SellerId", userId);

                    dBcon.OpenCon();
                    int rowsAffected = command.ExecuteNonQuery();

                    
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User Updated Successfully!", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No user found with the provided User ID.", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    dBcon.CloseCon();
                    getTable();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                
                int userId;
                if (!int.TryParse(Textbox_id.Text, out userId))
                {
                    MessageBox.Show("Please enter a valid User ID.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

               
                string deleteQuery = "DELETE FROM Seller WHERE SellerId = @SellerId";

                using (SqlCommand command = new SqlCommand(deleteQuery, dBcon.GetCon()))
                {
                   
                    command.Parameters.AddWithValue("@SellerId", userId);

                    dBcon.OpenCon();
                    int rowsAffected = command.ExecuteNonQuery();

                   
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User Deleted Successfully!", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No user found with the provided User ID.", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    dBcon.CloseCon();
                    getTable(); 
                    clear(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridView_customer_Click(object sender, EventArgs e)
        {

            Textbox_id.Text = dataGridView_customer.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = dataGridView_customer.SelectedRows[0].Cells[1].Value.ToString();

            TextBox_pass.Text = dataGridView_customer.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
    }


