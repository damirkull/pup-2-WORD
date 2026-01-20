namespace Words
{
    partial class FormPlay
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
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridViewField = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewField)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(169, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(135, 56);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "5 Слов";
            // 
            // dataGridViewField
            // 
            this.dataGridViewField.AllowUserToAddRows = false;
            this.dataGridViewField.AllowUserToDeleteRows = false;
            this.dataGridViewField.AllowUserToResizeColumns = false;
            this.dataGridViewField.AllowUserToResizeRows = false;
            this.dataGridViewField.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dataGridViewField.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewField.ColumnHeadersVisible = false;
            this.dataGridViewField.EnableHeadersVisualStyles = false;
            this.dataGridViewField.Location = new System.Drawing.Point(65, 70);
            this.dataGridViewField.MultiSelect = false;
            this.dataGridViewField.Name = "dataGridViewField";
            this.dataGridViewField.ReadOnly = true;
            this.dataGridViewField.RowHeadersVisible = false;
            this.dataGridViewField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewField.Size = new System.Drawing.Size(350, 350);
            this.dataGridViewField.TabIndex = 4;
            this.dataGridViewField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewField_KeyDown);
            this.dataGridViewField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewField_KeyPress);
            // 
            // FormPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.dataGridViewField);
            this.Controls.Add(this.labelName);
            this.Name = "FormPlay";
            this.Text = "5 Слов";
            this.Load += new System.EventHandler(this.FormPlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridViewField;
    }
}