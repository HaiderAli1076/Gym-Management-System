namespace GymManagementSystem.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));

            this.panel1      = new System.Windows.Forms.Panel();
            this.panel2      = new System.Windows.Forms.Panel();
            this.lblWelcome  = new System.Windows.Forms.Label();
            // 4 active dashboard buttons
            this.btnEquipment = new System.Windows.Forms.Button();
            this.btnMembers   = new System.Windows.Forms.Button();
            this.btnSessions  = new System.Windows.Forms.Button();  // opens Staff
            this.btnLogout    = new System.Windows.Forms.Button();
            // Placeholder buttons (no form yet)
            this.btnInvoice   = new System.Windows.Forms.Button();
            this.btnReports   = new System.Windows.Forms.Button();

            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();

            // panel1
            this.panel1.BackColor   = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location    = new System.Drawing.Point(110, 12);
            this.panel1.Name        = "panel1";
            this.panel1.Size        = new System.Drawing.Size(750, 500);
            this.panel1.TabIndex    = 0;

            // panel2
            this.panel2.BackColor   = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblWelcome);
            this.panel2.Controls.Add(this.btnEquipment);
            this.panel2.Controls.Add(this.btnMembers);
            this.panel2.Controls.Add(this.btnSessions);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnInvoice);
            this.panel2.Controls.Add(this.btnReports);
            this.panel2.Location    = new System.Drawing.Point(3, 3);
            this.panel2.Name        = "panel2";
            this.panel2.Size        = new System.Drawing.Size(740, 490);
            this.panel2.TabIndex    = 1;

            // lblWelcome
            this.lblWelcome.AutoSize  = true;
            this.lblWelcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI", 16F,
                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblWelcome.Location  = new System.Drawing.Point(270, 10);
            this.lblWelcome.Name      = "lblWelcome";
            this.lblWelcome.Size      = new System.Drawing.Size(200, 45);
            this.lblWelcome.TabIndex  = 0;
            this.lblWelcome.Text      = "Welcome";

            // ── ROW 1 ─────────────────────────────────────────────────────────
            // btnEquipment — opens EquipmentForm
            this.btnEquipment.BackColor          = System.Drawing.Color.FromArgb(255, 192, 255);
            this.btnEquipment.Font               = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipment.ForeColor          = System.Drawing.Color.FromArgb(80, 0, 0, 0);
            this.btnEquipment.Location           = new System.Drawing.Point(4, 67);
            this.btnEquipment.Name               = "btnEquipment";
            this.btnEquipment.Size               = new System.Drawing.Size(210, 149);
            this.btnEquipment.TabIndex           = 2;
            this.btnEquipment.Text               = "Equipment";
            this.btnEquipment.UseVisualStyleBackColor = false;
            this.btnEquipment.Click             += new System.EventHandler(this.btnEquipment_Click);

            // btnMembers — FIX: opens MemberForm (was opening Staffform)
            this.btnMembers.BackColor          = System.Drawing.Color.FromArgb(255, 192, 255);
            this.btnMembers.Font               = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold);
            this.btnMembers.ForeColor          = System.Drawing.Color.FromArgb(80, 0, 0, 0);
            this.btnMembers.Location           = new System.Drawing.Point(268, 67);
            this.btnMembers.Name               = "btnMembers";
            this.btnMembers.Size               = new System.Drawing.Size(210, 149);
            this.btnMembers.TabIndex           = 3;
            this.btnMembers.Text               = "Members";           // FIX: label matches function
            this.btnMembers.UseVisualStyleBackColor = false;
            this.btnMembers.Click             += new System.EventHandler(this.btnMembers_Click);

            // btnSessions — FIX: opens Staffform (was empty/dead)
            this.btnSessions.BackColor          = System.Drawing.Color.FromArgb(255, 192, 255);
            this.btnSessions.Font               = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold);
            this.btnSessions.ForeColor          = System.Drawing.Color.FromArgb(80, 0, 0, 0);
            this.btnSessions.Location           = new System.Drawing.Point(524, 67);
            this.btnSessions.Name               = "btnSessions";
            this.btnSessions.Size               = new System.Drawing.Size(210, 149);
            this.btnSessions.TabIndex           = 4;
            this.btnSessions.Text               = "Staff";            // FIX: label matches function
            this.btnSessions.UseVisualStyleBackColor = false;
            this.btnSessions.Click             += new System.EventHandler(this.btnSessions_Click);

            // ── ROW 2 ─────────────────────────────────────────────────────────
            // btnInvoice — placeholder
            this.btnInvoice.BackColor          = System.Drawing.Color.FromArgb(255, 192, 255);
            this.btnInvoice.Font               = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold);
            this.btnInvoice.ForeColor          = System.Drawing.Color.FromArgb(80, 0, 0, 0);
            this.btnInvoice.Location           = new System.Drawing.Point(4, 282);
            this.btnInvoice.Name               = "btnInvoice";
            this.btnInvoice.Size               = new System.Drawing.Size(210, 149);
            this.btnInvoice.TabIndex           = 5;
            this.btnInvoice.Text               = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = false;
            this.btnInvoice.Click             += new System.EventHandler(this.btnInvoice_Click);

            // btnReports — placeholder
            this.btnReports.BackColor          = System.Drawing.Color.FromArgb(255, 192, 255);
            this.btnReports.Font               = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor          = System.Drawing.Color.FromArgb(80, 0, 0, 0);
            this.btnReports.Location           = new System.Drawing.Point(268, 282);
            this.btnReports.Name               = "btnReports";
            this.btnReports.Size               = new System.Drawing.Size(210, 149);
            this.btnReports.TabIndex           = 6;
            this.btnReports.Text               = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click             += new System.EventHandler(this.btnReports_Click);

            // btnLogout — logout with confirmation
            this.btnLogout.BackColor          = System.Drawing.Color.FromArgb(255, 192, 255);
            this.btnLogout.Font               = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor          = System.Drawing.Color.FromArgb(80, 0, 0, 0);
            this.btnLogout.Location           = new System.Drawing.Point(524, 282);
            this.btnLogout.Name               = "btnLogout";
            this.btnLogout.Size               = new System.Drawing.Size(210, 149);
            this.btnLogout.TabIndex           = 7;
            this.btnLogout.Text               = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click             += new System.EventHandler(this.btnLogout_Click);

            // ── DashboardForm ─────────────────────────────────────────────────
            this.AutoScaleDimensions       = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode             = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage           = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout     = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize                = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered            = true;
            this.Name                      = "DashboardForm";
            this.Text                      = "Gym Management System — Dashboard";

            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel  panel1;
        private System.Windows.Forms.Panel  panel2;
        private System.Windows.Forms.Label  lblWelcome;
        private System.Windows.Forms.Button btnEquipment;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnSessions;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnReports;
    }
}
