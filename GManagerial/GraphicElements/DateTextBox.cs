using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    internal class DateTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            ClearTextBox();

            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


            else if (e.KeyChar == (char)Keys.Back)
            {
                if (this.SelectionStart > 0)
                {
                    if (this.Text[this.SelectionStart - 1] == '/')
                    {
                        e.Handled = true;
                        this.SelectionStart = this.SelectionStart - 1;
                    }
                }
            }

            if (this.Text.Length == 2 || this.Text.Length == 5)  //manfDateTB.SelectionStart == 2 || manfDateTB.SelectionStart == 5
            {
                BarlineLogic(e); //logica del delimitatore che non si deve spostare a cazzo durante l'inserimento
            }

            else
            {
                DateFormatting(e);
            }
        }

        private void BarlineLogic(KeyPressEventArgs e)
        {
            //System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            if (e.KeyChar != (char)Keys.Back)
            {
                int selectionStart = this.SelectionStart;

                if (char.IsDigit(e.KeyChar))
                {
                    // Controlla se il carattere da inserire è un numero
                    if (this.Text.Length < 10 && DateFormatting(e))
                    {
                        if (this.Text.Length == 2 || this.Text.Length == 5)
                        {
                            this.Text = this.Text.Insert(this.Text.Length, "/" + e.KeyChar);
                            this.SelectionStart = selectionStart + 2;
                        }

                        else
                        {
                            this.Text = this.Text.Insert(this.Text.Length, e.KeyChar.ToString());
                            this.SelectionStart = selectionStart + 1;
                        }
                    }
                }

                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Delete)
            {
                int selectionStart = this.SelectionStart;

                if (selectionStart > 0 && selectionStart < this.Text.Length && this.Text[selectionStart] == '/')
                {
                    this.Text = this.Text.Remove(selectionStart, 1);
                    this.SelectionStart = selectionStart;
                    e.Handled = true;
                }
            }
        }

        private Boolean DateFormatting(KeyPressEventArgs e)
        {
            int countSlash = this.Text.Count(c => c == '/'); //contare gli slash
            int lastSlashIndex = this.Text.LastIndexOf('/');  //dove si trova l'ultimo slash
            int cursorIndex = this.SelectionStart;  //dove si trova il cursore


            if (countSlash == 2)
            {
                if (IsYear(lastSlashIndex, cursorIndex))  //controllo se è un anno
                {
                    string year = this.Text.Substring(lastSlashIndex + 1, this.Text.Length - lastSlashIndex - 1);

                    if (year.Length == 4 && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                        return false;
                    }

                    return true;
                }

                else
                {
                    if (lastSlashIndex != -1)
                    {
                        string stringPortion = this.Text.Substring(0, lastSlashIndex);  //     "20/07"
                        int firstSlashIndex = stringPortion.LastIndexOf('/');

                        cursorIndex = this.SelectionStart;    //dov'è la stanghetta?

                        if (IsMonth(cursorIndex, firstSlashIndex))  //controllo se è un mese
                        {
                            string month = this.Text.Substring(firstSlashIndex + 1, stringPortion.Length - firstSlashIndex - 1);

                            if (month.Length == 2 && e.KeyChar != (char)Keys.Back)
                            {
                                e.Handled = true;
                                return false;
                            }
                            return true;
                        }

                        else
                        {
                            if (lastSlashIndex != -1)
                            {
                                string day = this.Text.Substring(0, firstSlashIndex);

                                if (day.Length == 2 && e.KeyChar != (char)Keys.Back)
                                {
                                    e.Handled = true;
                                    return false;
                                }
                                return true;
                            }
                        }
                    }
                }
            }

            else
            {
                if (lastSlashIndex != -1)
                {
                    string stringPortion = this.Text.Substring(0, lastSlashIndex + 1);  //     "20/07"
                    int firstSlashIndex = stringPortion.LastIndexOf('/');        //  dove si trova lo slash?
                    cursorIndex = this.SelectionStart;    //dov'è la stanghetta?

                    if (IsMonth(cursorIndex, lastSlashIndex))  //controllo se è un mese
                    {
                        string month = this.Text.Substring(firstSlashIndex + 1, stringPortion.Length - firstSlashIndex - 1);

                        if (month.Length == 2 && e.KeyChar != (char)Keys.Back)
                        {
                            e.Handled = true;
                            return false;
                        }

                        return true;
                    }

                    else
                    {
                        if (lastSlashIndex != -1)
                        {
                            string day = this.Text.Substring(0, lastSlashIndex);

                            if (day.Length == 2 && e.KeyChar != (char)Keys.Back)
                            {
                                e.Handled = true;
                                return false;
                            }

                            return true;
                        }
                    }
                }
            }
            return true;
        }

        private Boolean IsYear(int lastSlashIndex, int cursorIndex)
        {
            if (cursorIndex > lastSlashIndex)        //è un anno
            {
                return true;
            }
            return false;
        }


        static public Boolean IsMonth(int cursorIndex, int lastSlashIndex)
        {
            if (lastSlashIndex != -1)
            {
                if (cursorIndex > lastSlashIndex)  //è un mese   
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            ClearTextBox();

            if (e.KeyCode == Keys.Delete)
            {
                if (this.SelectionStart != this.Text.Length)
                {
                    if (this.Text[this.SelectionStart] == '/')
                    {
                        this.SelectionStart = this.SelectionStart + 1;
                        e.Handled = true;
                    }
                }
            }
        }

        private void ClearTextBox()
        {
            if (this.Text == "//" || this.Text == "/")
            {
                this.Text = string.Empty;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            //System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            string inputDate = this.Text;

            DateTimeFormatInfo formatInfo = DateTimeFormatInfo.CurrentInfo;

            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };


            if (this.Text == null || this.Text == "")
            {
                this.BackColor = SystemColors.Window;
            }

            else
            {


                if (DateTime.TryParseExact(inputDate, formats, formatInfo, DateTimeStyles.None, out DateTime date))
                {
                    int selectStart = this.SelectionStart;
                    this.SelectionStart = selectStart;
                    this.BackColor = System.Drawing.Color.Green;
                }

                else
                {
                    this.BorderStyle = BorderStyle.FixedSingle;
                    this.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
