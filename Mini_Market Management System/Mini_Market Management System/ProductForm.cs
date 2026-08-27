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
    public partial class ProductForm : Form
    {
        DBConnect dBcon = new DBConnect();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm();
            customer.Show();
            this.Hide();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void getTable()
        {
            string selectQuerry = "SELECT * FROM Product";
            SqlCommand command = new SqlCommand (selectQuerry, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView_product.DataSource = table;
        }

        private void clear ()
        {
            Textbox_id.Clear();
            TextBox_name.Clear();
            TextBox_price.Clear();
            TextBox_qty.Clear();

        }
        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {

                string insertQuery = "INSERT INTO Product VALUES (" + Textbox_id.Text + ",'" + TextBox_name.Text + "'," + TextBox_price.Text + "," + TextBox_qty.Text + ")";
                SqlCommand command = new SqlCommand(insertQuery, dBcon.GetCon());
                dBcon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBcon.CloseCon();
                getTable();
                clear();
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
                try
                {
                    string updateQuery = "UPDATE Product SET ProdName=@ProdName, ProdPrice=@ProdPrice, ProdQty=@ProdQty WHERE ProdID=@ProdID";

                    using (SqlCommand command = new SqlCommand(updateQuery, dBcon.GetCon()))
                    {
                       
                        int prodPrice, prodQty, prodID;

                     
                        string priceInput = TextBox_price.Text.Trim();
                        string qtyInput = TextBox_qty.Text.Trim();
                        string idInput = Textbox_id.Text.Trim();

                       
                        if (!int.TryParse(priceInput, out prodPrice))
                        {
                            MessageBox.Show("Please enter a valid price in cents.");
                            return;
                        }

                        if (!int.TryParse(qtyInput, out prodQty))
                        {
                            MessageBox.Show("Please enter a valid quantity.");
                            return;
                        }

                        if (!int.TryParse(idInput, out prodID))
                        {
                            MessageBox.Show("Please enter a valid Product ID.");
                            return;
                        }

                       
                        command.Parameters.AddWithValue("@ProdName", TextBox_name.Text);
                        command.Parameters.AddWithValue("@ProdPrice", prodPrice);
                        command.Parameters.AddWithValue("@ProdQty", prodQty);
                        command.Parameters.AddWithValue("@ProdID", prodID);

                     
                        dBcon.OpenCon();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product Updated Successfully", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_product_Click(object sender, EventArgs e)
        {
            Textbox_id.Text = dataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = dataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_price.Text = dataGridView_product.SelectedRows[0].Cells[2].Value.ToString();
            TextBox_qty.Text = dataGridView_product.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Textbox_id.Text == "")
               { MessageBox.Show("Missing Information", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

               }
                else
                { string deleteQuery = "DELETE FROM Product WHERE Prodid=" + Textbox_id.Text + "";
                    SqlCommand command = new SqlCommand(deleteQuery, dBcon.GetCon());
                    dBcon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm();
            customer.Show();
            customer.getTable();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_qty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Textbox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
