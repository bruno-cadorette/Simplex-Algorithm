namespace ProgrammationLineaire
{
    partial class Base
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
            this.textBoxNombreValeur = new System.Windows.Forms.TextBox();
            this.buttonCalculer = new System.Windows.Forms.Button();
            this.textBoxNombreEquation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNombreValeur
            // 
            this.textBoxNombreValeur.Location = new System.Drawing.Point(163, 6);
            this.textBoxNombreValeur.Name = "textBoxNombreValeur";
            this.textBoxNombreValeur.Size = new System.Drawing.Size(46, 20);
            this.textBoxNombreValeur.TabIndex = 2;
            this.textBoxNombreValeur.Text = "2";
            // 
            // buttonCalculer
            // 
            this.buttonCalculer.Location = new System.Drawing.Point(15, 94);
            this.buttonCalculer.Name = "buttonCalculer";
            this.buttonCalculer.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculer.TabIndex = 4;
            this.buttonCalculer.Text = "Calculez";
            this.buttonCalculer.UseVisualStyleBackColor = true;
            this.buttonCalculer.Click += new System.EventHandler(this.buttonCalculer_Click);
            // 
            // textBoxNombreEquation
            // 
            this.textBoxNombreEquation.Location = new System.Drawing.Point(163, 41);
            this.textBoxNombreEquation.Name = "textBoxNombreEquation";
            this.textBoxNombreEquation.Size = new System.Drawing.Size(46, 20);
            this.textBoxNombreEquation.TabIndex = 3;
            this.textBoxNombreEquation.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre de valeurs maximal : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre d\'équations : ";
            // 
            // Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNombreValeur);
            this.Controls.Add(this.buttonCalculer);
            this.Controls.Add(this.textBoxNombreEquation);
            this.Name = "Base";
            this.Text = "Base";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombreValeur;
        private System.Windows.Forms.Button buttonCalculer;
        private System.Windows.Forms.TextBox textBoxNombreEquation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}