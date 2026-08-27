using Mini_Market_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Market_Management_System
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (TextBox_username.Text == "admin" && TextBox_pass.Text == "1234")
            {
                CustomerForm customer = new CustomerForm();
                customer.Show();
                this.Hide();
                customer.getTable();
            }
            else {
                MessageBox.Show("Wrong Admin ID or Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
