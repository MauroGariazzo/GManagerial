using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.GraphicElements
{
    internal class SearchTextBox:TextBox
    {
        private bool _isActive;

        public SearchTextBox()
        {
            this.Text = "Cerca";
        }
        protected override void OnClick(EventArgs e)
        {
            this.Text = string.Empty;
            _isActive = true;
        }
    }
}
