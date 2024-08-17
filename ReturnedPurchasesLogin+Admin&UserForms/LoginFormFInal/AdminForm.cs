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
    public partial class AdminForm : Form
    {
        string connectionString = "Server=DESKTOP-UF1C10G\\MSSQLSERVER01;Database=Nortwind_III1;Integrated Security=True";
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nortwind_III1DataSet1.Returned_Purchases' table. You can move, or remove it, as needed.
            this.returned_PurchasesTableAdapter.Fill(this.nortwind_III1DataSet1.Returned_Purchases);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string updateQuery = "SELECT * FROM Returned_Purchases";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDataAdapter SDA = new SqlDataAdapter(updateQuery, conn);
                DataSet DS = new System.Data.DataSet();
                SDA.Fill(DS, "Returned_Purchases");
                dataGridView1.DataSource = DS.Tables[0];

                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Returned_Purchases(Purchase_Tag, Purchase_Name, Purchase_Category, Return_Cause) VALUES(@Tag_Value, @Name_Value, @Category_Value, @Cause_Value)";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@Tag_Value", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Name_Value", textBox2.Text);
                        cmd.Parameters.AddWithValue("Category_Value", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Cause_Value", textBox4.Text);

                        int affectedRows = cmd.ExecuteNonQuery();

                        MessageBox.Show($"{affectedRows} row(s) affected");

                        conn.Close();

                    }

                    else if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""){
                        MessageBox.Show("One or more input fields are empty. Please enter the desired data into the input field(s)");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string insertQuery = "UPDATE Returned_Purchases SET Purchase_Tag = @Tag_Value , Purchase_Name = @Name_Value, Purchase_Category = @Category_Value, Return_Cause = @Cause_Value WHERE Purchase_Tag = @Tag_Value";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@Tag_Value", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Name_Value", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Category_Value", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Cause_Value", textBox4.Text);

                        int affectedRows = cmd.ExecuteNonQuery();

                        MessageBox.Show($"{affectedRows} row(s) affected");

                        conn.Close();

                    }

                    else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                    {
                        MessageBox.Show("One or more input fields are empty. Please enter the desired data into the input field(s)");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string insertQuery = "DELETE Returned_Purchases WHERE Purchase_Tag = @Tag_Value";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    if (textBox1.Text != "")
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@Tag_Value", textBox1.Text);
                        

                        int affectedRows = cmd.ExecuteNonQuery();

                        MessageBox.Show($"{affectedRows} row(s) affected");

                        conn.Close();

                    }

                    else if (textBox1.Text == "")
                    {
                        MessageBox.Show("The tag input field is empty. Please enter the desired data into the tag input field");
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT Purchase_Tag, Purchase_Name, Purchase_Category, Return_Cause FROM Returned_Purchases WHERE Purchase_Tag = @Tag_Value";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(searchQuery, conn))
                {
                    if (textBox1.Text != "")
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@Tag_Value", textBox1.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                string tagValue = reader["Purchase_Tag"].ToString();
                                string nameValue = reader["Purchase_Name"].ToString();
                                string categoryValue = reader["Purchase_Category"].ToString();
                                string causeValue = reader["Return_Cause"].ToString();

                                MessageBox.Show("Result(s) found.");
                                MessageBox.Show($"Tag: {tagValue}, Name: {nameValue}, Category: {categoryValue}, Cause: {causeValue}");
                            }
                            else
                            {
                                MessageBox.Show("No results found.");
                            }
                        }
                    }
                }
            }
        }
    }
}
