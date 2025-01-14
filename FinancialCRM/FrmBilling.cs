using FinancialCRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCRM
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        FinancialCrmDBEntities db = new FinancialCrmDBEntities();

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        void FormClear()
        {
            txtPaymentId.Text = "";
            txtTitle.Text = "";
            txtAmount.Text = "";
            txtPeriod.Text = "";
        }

        private void btnPaymentList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnNewPayment_Click(object sender, EventArgs e)
        {

            string billTitle = txtTitle.Text;
            decimal billAmount = Convert.ToDecimal(txtAmount.Text);
            string billPeriod = txtPeriod.Text;

            Bills bill = new Bills();
            bill.BillTitle = billTitle;
            bill.BillAmount = billAmount;
            bill.BillPeriod = billPeriod;

            db.Bills.Add(bill);
            db.SaveChanges();
            MessageBox.Show("Bill added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormClear();

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtPaymentId.Text);
            var value = db.Bills.Find(id);
            db.Bills.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Bill deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormClear();

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtPaymentId.Text);
            var value = db.Bills.Find(id);
            value.BillTitle = txtTitle.Text;
            value.BillAmount = Convert.ToDecimal(txtAmount.Text);
            value.BillPeriod = txtPeriod.Text;
            db.SaveChanges();
            MessageBox.Show("Bill updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormClear();

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtPaymentId.Text = row.Cells["BillId"].Value?.ToString();
                txtTitle.Text = row.Cells["BillTitle"].Value?.ToString();
                txtAmount.Text = row.Cells["BillAmount"].Value?.ToString();
                txtPeriod.Text = row.Cells["BillPeriod"].Value?.ToString();

            }



        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }
    }
}
