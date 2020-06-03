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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=tutorial;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
            displaydata();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tutorialDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.tutorialDataSet.Employee);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into Employee values('" + txtName.Text + "','" + txtEmail.Text + "','" + txtDesignation.Text + "','" + txtSalary.Text + "')",con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data is Saved!");
            con.Close();
            displaydata();
            Clear();
        }

        public void displaydata()
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from Employee", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void Clear()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtDesignation.Text = "";
            txtSalary.Text = "";
        }

    }
}
