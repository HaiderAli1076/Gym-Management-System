using GymManagementSystem.Database;
using GymManagementSystem.Models;
using System;
using System.Collections;
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
    public partial class EquipmentForm : Form    
    {
        private int selectedEquipmentId = -1;
        public EquipmentForm()
        {
            InitializeComponent();
            LoadEquipment();
            SetupGrid();
        }
        private void SetupGrid()
        {
            dgvEquipment.Columns.Add("Id", "ID");
            dgvEquipment.Columns.Add("EquipmentName", "Equipment Name");
            dgvEquipment.Columns.Add("Category", "Category");
            dgvEquipment.Columns.Add("FeePerSession", "Fee Per Session");
            dgvEquipment.Columns.Add("Status", "Status");

            dgvEquipment.Columns["Id"].Visible = false;
        }
        private void LoadEquipment(string search = "")
        {
            dgvEquipment.Rows.Clear();

            List<Equipment> list = EquipmentRepository.GetAllEquipment(search);

            foreach (Equipment eq in list)
            {
                dgvEquipment.Rows.Add(
                    eq.Id,
                    eq.EquipmentName,
                    eq.Category,
                    eq.FeePerSession,
                    eq.Status
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            Equipment eq = new Equipment
            {
                EquipmentName = txtEquipmentName.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                FeePerSession = decimal.Parse(txtFee.Text.Trim()),
                Status = cmbStatus.SelectedItem.ToString()
            };

            if (EquipmentRepository.AddEquipment(eq))
            {
                MessageBox.Show("Equipment added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadEquipment();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentId == -1)
            {
                MessageBox.Show("Please select equipment to update!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            Equipment eq = new Equipment
            {
                Id = selectedEquipmentId,
                EquipmentName = txtEquipmentName.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                FeePerSession = decimal.Parse(txtFee.Text.Trim()),
                Status = cmbStatus.SelectedItem.ToString()
            };

            if (EquipmentRepository.UpdateEquipment(eq))
            {
                MessageBox.Show("Equipment updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadEquipment();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentId == -1)
            {
                MessageBox.Show("Please select equipment to delete!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this equipment?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (EquipmentRepository.DeleteEquipment(selectedEquipmentId))
                {
                    MessageBox.Show("Equipment deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadEquipment();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadEquipment(txtSearch.Text.Trim());
        }

        private void dgvEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEquipment.Rows[e.RowIndex];
                selectedEquipmentId = int.Parse(row.Cells["Id"].Value.ToString());
                txtEquipmentName.Text = row.Cells["EquipmentName"].Value.ToString();
                cmbCategory.SelectedItem = row.Cells["Category"].Value.ToString();
                txtFee.Text = row.Cells["FeePerSession"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            {
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtEquipmentName.Clear();
            cmbCategory.SelectedIndex = -1;
            txtFee.Clear();
            cmbStatus.SelectedIndex = -1;
            selectedEquipmentId = -1;
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtEquipmentName.Text.Trim()))
            {
                MessageBox.Show("Please enter equipment name!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtFee.Text.Trim()) || !decimal.TryParse(txtFee.Text.Trim(), out _))
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
    }
}
    

