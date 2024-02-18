namespace FichesAnimaux
{
    partial class RechercheForm
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
            this.rechercherGroupBox = new System.Windows.Forms.GroupBox();
            this.rechercherLabel = new System.Windows.Forms.Label();
            this.rechercherTextBox = new System.Windows.Forms.TextBox();
            this.suivantButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.rechercherGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // rechercherGroupBox
            // 
            this.rechercherGroupBox.Controls.Add(this.rechercherTextBox);
            this.rechercherGroupBox.Controls.Add(this.rechercherLabel);
            this.rechercherGroupBox.Location = new System.Drawing.Point(22, 36);
            this.rechercherGroupBox.Name = "rechercherGroupBox";
            this.rechercherGroupBox.Size = new System.Drawing.Size(438, 90);
            this.rechercherGroupBox.TabIndex = 0;
            this.rechercherGroupBox.TabStop = false;
            // 
            // rechercherLabel
            // 
            this.rechercherLabel.AutoSize = true;
            this.rechercherLabel.Location = new System.Drawing.Point(6, 31);
            this.rechercherLabel.Name = "rechercherLabel";
            this.rechercherLabel.Size = new System.Drawing.Size(77, 16);
            this.rechercherLabel.TabIndex = 0;
            this.rechercherLabel.Text = "&Rechercher";
            // 
            // rechercherTextBox
            // 
            this.rechercherTextBox.Location = new System.Drawing.Point(130, 31);
            this.rechercherTextBox.Name = "rechercherTextBox";
            this.rechercherTextBox.Size = new System.Drawing.Size(260, 22);
            this.rechercherTextBox.TabIndex = 1;
            // 
            // suivantButton
            // 
            this.suivantButton.Location = new System.Drawing.Point(550, 36);
            this.suivantButton.Name = "suivantButton";
            this.suivantButton.Size = new System.Drawing.Size(118, 36);
            this.suivantButton.TabIndex = 1;
            this.suivantButton.Text = "&Suivant";
            this.suivantButton.UseVisualStyleBackColor = true;
            this.suivantButton.Click += new System.EventHandler(this.suivantButton_Click);
            // 
            // annulerButton
            // 
            this.annulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annulerButton.Location = new System.Drawing.Point(550, 92);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(118, 34);
            this.annulerButton.TabIndex = 2;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annulerButton_Click);
            // 
            // RechercheForm
            // 
            this.AcceptButton = this.suivantButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.annulerButton;
            this.ClientSize = new System.Drawing.Size(693, 194);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.suivantButton);
            this.Controls.Add(this.rechercherGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RechercheForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechercher";
            this.rechercherGroupBox.ResumeLayout(false);
            this.rechercherGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox rechercherGroupBox;
        private System.Windows.Forms.Label rechercherLabel;
        private System.Windows.Forms.Button suivantButton;
        private System.Windows.Forms.Button annulerButton;
        internal System.Windows.Forms.TextBox rechercherTextBox;
    }
}