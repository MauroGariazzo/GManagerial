using GManagerial.ObtainID;
using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    class RowLogic
    {
        static public void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e, DataGridView DGV, List<int> idDGVRows)
             //onclick di una cella che è una checkbox -> //rowlogic
        {         
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)DGV.Rows[e.RowIndex].Cells["chkColumn"];
                chkCell.Value = !Convert.ToBoolean(chkCell.Value);

                if (Convert.ToBoolean(chkCell.Value))  //selezionare la checkbox
                {
                    idDGVRows.Add(e.RowIndex);
                    //idDBRows.Add(idProduct);

                    if (!MultipleRowsSelect(idDGVRows, DGV))
                    {
                        MessageBox.Show("Qualcosa è andato storto =(");
                        chkCell.Value = false; //disattivo la cella per sicurezza
                        idDGVRows.Clear();   //svuoto la lista
                    }
                }


                else     //deselezionare la checkbox
                {
                    try
                    {
                        idDGVRows.Remove(e.RowIndex);
                        MultipleRowsSelect(idDGVRows, DGV);

                        DGV.Rows[e.RowIndex].Selected = false;
                    }

                    catch (System.ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("Qualcosa è andato storto =(");
                        chkCell.Value = false;
                    }

                }
            
        }


        static public Boolean MultipleRowsSelect(List<int> idRows, DataGridView DGV)  //rowlogic
        {
            foreach (int row in idRows)
            {
                try
                {
                    DGV.Rows[row].Selected = true;
                }

                catch (System.ArgumentOutOfRangeException)
                {
                    return false;
                }

            }
            return true;
        }



        static public void DGV_CellClick(object sender, DataGridViewCellEventArgs e)//onclick di una cella che NON sia una checkbox
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)  //all'onclick della checkbox l'evento cellclick viene comunque richiamato
            {                                           //di conseguenza se sta cliccando sulla checkbox deve uscire dal metodo
                return;
            }
        }


        static public void DeselectAllCheckBox(List<int> idRows, DataGridView DGV, Boolean isDeleting = false, int selectedRow = 0)//rowlogic
        {
            int fRow = 0;

            if (idRows.Count > 0)
            {
                fRow = idRows.Min()-1;
            }

            if (isDeleting && idRows.Count > 0)
            {
                selectFirstRow(fRow, DGV);
            }

            else if (isDeleting && idRows.Count == 0)
            {
                selectFirstRow(selectedRow - 1, DGV);
            }

            idRows.Clear();
            DisableAllCheckBoxes(DGV); //disattivare tutte le box dopo che si conferma o annulla e c'è qualche checkbox attivo

        }

        static public void selectFirstRow(int fRow, DataGridView DGV)
        {
            try
            {
                DGV.Rows[fRow].Selected = true;
                if (fRow != 0)
                {
                    DGV.Rows[0].Selected = false;
                }
            }

            catch(System.ArgumentOutOfRangeException) 
            { 
                try
                {
                    DGV.Rows[0].Selected = true;
                }

                catch(System.ArgumentOutOfRangeException)
                {
                    return;
                }
            }

        }


        static public void DisableAllCheckBoxes(DataGridView DGV)   //rowlogic
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                //DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)row.Cells[0]; // Colonna della casella di controllo (indice 0)
                //chkCell.Value = false;
            }
        }

        

        static public void RowSelected(int selectedRow, DataGridView DGV, char nec = '-') // //rowlogic
        {
            if (DGV.Rows.Count > 0)
            {
                if(nec == 'c')
                {
                    DGV.Rows[DGV.Rows.Count - 1].Selected = true;
                    if (DGV.Rows[DGV.Rows.Count - 1].Index != 0)
                    {
                        DGV.Rows[0].Selected = false;
                    }
                    
                }

                else if(selectedRow != 0)
                {
                    try 
                    {
                        DGV.Rows[selectedRow].Selected = true;
                        DGV.Rows[0].Selected = false;
                    }
                    
                    catch(System.ArgumentOutOfRangeException)
                    {
                        try
                        {
                            DGV.Rows[0].Selected = true;
                        }

                        catch(System.ArgumentException)
                        {
                            return;
                        }
                    }
                }  
            }
        }

        static public void selectAllRows_CheckedChanged(CheckBox selectAllRows, DataGridView dgv, List<int>idDGVRows, List<int> idDBRows, string idForm)
        {
            if (selectAllRows.Checked)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!idDGVRows.Contains(row.Index))
                    {
                        idDGVRows.Add(row.Index);
                        idDBRows.Add(ObtainIDelements.ObtainIdElement(row.Index, dgv, idForm));
                        DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)dgv.Rows[row.Index].Cells["chkColumn"];
                        //chkCell.Value = !Convert.ToBoolean(chkCell.Value);
                        chkCell.Value = true;

                        dgv.Rows[row.Index].Selected = true;
                    }
                }
            }

            else
            {
                
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (idDGVRows.Contains(row.Index))
                    {
                        idDBRows.Remove(ObtainIDelements.ObtainIdElement(row.Index, dgv, idForm));
                        idDGVRows.Remove(row.Index);
                        DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)dgv.Rows[row.Index].Cells["chkColumn"];
                        //chkCell.Value = !Convert.ToBoolean(chkCell.Value);
                        chkCell.Value = false;
                        dgv.Rows[row.Index].Selected = false;
                        dgv.Rows[0].Selected = true;
                    }
                }
            }
        }

        static public void HowManyRows(DataGridView dgv, List<int>idDGVRows, ref int selectedRow, List<int>idDBRows) //RowLogic
        {
            if (dgv.SelectedRows.Count > 1)
            {
                foreach (DataGridViewRow rowIndex in dgv.SelectedRows)
                {
                    if (!idDGVRows.Contains(rowIndex.Index))
                    {
                        idDGVRows.Add(rowIndex.Index);
                    }

                    else
                    {
                        idDGVRows.Remove(rowIndex.Index);
                    }
                }
            }

            else
            {
                try
                {
                    selectedRow = dgv.SelectedRows[0].Index;
                }

                catch (System.ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            //moveIDfromDGVToDBList(idDBRows, idDGVRows, dgv, "Product_ID");
        }

        static public void CellContentClick(List<int> idDBRows, List<int> idDGVRows, DataGridView dgv, object sender, DataGridViewCellEventArgs e, string IDform)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {

                if (!idDBRows.Contains(ObtainIDelements.ObtainIdElement(dgv.SelectedRows[0].Index, dgv, IDform)))
                {
                    idDBRows.Add(ObtainIDelements.ObtainIdElement(dgv.SelectedRows[0].Index, dgv, IDform));
                }

                else
                {
                    idDBRows.Remove(ObtainIDelements.ObtainIdElement(dgv.SelectedRows[0].Index, dgv, IDform));
                }

                RowLogic.DGV_CellContentClick(sender, e, dgv, idDGVRows);
            }
        }

        /*static public void moveIDfromDGVToDBList(List<int> idDBRows, List<int> idDGVRows, DataGridView dgv, string idForm)
        {
            if (idDGVRows.Count > 0)
            {
                foreach (int rowIndex in idDGVRows)
                {
                    idDBRows.Add(ObtainID.ObtainIDelements.ObtainIdElement(rowIndex, dgv, idForm));
                }
            }
        }*/

        static public void DisableAllRows(DataGridView dgv)  //not checkbox
        {
            foreach(DataGridViewRow row in dgv.Rows)
            {
                if(row.Selected)
                {
                    row.Selected = false;
                }
            }
        }
    }
}
