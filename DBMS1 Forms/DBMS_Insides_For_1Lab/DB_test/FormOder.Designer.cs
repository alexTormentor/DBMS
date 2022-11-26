namespace DB_test
{
    partial class FormOder
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
            this.gridChassis = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboMech = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCore = new System.Windows.Forms.ComboBox();
            this.btnChassis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridChassis)).BeginInit();
            this.SuspendLayout();
            // 
            // gridChassis
            // 
            this.gridChassis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChassis.Location = new System.Drawing.Point(9, 23);
            this.gridChassis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridChassis.Name = "gridChassis";
            this.gridChassis.RowHeadersWidth = 51;
            this.gridChassis.RowTemplate.Height = 24;
            this.gridChassis.Size = new System.Drawing.Size(582, 162);
            this.gridChassis.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Каркасы";
            // 
            // comboMech
            // 
            this.comboMech.FormattingEnabled = true;
            this.comboMech.Location = new System.Drawing.Point(70, 201);
            this.comboMech.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboMech.Name = "comboMech";
            this.comboMech.Size = new System.Drawing.Size(522, 21);
            this.comboMech.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label2.Location = new System.Drawing.Point(7, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Машина";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label3.Location = new System.Drawing.Point(7, 232);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ядро";
            // 
            // comboCore
            // 
            this.comboCore.FormattingEnabled = true;
            this.comboCore.Location = new System.Drawing.Point(70, 229);
            this.comboCore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboCore.Name = "comboCore";
            this.comboCore.Size = new System.Drawing.Size(522, 21);
            this.comboCore.TabIndex = 5;
            // 
            // btnChassis
            // 
            this.btnChassis.Location = new System.Drawing.Point(9, 257);
            this.btnChassis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChassis.Name = "btnChassis";
            this.btnChassis.Size = new System.Drawing.Size(582, 19);
            this.btnChassis.TabIndex = 6;
            this.btnChassis.Text = "Собрать машину";
            this.btnChassis.UseVisualStyleBackColor = true;
            this.btnChassis.Click += new System.EventHandler(this.btnChassis_Click);
            // 
            // FormOder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 284);
            this.Controls.Add(this.btnChassis);
            this.Controls.Add(this.comboCore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboMech);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridChassis);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormOder";
            this.Text = "FormOder";
            ((System.ComponentModel.ISupportInitialize)(this.gridChassis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridChassis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboMech;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboCore;
        private System.Windows.Forms.Button btnChassis;
    }
}