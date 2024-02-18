namespace FichesAnimaux
{
    partial class Animal
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
            this.animalLabel = new System.Windows.Forms.Label();
            this.animalTextBox = new System.Windows.Forms.TextBox();
            this.classeLabel = new System.Windows.Forms.Label();
            this.codeGenetiqueLabel = new System.Windows.Forms.Label();
            this.contacteZooLabel = new System.Windows.Forms.Label();
            this.infoAnimalLabel = new System.Windows.Forms.Label();
            this.codeGenetiqueTextBox = new System.Windows.Forms.TextBox();
            this.contacteZooMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.infoAnimalRichTextBox = new System.Windows.Forms.RichTextBox();
            this.titreLabel = new System.Windows.Forms.Label();
            this.coupleSouricatesLabel = new System.Windows.Forms.Label();
            this.coupleSouricatesPictureBox = new System.Windows.Forms.PictureBox();
            this.becEnSabotPictureBox2 = new System.Windows.Forms.PictureBox();
            this.becEnSabotPictureBox1 = new System.Windows.Forms.PictureBox();
            this.classeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.coupleSouricatesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.becEnSabotPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.becEnSabotPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // animalLabel
            // 
            this.animalLabel.AutoSize = true;
            this.animalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animalLabel.Location = new System.Drawing.Point(16, 132);
            this.animalLabel.Name = "animalLabel";
            this.animalLabel.Size = new System.Drawing.Size(60, 20);
            this.animalLabel.TabIndex = 1;
            this.animalLabel.Text = "Animal";
            // 
            // animalTextBox
            // 
            this.animalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animalTextBox.Location = new System.Drawing.Point(273, 130);
            this.animalTextBox.Name = "animalTextBox";
            this.animalTextBox.Size = new System.Drawing.Size(216, 27);
            this.animalTextBox.TabIndex = 2;
            this.animalTextBox.TextChanged += new System.EventHandler(this.Modification_TextChanged);
            // 
            // classeLabel
            // 
            this.classeLabel.AutoSize = true;
            this.classeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classeLabel.Location = new System.Drawing.Point(16, 177);
            this.classeLabel.Name = "classeLabel";
            this.classeLabel.Size = new System.Drawing.Size(61, 20);
            this.classeLabel.TabIndex = 3;
            this.classeLabel.Text = "Classe";
            // 
            // codeGenetiqueLabel
            // 
            this.codeGenetiqueLabel.AutoSize = true;
            this.codeGenetiqueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeGenetiqueLabel.Location = new System.Drawing.Point(16, 223);
            this.codeGenetiqueLabel.Name = "codeGenetiqueLabel";
            this.codeGenetiqueLabel.Size = new System.Drawing.Size(125, 20);
            this.codeGenetiqueLabel.TabIndex = 5;
            this.codeGenetiqueLabel.Text = "Code génétique";
            // 
            // contacteZooLabel
            // 
            this.contacteZooLabel.AutoSize = true;
            this.contacteZooLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contacteZooLabel.Location = new System.Drawing.Point(16, 264);
            this.contacteZooLabel.Name = "contacteZooLabel";
            this.contacteZooLabel.Size = new System.Drawing.Size(223, 20);
            this.contacteZooLabel.TabIndex = 7;
            this.contacteZooLabel.Text = "Contacte: zoo le plus proche";
            // 
            // infoAnimalLabel
            // 
            this.infoAnimalLabel.AutoSize = true;
            this.infoAnimalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoAnimalLabel.Location = new System.Drawing.Point(12, 346);
            this.infoAnimalLabel.Name = "infoAnimalLabel";
            this.infoAnimalLabel.Size = new System.Drawing.Size(183, 20);
            this.infoAnimalLabel.TabIndex = 9;
            this.infoAnimalLabel.Text = "Information sur l\'animal";
            // 
            // codeGenetiqueTextBox
            // 
            this.codeGenetiqueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeGenetiqueTextBox.Location = new System.Drawing.Point(273, 220);
            this.codeGenetiqueTextBox.MaxLength = 10;
            this.codeGenetiqueTextBox.Name = "codeGenetiqueTextBox";
            this.codeGenetiqueTextBox.PasswordChar = '*';
            this.codeGenetiqueTextBox.Size = new System.Drawing.Size(216, 27);
            this.codeGenetiqueTextBox.TabIndex = 6;
            this.codeGenetiqueTextBox.TextChanged += new System.EventHandler(this.Modification_TextChanged);
            // 
            // contacteZooMaskedTextBox
            // 
            this.contacteZooMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contacteZooMaskedTextBox.Location = new System.Drawing.Point(273, 264);
            this.contacteZooMaskedTextBox.Mask = "(999) 000-0000";
            this.contacteZooMaskedTextBox.Name = "contacteZooMaskedTextBox";
            this.contacteZooMaskedTextBox.Size = new System.Drawing.Size(216, 27);
            this.contacteZooMaskedTextBox.TabIndex = 8;
            this.contacteZooMaskedTextBox.TextChanged += new System.EventHandler(this.Modification_TextChanged);
            // 
            // infoAnimalRichTextBox
            // 
            this.infoAnimalRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoAnimalRichTextBox.Location = new System.Drawing.Point(253, 346);
            this.infoAnimalRichTextBox.Name = "infoAnimalRichTextBox";
            this.infoAnimalRichTextBox.Size = new System.Drawing.Size(604, 196);
            this.infoAnimalRichTextBox.TabIndex = 10;
            this.infoAnimalRichTextBox.Text = "";
            this.infoAnimalRichTextBox.SelectionChanged += new System.EventHandler(this.infoAnimalRichTextBox_SelectionChanged);
            // 
            // titreLabel
            // 
            this.titreLabel.AutoSize = true;
            this.titreLabel.Font = new System.Drawing.Font("Yu Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.titreLabel.Location = new System.Drawing.Point(158, 27);
            this.titreLabel.Name = "titreLabel";
            this.titreLabel.Size = new System.Drawing.Size(515, 43);
            this.titreLabel.TabIndex = 0;
            this.titreLabel.Text = "Explorons l\'Univers Zoologique";
            // 
            // coupleSouricatesLabel
            // 
            this.coupleSouricatesLabel.AutoSize = true;
            this.coupleSouricatesLabel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.coupleSouricatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coupleSouricatesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.coupleSouricatesLabel.Location = new System.Drawing.Point(626, 313);
            this.coupleSouricatesLabel.Name = "coupleSouricatesLabel";
            this.coupleSouricatesLabel.Size = new System.Drawing.Size(231, 16);
            this.coupleSouricatesLabel.TabIndex = 11;
            this.coupleSouricatesLabel.Text = "Image du Jour : Couple de souricates ";
            // 
            // coupleSouricatesPictureBox
            // 
            this.coupleSouricatesPictureBox.Image = global::FichesAnimaux.Properties.Resources.Wonderful_Meerkats_Couples;
            this.coupleSouricatesPictureBox.Location = new System.Drawing.Point(653, 130);
            this.coupleSouricatesPictureBox.Name = "coupleSouricatesPictureBox";
            this.coupleSouricatesPictureBox.Size = new System.Drawing.Size(204, 180);
            this.coupleSouricatesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coupleSouricatesPictureBox.TabIndex = 13;
            this.coupleSouricatesPictureBox.TabStop = false;
            // 
            // becEnSabotPictureBox2
            // 
            this.becEnSabotPictureBox2.Image = global::FichesAnimaux.Properties.Resources.Shoe_bill_flipped;
            this.becEnSabotPictureBox2.Location = new System.Drawing.Point(757, 12);
            this.becEnSabotPictureBox2.Name = "becEnSabotPictureBox2";
            this.becEnSabotPictureBox2.Size = new System.Drawing.Size(100, 86);
            this.becEnSabotPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.becEnSabotPictureBox2.TabIndex = 11;
            this.becEnSabotPictureBox2.TabStop = false;
            // 
            // becEnSabotPictureBox1
            // 
            this.becEnSabotPictureBox1.Image = global::FichesAnimaux.Properties.Resources.Wonderful_shot_of_a_shoebill;
            this.becEnSabotPictureBox1.Location = new System.Drawing.Point(19, 12);
            this.becEnSabotPictureBox1.Name = "becEnSabotPictureBox1";
            this.becEnSabotPictureBox1.Size = new System.Drawing.Size(100, 86);
            this.becEnSabotPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.becEnSabotPictureBox1.TabIndex = 10;
            this.becEnSabotPictureBox1.TabStop = false;
            // 
            // classeComboBox
            // 
            this.classeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classeComboBox.FormattingEnabled = true;
            this.classeComboBox.Items.AddRange(new object[] {
            "Mammifères",
            "Oiseaux",
            "Reptiles",
            "Amphibiens",
            "Poissons"});
            this.classeComboBox.Location = new System.Drawing.Point(273, 177);
            this.classeComboBox.Name = "classeComboBox";
            this.classeComboBox.Size = new System.Drawing.Size(216, 28);
            this.classeComboBox.TabIndex = 4;
            this.classeComboBox.TextChanged += new System.EventHandler(this.Modification_TextChanged);
            // 
            // Animal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(880, 554);
            this.Controls.Add(this.classeComboBox);
            this.Controls.Add(this.coupleSouricatesLabel);
            this.Controls.Add(this.coupleSouricatesPictureBox);
            this.Controls.Add(this.titreLabel);
            this.Controls.Add(this.becEnSabotPictureBox2);
            this.Controls.Add(this.becEnSabotPictureBox1);
            this.Controls.Add(this.infoAnimalRichTextBox);
            this.Controls.Add(this.contacteZooMaskedTextBox);
            this.Controls.Add(this.codeGenetiqueTextBox);
            this.Controls.Add(this.infoAnimalLabel);
            this.Controls.Add(this.contacteZooLabel);
            this.Controls.Add(this.codeGenetiqueLabel);
            this.Controls.Add(this.classeLabel);
            this.Controls.Add(this.animalTextBox);
            this.Controls.Add(this.animalLabel);
            this.Name = "Animal";
            this.Text = "Animal ";
            this.Activated += new System.EventHandler(this.Animal_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Animal_FormClosing);
            this.TextChanged += new System.EventHandler(this.Modification_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.coupleSouricatesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.becEnSabotPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.becEnSabotPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label animalLabel;
        private System.Windows.Forms.Label classeLabel;
        private System.Windows.Forms.Label codeGenetiqueLabel;
        private System.Windows.Forms.Label contacteZooLabel;
        private System.Windows.Forms.Label infoAnimalLabel;
        private System.Windows.Forms.PictureBox becEnSabotPictureBox1;
        private System.Windows.Forms.PictureBox becEnSabotPictureBox2;
        private System.Windows.Forms.Label titreLabel;
        private System.Windows.Forms.PictureBox coupleSouricatesPictureBox;
        private System.Windows.Forms.Label coupleSouricatesLabel;
        internal System.Windows.Forms.TextBox animalTextBox;
        internal System.Windows.Forms.TextBox codeGenetiqueTextBox;
        internal System.Windows.Forms.MaskedTextBox contacteZooMaskedTextBox;
        internal System.Windows.Forms.ComboBox classeComboBox;
        internal System.Windows.Forms.RichTextBox infoAnimalRichTextBox;
    }
}