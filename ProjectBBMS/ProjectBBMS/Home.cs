using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectBBMS
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        Donors dal = new Donors();

        private void Home_Load(object sender, EventArgs e)
        {
            allDonorCount();
        }

        public void allDonorCount()
        {
            label2.Text = dal.countDonors("A RhD positive (A+)");
            label23.Text = dal.countDonors("A RhD negative (A-)");
            label5.Text = dal.countDonors("B RhD positive (B+)");
            label20.Text = dal.countDonors("B RhD negative (B-)");
            label8.Text = dal.countDonors("O RhD positive (O+)");
            label17.Text = dal.countDonors("O RhD negative (O-)");
            label11.Text = dal.countDonors("AB RhD positive (AB+)");
            label14.Text = dal.countDonors("AB RhD negative (AB-)");
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void donorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Donors f2 = new Donors();
            f2.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Activated(object sender, EventArgs e)
        {
            allDonorCount();
        }
    }
}
