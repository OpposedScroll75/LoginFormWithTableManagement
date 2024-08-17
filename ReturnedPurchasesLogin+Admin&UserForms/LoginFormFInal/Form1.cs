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

namespace LoginFormFInal
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=DESKTOP-UF1C10G\\MSSQLSERVER01;Database=Login_Example;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Input field(s) empty. Please type your log in data into the input field(s)");
            }

            string loginQuery = "SELECT userRole FROM Login WHERE userName =  @userName_Value AND userPassword = @userPassword_Value";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(loginQuery, conn))
                {
                    try
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@userName_Value", textBox1.Text);
                        cmd.Parameters.AddWithValue("@userPassword_Value", textBox2.Text);

                        object roleObject = cmd.ExecuteScalar();

                        if (roleObject == null) {
                            MessageBox.Show("Invalid login info. Please try again");

                        }
                        string role = roleObject.ToString();

                        if (role == "admin")
                        {
                            MessageBox.Show($"Login successful. Welcome back, {role}");
                            AdminForm adminForm = new AdminForm();
                            this.Hide();
                            adminForm.Show();
                        }

                        else if (role == "user")
                        {
                            MessageBox.Show($"Login successful. Welcome back, {role}");
                            UserForm userForm = new UserForm();
                            this.Hide();
                            userForm.Show();
                        }

                        

                        conn.Close();
                    }

                    catch
                    {
                        MessageBox.Show("An error occured. Please try again");
                    }
                }
            }
            }
        }
    }
