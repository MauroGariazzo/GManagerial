using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.ChildFormLogic
{
    class ChildFormLogic
    {
        static public void OpenChildForm(Form ChildForm, Panel panelDesktop)
        {
            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.RemoveAt(0);
            }

            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(ChildForm);
            ChildForm.Show();
        }
    }
}
