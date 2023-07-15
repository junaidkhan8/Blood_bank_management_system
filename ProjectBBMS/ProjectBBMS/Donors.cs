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

namespace ProjectBBMS
{
    public partial class Donors : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q1V8VLS" + "\\" + "SQLEXPRESS;Initial Catalog=BloodBankManagementSystem;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int donor_id = 0;
        string donors = "0";

        public Donors()
        {
            InitializeComponent();
            DisplayData();
        }

        private void ClearData()
        {
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            donor_id = 0;
        }
        private void DisplayData()
        {
            con.Open();
            adapt = new SqlDataAdapter("Select * from tbl_donor", con);
            DataTable dt1 = new DataTable();
            adapt.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Donors_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapt = new SqlDataAdapter("select * from tbl_donor where first_name like '" + textBox7.Text + "%'", con);
            DataTable dt = new DataTable();
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                cmd = new SqlCommand("insert into tbl_donor (first_name,last_name,contact,age,gender,blood_group,address) values (@fname,@lname,@contact,@age,@gender,@blood,@address)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@fname", textBox2.Text);
                cmd.Parameters.AddWithValue("@lname", textBox3.Text);
                cmd.Parameters.AddWithValue("@contact", textBox4.Text);
                cmd.Parameters.AddWithValue("@age", textBox5.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@blood", comboBox2.Text);
                cmd.Parameters.AddWithValue("@address", textBox6.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record entered successfully!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please provide all details.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                cmd = new SqlCommand("update tbl_donor set first_name = @fname, last_name = @lname, gender = @gender , age = @age, blood_group = @blood, contact = @contact, address = @address where donor_id = @id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@fname", textBox2.Text);
                cmd.Parameters.AddWithValue("@lname", textBox3.Text);
                cmd.Parameters.AddWithValue("@contact", textBox4.Text);
                cmd.Parameters.AddWithValue("@age", textBox5.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@blood", comboBox2.Text);
                cmd.Parameters.AddWithValue("@address", textBox6.Text);
                cmd.Parameters.AddWithValue("@id", donor_id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record updated successfully!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please select a record.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (donor_id != 0)
            {
                cmd = new SqlCommand("delete from tbl_donor where donor_id = @id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", donor_id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record deleted successfully!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please select a record.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            donor_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        public string countDonors(string blood_group)
        {
        con.Open();
        adapt = new SqlDataAdapter("select * from tbl_donor where blood_group = '" + blood_group + "'", con);
        DataTable dt2 = new DataTable();
        adapt.Fill(dt2);
        donors = dt2.Rows.Count.ToString();
        con.Close();
        return donors;
        }
    }
}
