/*
    Programmeur(s):      Mohamed ESSANHAJI,
                         Alioune sarr,
                         Mbengue El Hadji Cisse,
                         Franck Gildas M. K.

    Date:                Octobre

    Solution:            FichesAnimaux.sln
    Projet:              FichesAnimaux.csproj
    Classe:              FichesAnimauxGeneraleClass.cs

    But:                 Définir les règles de l'application

    Info:                Couche de métier.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ce = FichesAnimaux.FichesAnimauxGeneraleClass.CodeErreurs;

namespace FichesAnimaux
{
    /// <summary>
    /// Classe generale (couche metier)
    /// </summary>
    internal class FichesAnimauxGeneraleClass
    {
        #region Énumération

        /// <summary>
        /// Énumeration pour les messages d'erreurs
        /// </summary>
        public enum CodeErreurs
        {
            CENouveauFichier,
            CEAucuneModification,
            CERTFSeulement,
            CEAucunFormulaireActif,
            CEAucunTexteSelectionne,
            CEAucunTexteEnMemoire,
            CEErreurIndeterminee
        }

        #endregion

        #region Messages d'erreurs

        public static string[] tMessagesErreursStr = new string[7];

        /// <summary>
        /// Initialiser les messages d'erreurs
        /// </summary>
        public static void InitMessagesErreurs()
        {
            tMessagesErreursStr[(int)ce.CENouveauFichier] = "Une erreur est survenue lors de la création d'un nouveau fichier.";
            tMessagesErreursStr[(int)ce.CEAucuneModification] = "Le fichier n'a jamais été modifié";
            tMessagesErreursStr[(int)ce.CERTFSeulement] = "Enregistrer un document sous RTF seulement.";
            tMessagesErreursStr[(int)ce.CEAucunFormulaireActif] = "Aucun fichier animal actif";
            tMessagesErreursStr[(int)ce.CEAucunTexteSelectionne] = "Aucun texte n'a été sélectionné.";
            tMessagesErreursStr[(int)ce.CEAucunTexteEnMemoire] = "Aucun texte temporaire en mémoire (Clipboard)";
            tMessagesErreursStr[(int)ce.CEErreurIndeterminee] = "Erreur indéterminée... Veuillez contactez le bureau d'aide (HelpDesk).";
        }

        #endregion

        #region Menu mutuellement exclusif

        /// <summary>
        /// Enlever les crochets des sous-menus d'un menu parent.
        /// </summary>
        /// <param name="parentMenu">Menu dont les sous-menus doivent être décochés.</param>
        /// <remarks>Pour produire un menu mutuellement exclusif (un seul crochet en tout temps).</remarks>
        public static void EnleverCrochetSousMenu(ToolStripMenuItem parentMenu)
        {
            if (parentMenu != null)
            {
                foreach (ToolStripItem oToolStripItem in parentMenu.DropDownItems)
                {
                    if (oToolStripItem is ToolStripMenuItem)
                        (oToolStripItem as ToolStripMenuItem).Checked = false;
                }
            }
        }

        #endregion
    }
}
