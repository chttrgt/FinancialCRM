using FinancialCRM.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCRM
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private readonly FinancialCrmDBEntities _db = new FinancialCrmDBEntities();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowMessage("Please fill in all fields", MessageBoxIcon.Warning);
                HighlightInvalidFields(username, password);
                return;
            }

            if (!ValidateInput(username, password)) return;

            var user = _db.Users
                .FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password);

            if (user != null)
            {
                OpenDashboard();
            }
            else
            {
                ShowMessage("Invalid username or password", MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
        }

        private void HighlightInvalidFields(string username, string password)
        {
            txtUsername.BackColor = string.IsNullOrWhiteSpace(username) ? Color.Crimson : Color.White;
            txtPassword.BackColor = string.IsNullOrWhiteSpace(password) ? Color.Crimson : Color.White;
        }

        private bool ValidateInput(string username, string password)
        {
            bool isValid = true;

            if (username.Length < 3)
            {
                txtUsername.BackColor = Color.Crimson;
                ShowMessage("Username must be at least 3 characters long", MessageBoxIcon.Warning);
                isValid = false;
            }

            if (password.Length < 6)
            {
                txtPassword.BackColor = Color.Crimson;
                ShowMessage("Password must be at least 6 characters long", MessageBoxIcon.Warning);
                isValid = false;
            }

            return isValid;
        }

        private void OpenDashboard()
        {
            var frmDashboard = new FrmDashBoard();
            frmDashboard.Show();
            Hide();
        }

        private void ShowMessage(string message, MessageBoxIcon icon)
        {
            MessageBox.Show(message, "Notification", MessageBoxButtons.OK, icon);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = txtUsername.Text.Length < 3 ? Color.Crimson : Color.White;

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.BackColor = txtPassword.Text.Length < 6 ? Color.Crimson : Color.White;
            pbxEyeOn.BackColor = txtPassword.Text.Length < 6 ? Color.Crimson : Color.White;
            pbxEyeOff.BackColor = txtPassword.Text.Length < 6 ? Color.Crimson : Color.White;
            UpdatePasswordVisibilityControls();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
            pbxEyeOn.Visible = true;
            pbxEyeOff.Visible = false;
            UpdatePasswordVisibilityControls();
        }

        private void pbxEyeOn_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(false);
        }

        private void pbxEyeOff_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(true);
        }

        private void TogglePasswordVisibility(bool isHidden)
        {
            pbxEyeOn.Visible = isHidden;
            pbxEyeOff.Visible = !isHidden;
            txtPassword.PasswordChar = isHidden ? '●' : '\0';
        }

        private void UpdatePasswordVisibilityControls()
        {
            bool hasPassword = !string.IsNullOrEmpty(txtPassword.Text);
            pbxEyeOn.Enabled = hasPassword;
            pbxEyeOff.Enabled = hasPassword;

        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
