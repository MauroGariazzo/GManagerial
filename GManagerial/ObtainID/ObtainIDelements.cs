using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.ObtainID
{
    class ObtainIDelements
    {
        static public int ObtainIdElement(int selectedRowIndex, DataGridView dgv, string IDform)
        {
            if (dgv.SelectedRows.Count >= 1)
            {
                try
                {
                    int element_ID = Convert.ToInt32(dgv.Rows[selectedRowIndex].Cells[IDform].Value);
                    return element_ID;
                }

                catch 
                {
                    return -1;
                }
            }

            return 0;
        }
    }
}
