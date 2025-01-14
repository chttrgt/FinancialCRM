using FinancialCRM.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCRM
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmDBEntities db = new FinancialCrmDBEntities();

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            var ziraatBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(x => x.BankBalance).FirstOrDefault();
            var vakifBalance = db.Banks.Where(x => x.BankTitle == "VakıfBank").Select(x => x.BankBalance).FirstOrDefault();
            var isBanksiBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(x => x.BankBalance).FirstOrDefault();

            lblIsBankBalance.Text = isBanksiBalance.ToString() + " ₺";
            lblVakifBalance.Text = vakifBalance.ToString() + " ₺";
            lblZiraatBalance.Text = ziraatBalance.ToString() + " ₺";

            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Skip(1).Take(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Skip(2).Take(1).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Skip(3).Take(1).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Skip(4).Take(1).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Hide();
        }
    }
}
