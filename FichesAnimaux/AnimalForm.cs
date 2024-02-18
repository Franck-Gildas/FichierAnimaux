/*
    Programmeur(s):      Mohamed ESSANHAJI,
                         Alioune sarr,
                         Mbengue El Hadji Cisse,
                         Franck Gildas M. K.

    Date:                Octobre

    Solution:            FichesAnimaux.sln
    Projet:              FichesAnimaux.csproj
    Classe:              AnimalForm.cs
                                    
    But:                 Entrer et Récupérer de l'information sur l'animal.                   

    Info:                Couche de présentation.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using g = FichesAnimaux.FichesAnimauxGeneraleClass;
using ce = FichesAnimaux.FichesAnimauxGeneraleClass.CodeErreurs;

namespace FichesAnimaux
{
    public partial class Animal : Form
    {
        #region Variables

        private Boolean enregistrementBoolean = false;
        private Boolean modificationBoolean = false;

        // Variables pour l'edition et le style du infoAnimalRichTextBox
        bool estGras = false;
        bool estItalic = false;
        bool estSouligne = false;
        bool estTexteSelectionne = false;
        bool estDansClipboard = false;

        #endregion

        #region Constructeur
        public Animal()
        {
            InitializeComponent();

            ModeInsertion = true;
        }

        #endregion

        #region Propriétés

        public Boolean Enregistrement
        {
            get { return enregistrementBoolean; }
            set { enregistrementBoolean = value; }
        }

        public Boolean Modification
        {
            get { return modificationBoolean; }
            set { modificationBoolean = value; }
        }

        // Définir la propriété ModeInsertion
        public Boolean ModeInsertion
        {
            get;
            set;
        }

        #endregion

        #region Enregistrer ou non en ferment le document

        private void Animal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult enregistrerDialogResult;

            try
            {
                if (infoAnimalRichTextBox.Modified || Modification)
                {
                    enregistrerDialogResult = MessageBox.Show("Le document " + this.Text +
                                                " a été modifié, désirez-vous l'enregistrer?", "Enregistrer le document",
                                                 MessageBoxButtons.YesNoCancel);

                    switch (enregistrerDialogResult)
                    {
                        case DialogResult.Yes:
                            Enregistrer();
                            this.Dispose();     // Optionnel, selon la logique, les enfants pourraient demeurer visibles et dans le tableau MDIChildren
                            break;

                        case DialogResult.Cancel:
                            e.Cancel = true;  // Formulaire document reste ouvert
                                              // Mais les autres qui sont fermées sont encore dans le tableau MdiChildren
                                              // et restent encore visibles. Il faut en disposer avec this.Dispose...
                            break;

                        case DialogResult.No:
                            this.Dispose();
                            break;
                    }
                }
            }
            catch (Exception fermetureException)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + fermetureException.Message,
                                "Fermeture du document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Méthodes publiques: Enregistrer/Enregistrer sous/Attributs polices

        public void Enregistrer()
        {
            try
            {
                if (infoAnimalRichTextBox.Modified || Modification) // Enregistrer seulement si le texte a été modifié
                {
                    if (!Enregistrement)    // Utilisateur fournira le nom
                        EnregistrerSous();
                    else                    // Enregistre le texte dans le fichier avec le nom courant déja dans la barre de titre
                    {
                        RichTextBox temp = new RichTextBox();

                        temp.Rtf = infoAnimalRichTextBox.Rtf;

                        temp.SelectionStart = 0;
                        temp.SelectionLength = 0;
                        temp.SelectedText = animalTextBox.Text + Environment.NewLine +
                                            classeComboBox.Text + Environment.NewLine +
                                            codeGenetiqueTextBox.Text + Environment.NewLine + 
                                            contacteZooMaskedTextBox.Text + Environment.NewLine;

                        temp.SaveFile(this.Text);

                        infoAnimalRichTextBox.Modified = false;
                        Modification = false;
                    }
                }
                else    // N'a jamais été modifié (Message Optionnel)
                {
                    MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEAucuneModification], "Enregistrer un fichier animal",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception enregistrerException)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + enregistrerException.ToString(), "Enregistrer un fichier animal",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EnregistrerSous()
        {
            String nomFichierString;

            try
            {
                SaveFileDialog enregistrerDocumentSaveFileDialog;
                enregistrerDocumentSaveFileDialog = new SaveFileDialog();

                enregistrerDocumentSaveFileDialog.Title = "Enregistrer un fichier animal";
                enregistrerDocumentSaveFileDialog.Filter = "Fichiers rtf(*.rtf)|*.rtf|Tous les fichiers (*.*)|*.*";

                enregistrerDocumentSaveFileDialog.FileName = this.Text;

                if (enregistrerDocumentSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.Path.GetExtension(enregistrerDocumentSaveFileDialog.FileName).ToUpper() == ".RTF")
                    {
                        nomFichierString = enregistrerDocumentSaveFileDialog.FileName;

                        RichTextBox temp = new RichTextBox();

                        temp.Rtf = infoAnimalRichTextBox.Rtf;

                        temp.SelectedText = animalTextBox.Text + Environment.NewLine +
                        classeComboBox.Text + Environment.NewLine +
                        codeGenetiqueTextBox.Text + Environment.NewLine +
                        contacteZooMaskedTextBox.Text + Environment.NewLine;

                        temp.SaveFile(nomFichierString);

                        this.Text = nomFichierString;   // Nom courant du fichier enregistré.

                        Enregistrement = true;
                        infoAnimalRichTextBox.Modified = false;
                        Modification = false;
                    }
                    else
                    {
                        MessageBox.Show(g.tMessagesErreursStr[(int)ce.CERTFSeulement], "Enregistrer un fichier animal",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }   // Annule l'operation d'enregistrement du document
            }
            catch(Exception enregistrerSousException)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + enregistrerSousException.ToString(), "Enregistrer sous du fichier animal",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Changement apporté dans les zones de textes

        private void Modification_TextChanged(object sender, EventArgs e)
        {
            Modification = true;    // Si TextChanged déclanche prendre pour acquis qu'une modification ou changement est apporté
        }

        #endregion

        #region Selection Changed, Manipulation du texte du infoAnimalRichTextBox
        private void infoAnimalRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Parent oParent = (Parent)this.MdiParent;

                //Styles

                // Vérifie si le texte sélectionné est en gras, italic, ou souligné
                estGras = infoAnimalRichTextBox.SelectionFont.Bold;
                estItalic = infoAnimalRichTextBox.SelectionFont.Italic;
                estSouligne = infoAnimalRichTextBox.SelectionFont.Underline;

                // Mise à jour de l'état du bouton gras, italic, ou souligné sur le formulaire parent
                oParent.grasToolStripButton.Checked = estGras;
                oParent.italicToolStripButton.Checked = estItalic;
                oParent.soulignerToolStripButton.Checked = estSouligne;


                //Editions

                // Activer ou désactiver l'élément de menu Copier et Coller selon que le texte est sélectionné ou non
                estTexteSelectionne = infoAnimalRichTextBox.SelectionLength > 0;
                oParent.editionCopierToolStripMenuItem.Enabled = estTexteSelectionne;
                oParent.editionCouperToolStripMenuItem.Enabled = estTexteSelectionne;
                oParent.copierToolStripButton.Enabled = estTexteSelectionne;
                oParent.couperToolStripButton.Enabled = estTexteSelectionne;

                // Activer ou désactiver l'élément de menu Coller selon que le texte est dans le clipboard
                estDansClipboard = Clipboard.ContainsText() || Clipboard.ContainsImage();
                oParent.editionCollerToolStripMenuItem.Enabled = estDansClipboard;
                oParent.collerToolStripButton.Enabled = estDansClipboard;

                // Vérifier l’alignement
                if (infoAnimalRichTextBox.SelectionAlignment == HorizontalAlignment.Left)
                {
                    oParent.alignerGaucheToolStripButton.Checked = true;
                    oParent.alignerCentrerToolStripButton.Checked = false;
                    oParent.alignerDroiteToolStripButton.Checked = false;
                }

                if (infoAnimalRichTextBox.SelectionAlignment == HorizontalAlignment.Center)
                {
                    oParent.alignerGaucheToolStripButton.Checked = false;
                    oParent.alignerCentrerToolStripButton.Checked = true;
                    oParent.alignerDroiteToolStripButton.Checked = false;
                }

                if (infoAnimalRichTextBox.SelectionAlignment == HorizontalAlignment.Right)
                {
                    oParent.alignerGaucheToolStripButton.Checked = false;
                    oParent.alignerCentrerToolStripButton.Checked = false;
                    oParent.alignerDroiteToolStripButton.Checked = true;
                }

                // Vérifiez si la RichTextBox a une sélection
                if (infoAnimalRichTextBox.SelectionFont !=  null)
                {
                    // Mise à jour du ToolStripComboBox dans le formulaire parent avec le nom et la taille de la police
                    oParent.policeToolStripComboBox.Text = infoAnimalRichTextBox.SelectionFont.Name;
                    oParent.tailleToolStripComboBox.Text = Convert.ToInt32(infoAnimalRichTextBox.SelectionFont.Size).ToString();
                }

            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee]);
            }
        }

        public void ChangerAttributsPolices(FontStyle style)
        {
            // Changer les attributs de police du texte sélectionné
            try
            {
                // Récupère la police actuelle
                Font courantFont = infoAnimalRichTextBox.SelectionFont;

                // Crée un nouveau style qui combine le style actuel avec le nouveau style
                FontStyle nouveauFontStyle = courantFont.Style ^ style;

                // Crée une nouvelle police avec le style combiné
                Font nouveauFont = new Font(courantFont, nouveauFontStyle);

                // Applique la nouvelle police au texte sélectionné
                infoAnimalRichTextBox.SelectionFont = nouveauFont;
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee]);
            }
        }

        // Méthodes pour copier, couper et coller du texte

        public void CopierTexte()
        {
            if (estTexteSelectionne)
                infoAnimalRichTextBox.Copy();
        }

        public void CouperTexte()
        {
            if (estTexteSelectionne)
                infoAnimalRichTextBox.Cut();
        }

        public void CollerTexte()
        {
            if (Clipboard.ContainsText())
                infoAnimalRichTextBox.Paste();
        }

        // L'événement Activated est déclenché lorsque le formulaire devient la fenêtre active.
        private void Animal_Activated(object sender, EventArgs e)
        {
            infoAnimalRichTextBox_SelectionChanged(null, null);
        }

        #endregion

    }
}
