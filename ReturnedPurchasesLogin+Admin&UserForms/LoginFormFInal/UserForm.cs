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
    public partial class UserForm : Form
    {
        string connectionString = "Server=DESKTOP-UF1C10G\\MSSQLSERVER01;Database=Nortwind_III1;Integrated Security=True";
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nortwind_III1DataSet.Returned_Purchases' table. You can move, or remove it, as needed.
            this.returned_PurchasesTableAdapter.Fill(this.nortwind_III1DataSet.Returned_Purchases);

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
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
