using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Crud_Betamart_Fachmi
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ukk\oop\Crud_Betamart_Fachmi\MyDb.accdb;Persist Security Info=False;";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    this.barangBetaMartTableAdapter.Fill(this.appData.BarangBetaMart);
                    barangBetaMartBindingSource.DataSource = this.appData.BarangBetaMart;
                    //dataGridView.DataSource = barangBetaMartBindingSource;
                }
                else
                {
                    var query = from o in this.appData.BarangBetaMart
                                where o.NamaBarang.Contains(txtSearch.Text) || o.JenisBarang == txtSearch.Text || o.JumlahBarang == txtSearch.Text || o.HargaBarang.Contains(txtSearch.Text)
                                select o;
                    barangBetaMartBindingSource.DataSource = query.ToList();
                    //dataGridView.DataSource = query.ToList();
                }
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Anda Yakin Ingin Menghapus ini ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    barangBetaMartBindingSource.RemoveCurrent();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtNamaBarang.Focus();
                this.appData.BarangBetaMart.AddBarangBetaMartRow(this.appData.BarangBetaMart.NewBarangBetaMartRow());
                barangBetaMartBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                barangBetaMartBindingSource.ResetBindings(false);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtNamaBarang.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                barangBetaMartBindingSource.EndEdit();
                barangBetaMartTableAdapter.Update(this.appData.BarangBetaMart);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                barangBetaMartBindingSource.ResetBindings(false);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.BarangBetaMart' table. You can move, or remove it, as needed.
            this.barangBetaMartTableAdapter.Fill(this.appData.BarangBetaMart);
            barangBetaMartBindingSource.DataSource = this.appData.BarangBetaMart;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

      


        private void TxtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin Ingin Menghapus Produk Ini?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                barangBetaMartBindingSource.RemoveCurrent();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
