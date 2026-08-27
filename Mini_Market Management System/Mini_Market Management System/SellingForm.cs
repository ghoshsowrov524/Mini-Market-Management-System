using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mini_Market_Management_System
{
    public partial class SellingForm : Form
    {
        DBConnect dBcon = new DBConnect();

        public SellingForm()
        {
            InitializeComponent();
        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        public void getTable()
        {
            string selectQuery = "SELECT ProdId, ProdName, ProdPrice, ProdQty FROM Product";
            using (SqlCommand command = new SqlCommand(selectQuery, dBcon.GetCon()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataView view = new DataView(table);
                view.RowFilter = "ProdQty > 0"; // Filter condition

                dataGridView_selling.DataSource = view;
                
            }
        }

        private void clear()
        {
            Textbox_id.Clear();
            TextBox_name.Clear();
            TextBox_price.Clear();
            TextBox_qty.Clear();
        }

        private void dataGridView_selling_Click(object sender, EventArgs e)
        {
            Textbox_id.Text = dataGridView_selling.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = dataGridView_selling.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_price.Text = dataGridView_selling.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
           
            if (!int.TryParse(TextBox_qty.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer for quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(TextBox_price.Text, out int pricePerUnit) || pricePerUnit < 0)
            {
                MessageBox.Show("Please enter a valid positive integer for price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            
            if (!int.TryParse(Textbox_id.Text, out int productId))
            {
                MessageBox.Show("Invalid product ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            
            int total = pricePerUnit * quantity;

            // Show the total price message
            MessageBox.Show("Total Price: " + total + "\nChecking Stock!", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            
            UpdateProductQuantity(productId, quantity);
        }

        private void UpdateProductQuantity(int productId, int quantityToSubtract)
        {
            using (SqlConnection connection = dBcon.GetCon())
            {
                connection.Open(); 

                
                int currentQuantity;
                using (SqlCommand cmd = new SqlCommand("SELECT ProdQty FROM Product WHERE ProdId = @ProductId", connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }
                    currentQuantity = (int)result;
                }

               
                if (currentQuantity >= quantityToSubtract)
                {
                  
                    int newQuantity = currentQuantity - quantityToSubtract;
                    using (SqlCommand cmd = new SqlCommand("UPDATE Product SET ProdQty = @NewQuantity WHERE ProdId = @ProductId", connection))
                    {
                        cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.ExecuteNonQuery();
                    }

                   
                    MessageBox.Show("Added to Cart & Stock updated successfully!", "Stock Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    SellingForm sell = new SellingForm();
                    sell.Show();
                    sell.getTable();
                    
                    
                }
                else
                {
                    MessageBox.Show("Not enough stock available!", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SellingForm sell = new SellingForm();
                    sell.Show();
                    sell.getTable();
                }
            }
        }
       
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
