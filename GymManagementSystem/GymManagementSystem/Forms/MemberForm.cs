using GymManagementSystem.Database;
using GymManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem.Forms
{
    public partial class MemberForm : Form
    {
        private int selectedMemberId = -1;

        public MemberForm()
        {
            InitializeComponent();
            SetupGrid();
            LoadMembers();
        }

        private void SetupGrid()
        {
            dgvMembers.Columns.Add("Id", "ID");
            dgvMembers.Columns.Add("Name", "Name");
            dgvMembers.Columns.Add("Phone", "Phone");
            dgvMembers.Columns.Add("MembershipType", "Membership");
            dgvMembers.Columns.Add("Fee", "Fee (Rs)");
            dgvMembers.Columns.Add("JoinDate", "Join Date");
            dgvMembers.Columns.Add("ExpiryDate", "Expiry Date");
            dgvMembers.Columns.Add("Status", "Status");

            dgvMembers.Columns["Id"].Visible = false;
        }

        private void LoadMembers(string search = "")
        {
            dgvMembers.Rows.Clear();
            List<Member> list = MemberRepository.GetAllMembers(search);
            foreach (Member m in list)
            {
                dgvMembers.Rows.Add(
                    m.Id,
                    m.Name,
                    m.Phone,
                    m.MembershipType,
                    m.Fee,
                    m.JoinDate,
                    m.ExpiryDate,
                    m.Status
                );
            }
        }

        private string CalculateExpiry(string type, string joinDate)
        {
            DateTime join = DateTime.Parse(joinDate);
            switch (type)
            {
                case "Monthly": return join.AddMonths(1).ToString("yyyy-MM-dd");
                case "Quarterly": return join.AddMonths(3).ToString("yyyy-MM-dd");
                case "Yearly": return join.AddYears(1).ToString("yyyy-MM-dd");
                default: return join.AddMonths(1).ToString("yyyy-MM-dd");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string joinDate = DateTime.Now.ToString("yyyy-MM-dd");
            string memberType = cmbMembershipType.SelectedItem.ToString();

            Member m = new Member
            {
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                MembershipType = memberType,
                Fee = decimal.Parse(txtFee.Text.Trim()),
                JoinDate = joinDate,
                ExpiryDate = CalculateExpiry(memberType, joinDate),
                Status = "Active"
            };

            if (MemberRepository.AddMember(m))
            {
                MessageBox.Show("Member added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadMembers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == -1)
            {
                MessageBox.Show("Please select a member to update!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            string memberType = cmbMembershipType.SelectedItem.ToString();
            string joinDate = DateTime.Now.ToString("yyyy-MM-dd");

            Member m = new Member
            {
                Id = selectedMemberId,
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                MembershipType = memberType,
                Fee = decimal.Parse(txtFee.Text.Trim()),
                JoinDate = joinDate,
                ExpiryDate = CalculateExpiry(memberType, joinDate),
                Status = cmbStatus.SelectedItem.ToString()
            };

            if (MemberRepository.UpdateMember(m))
            {
                MessageBox.Show("Member updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadMembers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == -1)
            {
                MessageBox.Show("Please select a member to delete!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this member?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (MemberRepository.DeleteMember(selectedMemberId))
                {
                    MessageBox.Show("Member deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadMembers();
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMembers(txtSearch.Text.Trim());
        }
    

     private void ClearFields()
        {
            txtName.Clear();
            txtPhone.Clear();
            cmbMembershipType.SelectedIndex = -1;
            txtFee.Clear();
            cmbStatus.SelectedIndex = -1;
            selectedMemberId = -1;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please enter member name!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Please enter phone number!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbMembershipType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select membership type!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtFee.Text.Trim()) ||
                !decimal.TryParse(txtFee.Text.Trim(), out _))
            {
                MessageBox.Show("Please enter a valid fee!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
                selectedMemberId = int.Parse(row.Cells["Id"].Value.ToString());
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                cmbMembershipType.SelectedItem = row.Cells["MembershipType"].Value.ToString();
                txtFee.Text = row.Cells["Fee"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            }
        }
    }  // ✅ ONE closing brace for class
}      // ✅ ONE closing brace for namespace