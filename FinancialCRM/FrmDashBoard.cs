using FinancialCRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCRM
{
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }

        FinancialCrmDBEntities db = new FinancialCrmDBEntities();
        int count = 0;

        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance?.ToString("N", new CultureInfo("tr-TR")) + " ₺";

            var lastIncomingTransfer = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(x => x.Amount).FirstOrDefault();
            var lastIncomingTransferDescription = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(x => x.Description).FirstOrDefault();
            lblLastIncomingTransfer.Text = lastIncomingTransfer?.ToString("N", new CultureInfo("tr-TR")) + " ₺";
            lblLastIncomingTransferText.Text = lastIncomingTransferDescription;

            // Chart-1
            var bankData = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series1 = chart1.Series.Add("Bankalar");
            foreach (var item in bankData)
            {
                series1.Points.AddXY(item.BankTitle, item.BankBalance);
            }


            // Chart-2
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();

            // Toplam faturaların miktarını hesapla
            decimal totalAmount = (decimal)billData.Sum(x => x.BillAmount);

            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            foreach (var item in billData)
            {
                // Yeni bir DataPoint oluştur ve veriyi ekle
                var point = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                point.SetValueXY(item.BillTitle, item.BillAmount);

                // Yüzde hesaplama
                decimal percentage = (decimal)(item.BillAmount / totalAmount) * 100;

                // Etiket ve başlık ayarlarını yap
                point.Label = point.Label = $"{percentage:F2}%\n({item.BillAmount:N} ₺)"; ; // Dilimde yüzdelik değer
                point.LegendText = item.BillTitle; // Legend kısmında başlık

                // Seri içine DataPoint'i ekle
                series2.Points.Add(point);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 4 == 1)
            {
                var elektrikFaturasi = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = elektrikFaturasi?.ToString("N", new CultureInfo("tr-TR")) + " ₺";
            }

            if (count % 4 == 2)
            {
                var dogalgazFaturasi = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = dogalgazFaturasi?.ToString("N", new CultureInfo("tr-TR")) + " ₺";
            }

            if (count % 4 == 3)
            {
                var suFaturasi = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = suFaturasi?.ToString("N", new CultureInfo("tr-TR")) + " ₺";
            }

            if (count % 4 == 0)
            {
                var internetFaturasi = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "İnternet Faturası";
                lblBillAmount.Text = internetFaturasi?.ToString("N", new CultureInfo("tr-TR")) + " ₺";
            }
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Hide();
        }
    }
}
