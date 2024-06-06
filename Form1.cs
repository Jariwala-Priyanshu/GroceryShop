using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GroceryShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO shop (CustomerId, Category, p1, p2, p3, Category1, p4, p5, p6, vat, total) VALUES (@CustomerId, @Category, @P1, @P2, @P3, @Category1, @P4, @P5, @P6, @Vat, @Total)", con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Category", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@P1", textBox2.Text);
                    cmd.Parameters.AddWithValue("@P2", textBox3.Text);
                    cmd.Parameters.AddWithValue("@P3", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Category1", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@P4", textBox5.Text);
                    cmd.Parameters.AddWithValue("@P5", textBox6.Text);
                    cmd.Parameters.AddWithValue("@P6", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Vat", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Total", textBox9.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            BindData();
        }

        private void BindData()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM shop", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int customerId))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM shop WHERE CustomerId=@CustomerId", con))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record Deleted");
                BindData();
            }
            else
            {
                MessageBox.Show("Please enter a valid Customer ID.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
    }
}
