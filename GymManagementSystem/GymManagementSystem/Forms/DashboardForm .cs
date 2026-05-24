using System;
using System.Windows.Forms;
using GymManagementSystem.Database;

namespace GymManagementSystem.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {LoginForm.LoggedInUser}!";
        }

        // FIX 2: btnEquipment correctly opens EquipmentForm
        private void btnEquipment_Click(object sender, EventArgs e)
        {
            EquipmentForm equipmentForm = new EquipmentForm();
            equipmentForm.Show();
        }

        // FIX 3: btnMembers (labeled "Members") now correctly opens MemberForm
        private void btnMembers_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm();
            memberForm.Show();
        }

        // FIX 4: btnSessions (labeled "Staff") now correctly opens Staffform
        private void btnSessions_Click(object sender, EventArgs e)
        {
            Staffform staffForm = new Staffform();
            staffForm.Show();
        }

        // Logout with confirmation
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        // Invoice and Reports — placeholder stubs (buttons exist in designer, no form yet)
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Invoice module coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reports module coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
