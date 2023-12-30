using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial
{
    class WMCLink  //Whatsapp,Mail,Calls Link Redirect
    {
        static public void whatsappChat_Click(System.Windows.Forms.TextBox mobileBox)
        {
            string mobilePhone = mobileBox.Text;

            if (!string.IsNullOrWhiteSpace(mobilePhone))
            {
                mobilePhone = mobilePhone.Replace("+", "").Replace(" ", "").Trim();

                string urlWhatsAppWeb = $"https://web.whatsapp.com/send?phone={mobilePhone}";

                System.Diagnostics.Process.Start(urlWhatsAppWeb);
            }
            else
            {
                MessageBox.Show("Inserisci un numero di telefono valido.");
            }
        }

        static public void mailBtn_Click(System.Windows.Forms.TextBox mailBox)
        {
            string mailAddress = mailBox.Text;

            if (!string.IsNullOrWhiteSpace(mailAddress))
            {
                string urlEmail = $"mailto:{mailAddress}";

                System.Diagnostics.Process.Start(urlEmail);
            }
            else
            {
                MessageBox.Show("Inserisci un indirizzo email valido.");
            }
        }

        static public void phoneBtn_Click(System.Windows.Forms.TextBox telBox)
        {
            string phoneNumber = telBox.Text;

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

                string phoneUrl = $"tel:{phoneNumber}";

                System.Diagnostics.Process.Start(phoneUrl);
            }
            else
            {
                MessageBox.Show("Inserisci un numero di telefono valido.", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
