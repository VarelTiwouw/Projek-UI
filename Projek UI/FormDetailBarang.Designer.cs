namespace Projek_UI
{
    partial class FormDetailBarang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailBarang));
            this.dataGridViewDetailBarang = new System.Windows.Forms.DataGridView();
            this.btn_kembali = new System.Windows.Forms.Button();
            this.lbl_total = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetailBarang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDetailBarang
            // 
            this.dataGridViewDetailBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDetailBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetailBarang.Location = new System.Drawing.Point(12, 52);
            this.dataGridViewDetailBarang.Name = "dataGridViewDetailBarang";
            this.dataGridViewDetailBarang.RowHeadersWidth = 51;
            this.dataGridViewDetailBarang.RowTemplate.Height = 24;
            this.dataGridViewDetailBarang.Size = new System.Drawing.Size(776, 361);
            this.dataGridViewDetailBarang.TabIndex = 0;
            this.dataGridViewDetailBarang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetailBarang_CellContentClick);
            // 
            // btn_kembali
            // 
            this.btn_kembali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kembali.Image = ((System.Drawing.Image)(resources.GetObject("btn_kembali.Image")));
            this.btn_kembali.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kembali.Location = new System.Drawing.Point(684, 3);
            this.btn_kembali.Name = "btn_kembali";
            this.btn_kembali.Size = new System.Drawing.Size(104, 43);
            this.btn_kembali.TabIndex = 1;
            this.btn_kembali.Text = "Kembali\r\n";
            this.btn_kembali.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kembali.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_kembali.UseVisualStyleBackColor = true;
            this.btn_kembali.Click += new System.EventHandler(this.btn_kembali_Click);
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(6, 14);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(50, 29);
            this.lbl_total.TabIndex = 3;
            this.lbl_total.Text = "Rp.";
            this.lbl_total.Click += new System.EventHandler(this.lbl_total_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbl_total);
            this.groupBox1.Location = new System.Drawing.Point(450, 413);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // FormDetailBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_kembali);
            this.Controls.Add(this.dataGridViewDetailBarang);
            this.Name = "FormDetailBarang";
            this.Text = "FormDetailBarang";
            this.Load += new System.EventHandler(this.FormDetailBarang_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetailBarang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDetailBarang;
        private System.Windows.Forms.Button btn_kembali;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}