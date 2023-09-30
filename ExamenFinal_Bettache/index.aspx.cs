using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinal_Bettache
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {       
                if (!IsPostBack)
                {

                }

        }

        protected void btnValider_Click(object sender, EventArgs e)
        {
            string type = dltypeCarte.Text;
            string numero = txtNumerCarte.Text;
            string date = txtDate.Text;
            string montant = txtMontant.Text;

         

            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(date) ||
                string.IsNullOrEmpty(montant))
            {
                lblChamps.Text = "Tous les champs sont requis!";
                return;
            }

            // Mettez à jour l'image en fonction du type de carte sélectionné
            if (type == "Master Card")
            {
               imgCarte.ImageUrl = "~/images/mastercard.png";
            }
            else if (type == "Visa")
            {
                imgCarte.ImageUrl = "~/images/visa.png";
            }
            else if (type == "American Express")
            {
                imgCarte.ImageUrl = "~/images/amex.png";
            }




            if (!IsValidDateExpiration(date))
            {
                lblChamps.Text = "La date d'expiration doit être au format MM/AAAA et supérieure à la date courante.";
                return;
            }
            if (!IsValidMontant(montant))
            {
                lblChamps.Text = "Le montant doit être un entier positif compris entre 100 et 10000.";
                return;
            }

            // Validez en fonction du type de carte
            bool carteValide = false;

            if (type == "Master Card" && IsValidMasterCard(numero))
            {
                carteValide = true;
               // imgCarte.ImageUrl = "~/images/mastercard.png";
            }
            else if (type == "Visa" && IsValidVisa(numero))
            {
                carteValide = true;
                //imgCarte.ImageUrl = "~/images/visa.png";
            }
            else if (type == "American Express" && IsValidAmericanExpress(numero))
            {
                carteValide = true;
               // imgCarte.ImageUrl = "~/images/amex.png";
            }

            if (carteValide)
            {
                lblChamps.Text = "Les informations saisies sont valides.";
            }
            else
            {
                lblChamps.Text = "Le numéro de carte n'est pas valide pour le type de carte sélectionné.";
            }
        }




        private bool IsValidDateExpiration(string dateExpiration)
        {
            if (DateTime.TryParseExact(dateExpiration, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
            {
                return expDate > DateTime.Now;
            }
            return false;
        }

      
        private bool IsValidMontant(string montantText)
        {
            if (int.TryParse(montantText, out int montant))
            {
                return montant >= 100 && montant <= 10000;
            }
            return false;
        }

        // Méthode de validation pour MasterCard
        private bool IsValidMasterCard(string numeroCarte)
        {
            if (Regex.IsMatch(numeroCarte, @"^5[1-5]\d{14}$"))
            {
                return true;
            }
            return false;
        }

        // Méthode de validation pour Visa
        private bool IsValidVisa(string numeroCarte)
        {
            if (Regex.IsMatch(numeroCarte, @"^(4\d{12}(\d{3})?)$"))
            {
                return true;
            }
            return false;
        }

        // Méthode de validation pour American Express
        private bool IsValidAmericanExpress(string numeroCarte)
        {
            if (Regex.IsMatch(numeroCarte, @"^3[47]\d{13}$"))
            {
                return true;
            }
            return false;
        }


    }
}