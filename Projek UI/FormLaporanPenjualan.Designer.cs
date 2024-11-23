namespace Projek_UI
{
    partial class FormLaporanPenjualan
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
            this.dataGridViewLaporanPenjualan = new System.Windows.Forms.DataGridView();
            this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLaporanPenjualan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLaporanPenjualan
            // 
            this.dataGridViewLaporanPenjualan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLaporanPenjualan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLaporanPenjualan.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewLaporanPenjualan.Name = "dataGridViewLaporanPenjualan";
            this.dataGridViewLaporanPenjualan.RowHeadersWidth = 51;
            this.dataGridViewLaporanPenjualan.RowTemplate.Height = 24;
            this.dataGridViewLaporanPenjualan.Size = new System.Drawing.Size(851, 461);
            this.dataGridViewLaporanPenjualan.TabIndex = 1;
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(12, 12);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerTanggal.TabIndex = 2;
            this.dateTimePickerTanggal.ValueChanged += new System.EventHandler(this.dateTimePickerTanggal_ValueChanged);
            // 
            // FormLaporanPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 513);
            this.Controls.Add(this.dateTimePickerTanggal);
            this.Controls.Add(this.dataGridViewLaporanPenjualan);
            this.Name = "FormLaporanPenjualan";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.FormLaporanPenjualan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLaporanPenjualan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewLaporanPenjualan;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
    }
}