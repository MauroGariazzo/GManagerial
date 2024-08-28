using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.Products;

namespace GManagerial.RowLogic
{
    internal class RowLogic
    {
        private DataGridView _dataGridView;
        public RowLogic(DataGridView dataGridView) 
        {
            this._dataGridView = dataGridView;
        }

        private List<int> RowsSelected(DataGridViewSelectedRowCollection rowsCollection)
        {
            List<int> _rowsSelectedList = new List<int>();

            foreach (DataGridViewRow row in rowsCollection) 
            {
                int index = row.Index;
                _rowsSelectedList.Add(index);
            }
            return _rowsSelectedList;
        }

        private int RowToSelectAfterDataGridViewItemDelete()
        {
            DataGridViewSelectedRowCollection rows = _dataGridView.SelectedRows;
            List<int> rowsSelectedList = RowsSelected(rows);
            
            int minIndex = rowsSelectedList.Max()-1;
            return minIndex;
        }


        public int SelectedRow(IsNewEditCopyDeleteEnum command)
        {

            if (command == IsNewEditCopyDeleteEnum.Delete) // if(command == 'd')
            {
                return RowToSelectAfterDataGridViewItemDelete();
            }

            return 0;
        }

 
        public int RowToSelectInDataGridView(IsNewEditCopyDeleteEnum command, int? index)
        {
            try
            {
                if (command.Equals(IsNewEditCopyDeleteEnum.Edit) || command.Equals(IsNewEditCopyDeleteEnum.Cancel))
                {
                    return (int)index;
                }

                else if (command.Equals(IsNewEditCopyDeleteEnum.New) || command.Equals(IsNewEditCopyDeleteEnum.Copy))
                {
                    return _dataGridView.Rows.Count - 1;
                }

                else if (command.Equals(IsNewEditCopyDeleteEnum.Delete))
                {
                    if (RowToSelectAfterDataGridViewItemDelete() != -1)
                    {
                        return RowToSelectAfterDataGridViewItemDelete();
                    }
                }
            }

            catch (System.ArgumentOutOfRangeException)
            {
                return 0;
            }
            return 0;
        }

    }
}
