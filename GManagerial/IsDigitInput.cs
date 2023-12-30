using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    class IsDigitInput
    {
        static public void OnlyNums_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && !IsCtrlShortcut(e.KeyChar) && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;             
            }

            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }


        static public bool IsCtrlShortcut(char keyChar)
        {
            return keyChar == '\u0001' || keyChar == '\u0003' || keyChar == '\u0016' || keyChar == '\u0018';
        }

        static public void CapBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Impedisce l'inserimento del carattere non numerico
            }
        }

        static public void priceTB_KeyPress(object sender, KeyPressEventArgs e, TextBox price)
        {
            if (e.KeyChar == ',')
            {
                if (!price.Text.Contains(','))
                {
                    e.Handled = false;
                }

                else
                {
                    e.Handled = true;
                }
            }

            else if (e.KeyChar == '.')
            {
                if (!price.Text.Contains(','))
                {
                    e.KeyChar = ',';
                }

                else
                {
                    e.Handled = true;
                }

            }

            else if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        static public bool Parse(TextBox tb)
        {
            try
            {
                int result = int.Parse(tb.Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
