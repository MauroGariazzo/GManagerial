using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    static internal class CustomerDgw
    {
        static public void DisableDgw(Control.ControlCollection controls, ToolStripButton btnFcs)   //metodo per disattivare tutti i datagridview che non appartengono al menù cliccato
        {
            foreach (Control control in controls)
            {
                if (control is DataGridView dgw)
                {
                    if (btnFcs.Name + "Dgw" != dgw.Name)
                    {
                        dgw.Visible = false;
                    }
                }
            }
        }

        static public void DisableAllDgw(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is DataGridView dgw)
                {
                    dgw.Visible = false;
                }
            }

        }


        static public void EnableDgw(DataGridView dgw)
        {
            dgw.Visible = true;
        }
    }
}
