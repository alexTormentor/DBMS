namespace DB_test
{
    partial class FormMenu
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
            this.btnMech = new System.Windows.Forms.Button();
            this.btnCore = new System.Windows.Forms.Button();
            this.btnChassis = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMech
            // 
            this.btnMech.Location = new System.Drawing.Point(81, 35);
            this.btnMech.Margin = new System.Windows.Forms.Padding(2);
            this.btnMech.Name = "btnMech";
            this.btnMech.Size = new System.Drawing.Size(112, 19);
            this.btnMech.TabIndex = 0;
            this.btnMech.Text = "Машины";
            this.btnMech.UseVisualStyleBackColor = true;
            this.btnMech.Click += new System.EventHandler(this.btnMech_Click);
            // 
            // btnCore
            // 
            this.btnCore.Location = new System.Drawing.Point(81, 88);
            this.btnCore.Margin = new System.Windows.Forms.Padding(2);
            this.btnCore.Name = "btnCore";
            this.btnCore.Size = new System.Drawing.Size(112, 19);
            this.btnCore.TabIndex = 1;
            this.btnCore.Text = "Ядра";
            this.btnCore.UseVisualStyleBackColor = true;
            this.btnCore.Click += new System.EventHandler(this.btnCore_Click);
            // 
            // btnChassis
            // 
            this.btnChassis.Location = new System.Drawing.Point(81, 137);
            this.btnChassis.Margin = new System.Windows.Forms.Padding(2);
            this.btnChassis.Name = "btnChassis";
            this.btnChassis.Size = new System.Drawing.Size(112, 19);
            this.btnChassis.TabIndex = 2;
            this.btnChassis.Text = "Каркасы";
            this.btnChassis.UseVisualStyleBackColor = true;
            this.btnChassis.Click += new System.EventHandler(this.btnChassis_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 19);
            this.button1.TabIndex = 3;
            this.button1.Text = "Транзакция";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.transact);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(198, 178);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 19);
            this.button2.TabIndex = 4;
            this.button2.Text = "Процедура";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Procedure);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 230);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChassis);
            this.Controls.Add(this.btnCore);
            this.Controls.Add(this.btnMech);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMech;
        private System.Windows.Forms.Button btnCore;
        private System.Windows.Forms.Button btnChassis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}