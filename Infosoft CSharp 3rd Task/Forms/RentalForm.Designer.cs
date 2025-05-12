﻿namespace Infosoft_CSharp_3rd_Task
{
    partial class RentalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVideo = new System.Windows.Forms.ComboBox();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pictureBoxShutdown = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShutdown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(165, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Costumer Name:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Items.AddRange(new object[] {
            "VCD",
            "DVD"});
            this.cmbCustomer.Location = new System.Drawing.Point(342, 154);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(203, 30);
            this.cmbCustomer.TabIndex = 19;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(165, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Video List:";
            // 
            // cmbVideo
            // 
            this.cmbVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVideo.FormattingEnabled = true;
            this.cmbVideo.Items.AddRange(new object[] {
            "VCD",
            "DVD"});
            this.cmbVideo.Location = new System.Drawing.Point(342, 193);
            this.cmbVideo.Name = "cmbVideo";
            this.cmbVideo.Size = new System.Drawing.Size(203, 30);
            this.cmbVideo.TabIndex = 21;
            this.cmbVideo.SelectedIndexChanged += new System.EventHandler(this.cmbVideo_SelectedIndexChanged_1);
            // 
            // numDays
            // 
            this.numDays.Location = new System.Drawing.Point(324, 235);
            this.numDays.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(35, 20);
            this.numDays.TabIndex = 23;
            this.numDays.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(165, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Rental Days:";
            // 
            // dgvRentals
            // 
            this.dgvRentals.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentals.Location = new System.Drawing.Point(170, 342);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.Size = new System.Drawing.Size(725, 259);
            this.dgvRentals.TabIndex = 25;
            this.dgvRentals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRentals_CellContentClick);
            // 
            // btnRent
            // 
            this.btnRent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRent.Font = new System.Drawing.Font("Elephant", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRent.Location = new System.Drawing.Point(170, 278);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(122, 42);
            this.btnRent.TabIndex = 26;
            this.btnRent.Text = "Rent";
            this.btnRent.UseVisualStyleBackColor = false;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturn.Font = new System.Drawing.Font("Elephant", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(371, 278);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(122, 42);
            this.btnReturn.TabIndex = 27;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEdit.Font = new System.Drawing.Font("Elephant", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(572, 278);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(122, 42);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "Edit Rental";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Font = new System.Drawing.Font("Elephant", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(773, 278);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 42);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete Rental";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(678, 169);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(217, 29);
            this.txtSearch.TabIndex = 30;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(588, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Search:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Font = new System.Drawing.Font("Elephant", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(714, 204);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 42);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pictureBoxShutdown
            // 
            this.pictureBoxShutdown.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxShutdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxShutdown.Location = new System.Drawing.Point(934, -1);
            this.pictureBoxShutdown.Name = "pictureBoxShutdown";
            this.pictureBoxShutdown.Size = new System.Drawing.Size(111, 59);
            this.pictureBoxShutdown.TabIndex = 33;
            this.pictureBoxShutdown.TabStop = false;
            this.pictureBoxShutdown.Click += new System.EventHandler(this.pictureBoxShutdown_Click);
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1031, 641);
            this.Controls.Add(this.pictureBoxShutdown);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.dgvRentals);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numDays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVideo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RentalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentalForm";
            this.Load += new System.EventHandler(this.RentalForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShutdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVideo;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBoxShutdown;
    }
}