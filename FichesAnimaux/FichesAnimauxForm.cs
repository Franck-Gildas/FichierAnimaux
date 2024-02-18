/*
    Programmeur(s):      Franck Gildas M. K.
                         Mohamed ESSANHAJI,
                         Alioune sarr,
                         Mbengue El Hadji Cisse,
                         
    Date:                Novembre

    Solution:            FichesAnimaux.sln
    Projet:              FichesAnimaux.csproj
    Classe:              FichesAnimauxForm.cs

    But:                 - Créer la classe du formulaire parent d'une application Multiple Document Interface.
                         - Créer le menu, la barre d'outils et la barre d'état du formulaire parent. 
                         - Permettre à l'usager de déplacer et ancrer le menu principal et la barre d'outils.
                         - Créer des fichier enfant d'une application principale.
                         - Modifier la fenêtre des fichiers enfants.
                         - Modifier le menu dans la barre d'outils.
                         - Ouvrir, Enregistrer et Fermer un formulaire Enfant.
                         - Édition, Police et Alignement du texte, Modifier les boutons de la barre d’outils d’après le texte
                           sélectionné, Activer/Désactiver les boutons et les menus lorsque les clients ouvrent et ferment.
                         - Changer la police du texte sélectionné

                         - Phase F : Boîte à outils Rechercher.

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
using System.Globalization;

namespace FichesAnimaux
{
    public partial class Parent : Form
    {
        #region Variables globales et privées

        int nombre = 0;
        private ComboBox oComboBox;

        #endregion

        #region Initialisation
        public Parent()
        {
            InitializeComponent();
        }

        private void Parent_Load(object sender, EventArgs e)
        {
            g.InitMessagesErreurs();
            AssocierImage();
            DesactiverOperationsMenusBarreOutils();
            fichesAnimauxOpenFileDialog.Filter = "Fichiers rtf (*.rtf)|*.rtf|Tous les fichiers(*.*)|*.*";
            fichesAnimauxOpenFileDialog.AddExtension = true;
            fichesAnimauxOpenFileDialog.CheckFileExists = true;
            fichesAnimauxOpenFileDialog.DefaultExt = "rtf";

            // Vérifier la culture
            cultureToolStripStatusLabel.Text = CultureInfo.CurrentCulture.NativeName;

            // Vérifier si l’option Verrouillage « caps lock » est activé ou non
            if (System.Console.CapsLock)
                verrouillageMajToolStripStatusLabel.Text = "MAJ";

            // Pour empêcher l'événement de sélection de police ou de taille de police de se déclencher avant même la création ou l'ouverture d'un formulaire.
            policeToolStripComboBox.SelectedIndexChanged -= policeToolStripComboBox_SelectedIndexChanged;
            tailleToolStripComboBox.SelectedIndexChanged -= tailleToolStripComboBox_SelectedIndexChanged;

            // Liste interne du contrôle ToolStripComboBox d'une barre d'outils
            oComboBox = policeToolStripComboBox.ComboBox;

            //Le texte des éléments de liste ne sera pas pris en charge automatiquement.
            oComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            oComboBox.Width *= 2;

            // Afficher la liste des polices installées dans leur police respective. (objet fontFamily stocké)
            AfficherPolicesInstalleesOrdinateur();

            oComboBox.DrawItem += oComboBox_DrawItem;

            // Remplace l'événement de sélection Combobox
            policeToolStripComboBox.SelectedIndexChanged += policeToolStripComboBox_SelectedIndexChanged;
            tailleToolStripComboBox.SelectedIndexChanged += tailleToolStripComboBox_SelectedIndexChanged;

            InitDialogue();
        }

        #endregion

        #region Gérer l'événement DrawItem pour afficher le nom de la police

        private void oComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return; // Si aucun élément n'est sélectionné, renvoie

            // Récupère la famille de polices
            FontFamily fontFamily = new FontFamily((string)oComboBox.Items[e.Index]);

            // Crée une nouvelle police
            using (Font font = new Font(fontFamily.Name, oComboBox.Font.Size))
            {
                // Dessine l'élément
                e.Graphics.DrawString(fontFamily.Name, font, Brushes.Black, e.Bounds);
            }
        }


        #endregion

        #region Méthode pour Associer les images
        private void AssocierImage()
        {
            fichierNouveauToolStripMenuItem.Image = nouveauToolStripButton.Image;
            fichierOuvrirToolStripMenuItem.Image = ouvrirToolStripButton.Image;
            fichierEnregistrerToolStripMenuItem.Image = enregistrerToolStripButton.Image;
            editionCouperToolStripMenuItem.Image = couperToolStripButton.Image;
            editionCopierToolStripMenuItem.Image = copierToolStripButton.Image;
            editionCollerToolStripMenuItem.Image = collerToolStripButton.Image;
            aideSurListeAnimauxToolStripMenuItem.Image = aideToolStripButton.Image;
        }

        #endregion

        #region Changer l'orientation du MenuStrip et ToolStrip quand le ToolStripPanel reçoit le control

        private void CombinerQuatreToolStripPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control == fichesAnimauxMenuStrip)
            {
                if (sender == gaucheToolStripPanel || sender == droitToolStripPanel)
                {
                    fichesAnimauxMenuStrip.TextDirection = ToolStripTextDirection.Vertical90;
                    fichesAnimauxMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                    taperQuestionToolStripTextBox.Visible = false;
                }
                else
                {
                    fichesAnimauxMenuStrip.TextDirection = ToolStripTextDirection.Horizontal;
                    fichesAnimauxMenuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                    taperQuestionToolStripTextBox.Visible = true;
                }
            }

            else
            {
                if (sender == gaucheToolStripPanel || sender == droitToolStripPanel)
                {
                    policeToolStripComboBox.Visible = false;
                    tailleToolStripComboBox.Visible = false;
                }
                else
                {
                    policeToolStripComboBox.Visible = true;
                    tailleToolStripComboBox.Visible = true;
                }
            }
        }

        #endregion

        #region Selectionner la boite de texte Taper Une question quand elle reçoit le focus
        private void taperQuestionToolStripTextBox_Click(object sender, EventArgs e)
        {
            taperQuestionToolStripTextBox.SelectAll();
        }

        #endregion

        #region Modifier l’apparence de la barre des menus.

        private void StyleToolStripMenuItems_Click(object sender, EventArgs e)
        {
            int renderModeInt;

            renderModeInt = affichageBarreOutilsToolStripMenuItem.DropDownItems.IndexOf(sender as ToolStripMenuItem) + 1;

            fichesAnimauxMenuStrip.RenderMode = (ToolStripRenderMode)renderModeInt;

            g.EnleverCrochetSousMenu(affichageBarreOutilsToolStripMenuItem);

            (sender as ToolStripMenuItem).Checked = true;
        }

        #endregion

        #region Nouveau document : Fichier enfant
        private void NouveauToolStripItem_Click(object sender, EventArgs e)
        {
            //Animal oAnimal = new Animal();

            Animal oAnimal;

            try
            {
                oAnimal = new Animal();
                nombre++;

                oAnimal.MdiParent = this;
                oAnimal.Text += nombre;
                oAnimal.Show();

                oAnimal.ModeInsertion = true;
            }
            catch(Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CENouveauFichier]);
            }

            ActiverOperationsMenusBarreOutils();
        }

        #endregion

        #region Menu - Réorganiser les fenêtres

        private void FenetreMDILayout_Click(object sender, EventArgs e)
        {
            int MDILayoutInt;

            MDILayoutInt = fenetreToolStripMenuItem.DropDownItems.IndexOf(sender as ToolStripMenuItem);

            this.LayoutMdi((MdiLayout)MDILayoutInt);

            g.EnleverCrochetSousMenu(fenetreToolStripMenuItem);

            (sender as ToolStripMenuItem).Checked = true;
        }

        #endregion

        #region Ouvrir un document RTF existant dans une nouvelle fenêtre

        private void FichierOuvrirDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (fichesAnimauxOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.Path.GetExtension(fichesAnimauxOpenFileDialog.FileName).ToUpper() == ".RTF")
                    {
                        string nom;
                        string classe;
                        string code;
                        string contacte;

                        Animal oAnimal = new Animal();

                        oAnimal.Text = fichesAnimauxOpenFileDialog.FileName;  // Nom du document ouvert et son chemin d'acces dans la barre de titre
                        oAnimal.MdiParent = this;
                        
                        RichTextBox oRichTextBox = new RichTextBox();

                        oRichTextBox.LoadFile(fichesAnimauxOpenFileDialog.FileName);

                        nom = oRichTextBox.Lines[0];
                        classe = oRichTextBox.Lines[1];
                        code = oRichTextBox.Lines[2];
                        contacte = oRichTextBox.Lines[3];

                        oAnimal.animalTextBox.Text = nom;
                        oAnimal.classeComboBox.Text = classe;
                        oAnimal.codeGenetiqueTextBox.Text = code;
                        oAnimal.contacteZooMaskedTextBox.Text = contacte;

                        oRichTextBox.SelectionStart = 0;
                        oRichTextBox.SelectionLength = nom.Length +
                                                       classe.Length +
                                                       code.Length +
                                                       contacte.Length + 4;
                        oRichTextBox.SelectedText = String.Empty;

                        oAnimal.infoAnimalRichTextBox.Rtf = oRichTextBox.Rtf;

                        oAnimal.infoAnimalRichTextBox.Modified = false;  // Un fichier ouvert n'a jamais été modifié.
                        oAnimal.Modification = false;
                        oAnimal.Enregistrement = true;

                        oAnimal.Show();

                        fichesAnimauxOpenFileDialog.InitialDirectory = fichesAnimauxOpenFileDialog.FileName;

                        oAnimal.ModeInsertion = true;

                        insertionToolStripStatusLabel.Text = "RFP";
                    }
                    else
                    {
                        MessageBox.Show(g.tMessagesErreursStr[(int)ce.CERTFSeulement], "Ouvrir un document",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }   // Ouvrir un document portant l'extension RTF seulement. ArgumentException si on tente d'ouvrir un.doc
                }       // Cancel - annule l'operation d'ouverture d'un document.
            }
            catch(Exception ouvrirException)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + ouvrirException.ToString(),
                                "Ouvrir un document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActiverOperationsMenusBarreOutils();
        }

        #endregion

        #region Enregistrer ou Enregistrer Sous

        private void FichierEnregistrer_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                if (sender == fichierEnregistrerToolStripMenuItem || sender == enregistrerToolStripButton)
                {
                    Animal oAnimal;
                    oAnimal = (Animal)this.ActiveMdiChild;
                    oAnimal.Enregistrer();
                }
                else
                {
                    Animal oAnimal;
                    oAnimal = (Animal)this.ActiveMdiChild;
                    oAnimal.EnregistrerSous();
                }

                creerOuvrirAnimalToolStripStatusLabel.Text = this.ActiveMdiChild.Text;
            }
        }

        #endregion

        #region Gérer les options du menu Éditions

        private void EditionTexte_Click(object sender, EventArgs e)
        {
            try
            {
                Animal activeAnimal = (Animal)this.ActiveMdiChild;

                if (activeAnimal != null)
                {
                    if (sender == editionCopierToolStripMenuItem || sender == copierToolStripButton)
                        activeAnimal.CopierTexte();

                    if (sender == editionCouperToolStripMenuItem || sender == couperToolStripButton)
                        activeAnimal.CouperTexte();

                    if (sender == editionCollerToolStripMenuItem || sender == collerToolStripButton)
                        activeAnimal.CollerTexte();

                    if (sender == editionEffacerToolStripMenuItem)
                        activeAnimal.infoAnimalRichTextBox.Clear();

                    if (sender == editionSelectionnerToolStripMenuItem)
                        activeAnimal.infoAnimalRichTextBox.SelectAll();
                }
                else
                    MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEAucunFormulaireActif]);
            }
            catch (Exception editionException)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + editionException.ToString(),
                     "Edition de police", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Style Polices du infoAnimalRichTextBox

        private void StylePolice_Click(object sender, EventArgs e)
        {
            try
            {
                Animal activeAnimal = (Animal)this.ActiveMdiChild;

                if (activeAnimal != null)
                {
                    if (sender == grasToolStripButton)  // Dis au formulaire enfant de changer le style de police du texte sélectionné en gras
                        activeAnimal.ChangerAttributsPolices(FontStyle.Bold);

                    else if (sender == italicToolStripButton)   // Dis au formulaire enfant de changer le style de police du texte sélectionné en italic
                        activeAnimal.ChangerAttributsPolices(FontStyle.Italic);

                    else                                    // Dis au formulaire enfant de changer le style de police du texte sélectionné en souligné
                        activeAnimal.ChangerAttributsPolices(FontStyle.Underline);
                }
                else
                    MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEAucunFormulaireActif]);
            }
            catch(Exception styleException)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + styleException.ToString(),
                        "Style de police", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Gérer l’alignement.

        private void Alignement_Click(object sender, EventArgs e)
        {
            try
            {
                Animal activeAnimal = (Animal)this.ActiveMdiChild;

                if (activeAnimal != null)
                {
                    if (sender == alignerGaucheToolStripButton)
                    {
                        activeAnimal.infoAnimalRichTextBox.SelectionAlignment = HorizontalAlignment.Left;

                        alignerGaucheToolStripButton.Checked = true;
                        alignerCentrerToolStripButton.Checked = false;
                        alignerDroiteToolStripButton.Checked = false;
                    }

                    else if (sender == alignerCentrerToolStripButton)
                    {
                        activeAnimal.infoAnimalRichTextBox.SelectionAlignment = HorizontalAlignment.Center;

                        alignerGaucheToolStripButton.Checked = false;
                        alignerCentrerToolStripButton.Checked = true;
                        alignerDroiteToolStripButton.Checked = false;
                    }

                    else
                    {
                        activeAnimal.infoAnimalRichTextBox.SelectionAlignment = HorizontalAlignment.Right;

                        alignerGaucheToolStripButton.Checked = false;
                        alignerCentrerToolStripButton.Checked = false;
                        alignerDroiteToolStripButton.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEAucunFormulaireActif]);
                }
            }
            catch (Exception alignementException)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + alignementException.ToString(),
                            "Alignement du Texte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Désactiver tous les menus et les boutons.

        private void DesactiverOperationsMenusBarreOutils()
        {
            // Désactiver tous les éléments du menu
            foreach (ToolStripItem mainToolStripItem in fichesAnimauxMenuStrip.Items)
            {
                if (mainToolStripItem is ToolStripMenuItem mainToolStripMenuItem)
                {
                    foreach (ToolStripItem courantToolStripItem in mainToolStripMenuItem.DropDownItems)
                    {
                        if (courantToolStripItem is ToolStripMenuItem courantToolStripMenuItem)
                        {
                            courantToolStripMenuItem.Enabled = false;
                        }
                    }
                }
            }

            // Activer des éléments de menu spécifiques
            fichierNouveauToolStripMenuItem.Enabled = true;
            fichierOuvrirToolStripMenuItem.Enabled = true;
            fichierQuitterToolStripMenuItem.Enabled = true;
            aideSurListeAnimauxToolStripMenuItem.Enabled = true;

            // Désactiver tous les boutons de la barre d'outils
            foreach (ToolStripItem boutonToolStripItem in fichesAnimauxToolStrip.Items)
            {
                boutonToolStripItem.Enabled = false;
            }

            // Activer des boutons spécifiques de la barre d'outils
            nouveauToolStripButton.Enabled = true;
            ouvrirToolStripButton.Enabled = true;
            aideToolStripButton.Enabled = true;
        }

        #endregion

        #region Désactiver les menus quand tous les documents sont fermés

        private void Parent_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                DesactiverOperationsMenusBarreOutils();

                // Définit le texte du ToolStripStatusLabel
                creerOuvrirAnimalToolStripStatusLabel.Text = "Créer ou ouvrir un fichier animal";
                insertionToolStripStatusLabel.Text = "";

                foreach (Form form in this.OwnedForms)
                {
                    if (form is RechercheForm)
                        form.Close();
                }
            }
            else
            {
                // Convertit le formulaire enfant actif en Enfant
                Animal activeAnimal = this.ActiveMdiChild as Animal;

                // Vérifie si le casting a réussi
                if (activeAnimal != null)
                {
                    // Vérifier la propriété InsertionMode et mettre à jour le ToolStripStatusLabel
                    if (activeAnimal.ModeInsertion)
                        insertionToolStripStatusLabel.Text = "INS";
                    else
                        insertionToolStripStatusLabel.Text = "RFP";
                }
                else
                   insertionToolStripStatusLabel.Text = "";

                // Définit le texte du ToolStripStatusLabel sur le titre de la fenêtre active
                creerOuvrirAnimalToolStripStatusLabel.Text = this.ActiveMdiChild.Text;
            }
        }

        #endregion

        #region KeyDown : Capter « Caps Lock » ou la clé « Insert »

        private void Parent_KeyDown(object sender, KeyEventArgs e)
        {
            // Vérifiez si le verrouillage des majuscules est activé
            if (Control.IsKeyLocked(Keys.CapsLock))
                verrouillageMajToolStripStatusLabel.Text = "MAJ";
            else
                verrouillageMajToolStripStatusLabel.Text = string.Empty;

            // Vérifier si la touche Insert a été appuyée
            if (e.KeyCode == Keys.Insert)
            {
                // Mettre à jour le ToolStripStatusLabel
                if (insertionToolStripStatusLabel.Text == "INS")
                {
                    insertionToolStripStatusLabel.Text = "RFP";

                    if (this.ActiveMdiChild != null)
                        (this.ActiveMdiChild as Animal).ModeInsertion = false;

                }
                else
                {
                    insertionToolStripStatusLabel.Text = "INS";

                    // Définit la propriété InsertionMode de la fenêtre active sur true
                    if (this.ActiveMdiChild is Animal activeAnimal)
                        activeAnimal.ModeInsertion = true;
                }

                // Définit la propriété InsertionMode de la fenêtre active sur false
                //if (this.ActiveMdiChild is Animal activeAnimal)
                //    activeAnimal.ModeInsertion = false;

            }
            
        }

        #endregion

        #region Activer tous les menus et les boutons.

        private void ActiverOperationsMenusBarreOutils()
        {
            Animal activeAnimal = (Animal)this.ActiveMdiChild;
            bool estTexteSelectionne = activeAnimal.infoAnimalRichTextBox.SelectionLength > 0;
            bool estDansClipboard = Clipboard.ContainsText() || Clipboard.ContainsImage();

            // Active tous les éléments de menu
            foreach (ToolStripItem mainToolStripItem in fichesAnimauxMenuStrip.Items)
            {
                if (mainToolStripItem is ToolStripMenuItem mainToolStripMenuItem)
                {
                    foreach (ToolStripItem courantToolStripItem in mainToolStripMenuItem.DropDownItems)
                    {
                        if (courantToolStripItem is ToolStripMenuItem courantToolStripMenuItem)
                        {
                            courantToolStripMenuItem.Enabled = true;
                        }
                    }
                }
            }

            // Activer le menu copier et couper seulement si du texte est selectionné dans infoAnimalRichTextBox
            editionCopierToolStripMenuItem.Enabled = estTexteSelectionne;
            editionCouperToolStripMenuItem.Enabled = estTexteSelectionne;

            // Activer ou désactiver l'élément de menu Coller selon que le texte est dans le clipboard
            editionCollerToolStripMenuItem.Enabled = estDansClipboard;       

            // Activer tous les boutons de la barre d'outils
            foreach (ToolStripItem boutonToolStripItem in fichesAnimauxToolStrip.Items)
            {
                boutonToolStripItem.Enabled = true;
            }

            // Activer la barre d'outil de copier et couper seulement si du texte est selectionné dans infoAnimalRichTextBox
            copierToolStripButton.Enabled = estTexteSelectionne;
            couperToolStripButton.Enabled = estTexteSelectionne;

            // Activer ou désactiver l'élément de menu Coller selon que le texte est dans le clipboard
            collerToolStripButton.Enabled = estDansClipboard;
        }

        #endregion

        #region Méthodes Privées

        private void AfficherPolicesInstalleesOrdinateur()
        {
            try
            {
                System.Drawing.Text.InstalledFontCollection oInstalledFonts = new System.Drawing.Text.InstalledFontCollection();

                foreach (FontFamily oFontFamily in oInstalledFonts.Families)
                {
                    // Objet de la classe FontFamily ajouté à ComboBox
                    policeToolStripComboBox.Items.Add(oFontFamily.Name);
                }

                // Noms des familles de polices affichées
                oComboBox.DisplayMember = "Name";
            }
            catch (Exception e)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + e.ToString(),
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitDialogue()
        {
            fichesAnimauxFontDialog.ShowColor = true;
            fichesAnimauxFontDialog.AllowSimulations = true;
            fichesAnimauxFontDialog.FixedPitchOnly = true;
            fichesAnimauxFontDialog.FontMustExist = true;

            fichesAnimauxFontDialog.MinSize = 8;
            fichesAnimauxFontDialog.MaxSize = 14;
        }

        #endregion

        #region Polices, Tailles, et Formats
        private void policeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font oRichTextBoxFont = (this.ActiveMdiChild as Animal).infoAnimalRichTextBox.SelectionFont;

            if (oRichTextBoxFont != null) // Une seule police dans le texte sélectionné
            {
                try
                {
                    (this.ActiveMdiChild as Animal).infoAnimalRichTextBox.SelectionFont = new Font(policeToolStripComboBox.Text, oRichTextBoxFont.Size, oRichTextBoxFont.Style);

                    this.ActiveMdiChild.ActiveControl.Focus();  // Remettre le focus sur le cours document
                }
                catch (Exception ex)
                {
                    MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + ex.ToString(),
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void tailleToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Animal oAnimal = (Animal)this.ActiveMdiChild;
            Font oRichTextBoxFont = oAnimal.infoAnimalRichTextBox.SelectionFont;

            oAnimal.infoAnimalRichTextBox.SelectionFont = new Font(oRichTextBoxFont.Name, int.Parse(tailleToolStripComboBox.Text), oRichTextBoxFont.Style);

            this.ActiveMdiChild.ActiveControl.Focus();
        }

        private void formatPoliceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Récupère la RichTextBox à partir du formulaire enfant MDI actif
            RichTextBox oRichTextBox = (this.ActiveMdiChild as Animal).infoAnimalRichTextBox;

            try
            {
                // Définit la police du FontDialog sur la police actuelle du texte sélectionné dans RichTextBox
                fichesAnimauxFontDialog.Font = oRichTextBox.SelectionFont;
                fichesAnimauxFontDialog.Color = oRichTextBox.SelectionColor;

                // Afficher le dialogue FontDialog
                if (fichesAnimauxFontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Si l'utilisateur a cliqué sur OK, appliquez la police sélectionnée dans FontDialog au texte sélectionné dans RichTextBox
                    oRichTextBox.SelectionFont = fichesAnimauxFontDialog.Font;
                    oRichTextBox.SelectionColor = fichesAnimauxFontDialog.Color;
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + ex.ToString(),
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

        #region Rechercher

        private void editionRechercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.OwnedForms.Length == 0)
            {
                RechercheForm rechercheDialogue;

                try
                {
                    rechercheDialogue = new RechercheForm();
                    rechercheDialogue.Owner = this;
                    rechercheDialogue.Mot = (this.ActiveMdiChild.ActiveControl as RichTextBox).SelectedText;
                    rechercheDialogue.Show();
                }
                catch ( Exception ex )
                {
                    MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + ex.ToString(),
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        #endregion

        #region Fermer le formulaire enfant active
        private void fichierFermerToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }


        #endregion

        #region Fermer l'Application
        private void fichierQuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
