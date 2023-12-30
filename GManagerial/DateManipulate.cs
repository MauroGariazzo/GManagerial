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
    class DateManipulate
    {
        static public void IsValiDate(object sender, TextBox tb)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            string inputDate = textBox.Text;

            DateTimeFormatInfo formatInfo = DateTimeFormatInfo.CurrentInfo;

            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };


            if (tb.Text == null || tb.Text == "")
            {
                textBox.BackColor = SystemColors.Window;
            }

            else
            {


                if (DateTime.TryParseExact(inputDate, formats, formatInfo, DateTimeStyles.None, out DateTime date))
                {
                    int selectStart = textBox.SelectionStart;
                    textBox.SelectionStart = selectStart;
                    textBox.BackColor = System.Drawing.Color.Green;
                }

                else
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        static public Boolean dateFormatting(KeyPressEventArgs e, TextBox tb)
        {
            int countSlash = tb.Text.Count(c => c == '/'); //contare gli slash
            int lastSlashIndex = tb.Text.LastIndexOf('/');  //dove si trova l'ultimo slash
            int cursorIndex = tb.SelectionStart;  //dove si trova il cursore


            if (countSlash == 2)
            {
                if (IsYear(e, lastSlashIndex, cursorIndex))  //controllo se è un anno
                {
                    string year = tb.Text.Substring(lastSlashIndex + 1, tb.Text.Length - lastSlashIndex - 1);

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
                        string stringPortion = tb.Text.Substring(0, lastSlashIndex);  //     "20/07"
                        int firstSlashIndex = stringPortion.LastIndexOf('/');

                        cursorIndex = tb.SelectionStart;    //dov'è la stanghetta?

                        if (IsMonth(e, cursorIndex, firstSlashIndex))  //controllo se è un mese
                        {
                            string month = tb.Text.Substring(firstSlashIndex + 1, stringPortion.Length - firstSlashIndex - 1);

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
                                string day = tb.Text.Substring(0, firstSlashIndex);

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
                    string stringPortion = tb.Text.Substring(0, lastSlashIndex + 1);  //     "20/07"
                    int firstSlashIndex = stringPortion.LastIndexOf('/');        //  dove si trova lo slash?
                    cursorIndex = tb.SelectionStart;    //dov'è la stanghetta?

                    if (IsMonth(e, cursorIndex, lastSlashIndex))  //controllo se è un mese
                    {
                        string month = tb.Text.Substring(firstSlashIndex + 1, stringPortion.Length - firstSlashIndex - 1);

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
                            string day = tb.Text.Substring(0, lastSlashIndex);

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

        static public Boolean IsYear(KeyPressEventArgs e, int lastSlashIndex, int cursorIndex)
        {
            if (cursorIndex > lastSlashIndex)        //è un anno
            {
                return true;
            }
            return false;
        }


        static public Boolean IsMonth(KeyPressEventArgs e, int cursorIndex, int lastSlashIndex)
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

        static public void manfDateTB_KeyPress(object sender, KeyPressEventArgs e, TextBox tb)
        {
            clearTB(tb);

            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


            else if (e.KeyChar == (char)Keys.Back)
            {
                if (tb.SelectionStart > 0)
                {
                    if (tb.Text[tb.SelectionStart - 1] == '/')
                    {
                        e.Handled = true;
                        tb.SelectionStart = tb.SelectionStart - 1;
                    }
                }
            }

            if (tb.Text.Length == 2 || tb.Text.Length == 5)  //manfDateTB.SelectionStart == 2 || manfDateTB.SelectionStart == 5
            {
                barlineLogic(sender, e, '/', tb); //logica del delimitatore che non si deve spostare a cazzo durante l'inserimento
            }

            else
            {
                dateFormatting(e, tb);
            }
        }

        static public void clearTB(TextBox tb)
        {
            if (tb.Text == "//" || tb.Text == "/")
            {
                tb.Text = "";
            }
        }

        static public void barlineLogic(object sender, KeyPressEventArgs e, char character, TextBox tb)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            if (e.KeyChar != (char)Keys.Back)
            {
                int selectionStart = textBox.SelectionStart;

                if (char.IsDigit(e.KeyChar))
                {
                    // Controlla se il carattere da inserire è un numero
                    if (textBox.Text.Length < 10 && dateFormatting(e, tb))
                    {
                        if (tb.Text.Length == 2 || tb.Text.Length == 5)
                        {
                            textBox.Text = textBox.Text.Insert(tb.Text.Length, "/" + e.KeyChar);
                            textBox.SelectionStart = selectionStart + 2;
                        }

                        else
                        {
                            textBox.Text = textBox.Text.Insert(tb.Text.Length, e.KeyChar.ToString());
                            textBox.SelectionStart = selectionStart + 1;
                        }
                    }
                }

                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Delete)
            {
                int selectionStart = textBox.SelectionStart;

                if (selectionStart > 0 && selectionStart < textBox.Text.Length && textBox.Text[selectionStart] == '/')
                {
                    textBox.Text = textBox.Text.Remove(selectionStart, 1);
                    textBox.SelectionStart = selectionStart;
                    e.Handled = true;
                }
            }
        }

        static public void manfDateTB_KeyDown(object sender, KeyEventArgs e, TextBox tb)
        {
            clearTB(tb);

            if (e.KeyCode == Keys.Delete)
            {
                if (tb.SelectionStart != tb.Text.Length)
                {
                    if (tb.Text[tb.SelectionStart] == '/')
                    {
                        tb.SelectionStart = tb.SelectionStart + 1;
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
