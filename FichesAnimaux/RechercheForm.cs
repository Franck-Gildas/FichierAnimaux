/*
    Programmeur(s):      Franck Gildas M. K.
                         Mohamed ESSANHAJI,
                         Alioune sarr,
                         Mbengue El Hadji Cisse,
                         
    Date:                Octobre

    Solution:            FichesAnimaux.sln
    Projet:              FichesAnimaux.csproj
    Classe:              FichesAnimauxGeneraleClass.cs

    But:                 Définir les règles de l'application

    Info:                Couche de métier.
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
    public partial class RechercheForm : Form
    {
        #region Init

        public RechercheForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Propriété 

        public string Mot
        {
            get { return rechercherTextBox.Text; }
            set { rechercherTextBox.Text = value; }
        }

        #endregion

        #region Click Suivant
        private void suivantButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Owner.ActiveMdiChild != null)
                {
                    RichTextBox oRichTextBox = (this.Owner.ActiveMdiChild as Animal).infoAnimalRichTextBox;

                    int positionDepartInt = oRichTextBox.SelectionStart;
                    //string Mot = rechercherTextBox.Text;

                    if (oRichTextBox.SelectionLength == 0)
                    {
                        int position = oRichTextBox.Find(Mot, positionDepartInt, RichTextBoxFinds.None);

                        if (position == -1)
                        {
                            // Si le texte n'est pas trouvé, lancez la recherche depuis le début du document
                            position = oRichTextBox.Find(Mot, 0, RichTextBoxFinds.None);
                        }

                        if (position != -1)
                        {
                            // Si le texte est retrouvé
                            oRichTextBox.Select(position, Mot.Length);
                            oRichTextBox.ScrollToCaret();
                        }
                    }
                    else
                    {
                        int position = oRichTextBox.Find(Mot, positionDepartInt + 1, RichTextBoxFinds.None);

                        if (position == -1)
                        {
                            // If the text is not found, start the search from the beginning of the document
                            position = oRichTextBox.Find(Mot, 0, RichTextBoxFinds.None);
                        }

                        if (position != -1) // Si le texte est trouvé
                        {
                            oRichTextBox.Select(position, Mot.Length);
                            oRichTextBox.ScrollToCaret();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee] + Environment.NewLine + ex.ToString(),
                 "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

        #region Annuler
        private void annulerButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
