using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.GraphicElements
{
    internal class IntTextBox:TextBox
    { 
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete) //se l'input è diverso da un numero e dal tasto delete e il canc
            {
                e.Handled = true; //impedisci l'inserimento del carattere
                return;
            }
        }
    }
}
