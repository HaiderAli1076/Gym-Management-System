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
    public partial class Staffform : Form

    {
        private int selectedStaffId = -1;

        public Staffform()
        {
            InitializeComponent();
            SetupGrid();
            LoadStaff();
        }
        private void SetupGrid()
        {
            dgvStaff.Columns.Add("Id", "ID");
            dgvStaff.Columns.Add("Name", "Name");
            dgvStaff.Columns.Add("Role", "Role");
            dgvStaff.Columns.Add("Contact", "Contact");
            dgvStaff.Columns.Add("Salary", "Salary");
            dgvStaff.Columns.Add("JoinDate", "Join Date");

            dgvStaff.Columns["Id"].Visible = false;
        }
        private void LoadStaff(string search = "")
        {
            dgvStaff.Rows.Clear();

            List<Staff> list = StaffRepository.GetAllStaff(search);
            foreach (Staff s in list)
            {
                dgvStaff.Rows.Add(
                    s.Id,
                    s.Name,
                    s.Role,
                    s.Contact,
                    s.Salary,
                    s.JoinDate
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            Staff s = new Staff
            {
                Name = txtName.Text.Trim(),
                Role = cmbRole.SelectedItem.ToString(),
                Contact = txtContact.Text.Trim(),
                Salary = decimal.Parse(txtSalary.Text.Trim()),
                JoinDate = DateTime.Now.ToString("yyyy-MM-dd")
            };

            if (StaffRepository.AddStaff(s))
            {
                MessageBox.Show("Staff added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadStaff();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Please select a staff member to update!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            Staff s = new Staff
            {
                Id = selectedStaffId,
                Name = txtName.Text.Trim(),
                Role = cmbRole.SelectedItem.ToString(),
                Contact = txtContact.Text.Trim(),
                Salary = decimal.Parse(txtSalary.Text.Trim()),
                JoinDate = DateTime.Now.ToString("yyyy-MM-dd")
            };

            if (StaffRepository.UpdateStaff(s))
            {
                MessageBox.Show("Staff updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadStaff();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Please select a staff member to delete!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this staff member?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (StaffRepository.DeleteStaff(selectedStaffId))
                {
                    MessageBox.Show("Staff deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadStaff();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStaff(txtSearch.Text.Trim());
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
                selectedStaffId = int.Parse(row.Cells["Id"].Value.ToString());
                txtName.Text = row.Cells["Name"].Value.ToString();
                cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();
                txtContact.Text = row.Cells["Contact"].Value.ToString();
                txtSalary.Text = row.Cells["Salary"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            cmbRole.SelectedIndex = -1;
            txtContact.Clear();
            txtSalary.Clear();
            selectedStaffId = -1;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please enter staff name!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtContact.Text.Trim()))
            {
                MessageBox.Show("Please enter contact number!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtSalary.Text.Trim()) ||
                !decimal.TryParse(txtSalary.Text.Trim(), out _))
            {
                MessageBox.Show("Please enter a valid salary!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
