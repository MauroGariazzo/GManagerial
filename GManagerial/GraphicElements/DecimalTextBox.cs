using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    internal class DecimalTextBox : TextBox
    {
        private decimal maxValue;
        private string tempString;
        private StringBuilder sb;
        private string maxValueString;
        private int numOfDigit;
        public DecimalTextBox(decimal maxValue)
        {
            this.maxValue = maxValue;
            this.tempString = this.Text;
            this.sb = new StringBuilder(this.Text);
            this.maxValueString = maxValue.ToString();
            this.numOfDigit = this.maxValueString.Length;
        }

        protected override void OnKeyPress(KeyPressEventArgs kpe)
        {
            if (kpe.KeyChar.Equals('.')) //se è un punto lo trasformo in virgola
            {
                kpe.KeyChar = ',';
            }

            if (!char.IsControl(kpe.KeyChar) && !char.IsDigit(kpe.KeyChar) && kpe.KeyChar != ',') //se il carattere non è un numero o la virgola impedisco l'inserimento
            {
                kpe.Handled = true;
                return;
            }

            //se è un numero
            tempString = this.Text;
            if (char.IsDigit(kpe.KeyChar))
            {
                sb = new StringBuilder(this.Text);
                sb.Insert(this.SelectionStart, kpe.KeyChar);
                tempString = sb.ToString();

                if (CheckIfUserInputIsGreaterThenMaxValue(tempString) || CheckIfIntegersNumsIsGreaterThanFour(tempString)) // se è più grande di 1000
                {
                    if (!CheckIfCommaIsPresent())
                    {
                        if (this.SelectionLength.Equals(0))
                        {
                            sb = new StringBuilder(this.Text);
                            sb.Insert(this.Text.Length, ',');
                            tempString = sb.ToString();
                        }

                        else
                        {
                            sb = new StringBuilder(this.Text);
                            sb.Remove(this.SelectionStart, this.SelectionLength);
                            sb.Insert(this.SelectionStart, ',');
                            tempString = sb.ToString();
                        }

                        if (CheckIfUserInputIsGreaterThenMaxValue(tempString) && this.SelectionLength.Equals(0))
                        {
                            kpe.Handled = true;
                            return;
                        }

                        if (!tempString.Equals(","))
                        {
                            this.Text = tempString;
                            this.SelectionStart = this.Text.Length;
                        }
                    }

                    else
                    {
                        if (this.SelectionLength.Equals(0))
                        {
                            sb = new StringBuilder(this.Text);
                            sb.Insert(this.SelectionStart, kpe.KeyChar);
                            tempString = sb.ToString();
                        }

                        else
                        {
                            sb = new StringBuilder(this.Text);
                            sb.Remove(this.SelectionStart, this.SelectionLength);
                            sb.Insert(this.SelectionStart, kpe.KeyChar);
                            tempString = sb.ToString();
                        }

                        if (CheckIfIntegersNumsIsGreaterThanFour(tempString) && this.SelectionLength.Equals(0) || CheckIfUserInputIsGreaterThenMaxValue(tempString))
                        {
                            kpe.Handled = true;
                            return;
                        }
                    }
                }

                else if (CheckIfCommaIsPresent())
                {
                    if (this.SelectionStart > IndexComma(tempString) && CheckIfNumOfDecimalsIsThree(tempString))
                    {
                        if (this.SelectionLength.Equals(0))
                        {
                            sb = new StringBuilder(this.Text);
                            sb.Insert(this.SelectionStart, kpe.KeyChar);
                            tempString = sb.ToString();
                        }

                        else
                        {
                            sb = new StringBuilder(this.Text);
                            sb.Remove(this.SelectionStart, this.SelectionLength);
                            sb.Insert(this.SelectionStart, kpe.KeyChar);
                            tempString = sb.ToString();
                        }

                        if (CheckIfNumOfDecimalsIsThree(tempString))
                        {
                            kpe.Handled = true;
                            return;
                        }
                    }
                }

            }

            //se è una virgola
            else if (kpe.KeyChar.Equals(','))
            {
                if (this.Text.Contains(','))
                {
                    kpe.Handled = true;
                    return;
                }
            }

        }



        private bool CheckIfNumOfDecimalsIsThree(string tempString)
        {
            int commaIndex = IndexComma(tempString);
            if (commaIndex != -1)
            {
                string subString = tempString.Substring(commaIndex, (tempString.Length - 1) - commaIndex);

                if (subString.Length >= 3)
                {
                    return true;
                }

                return false;
            }
            return false;
        }





        protected override void OnKeyDown(KeyEventArgs kea)
        {
            if (kea.KeyCode != Keys.Back && kea.KeyCode != Keys.Delete && kea.KeyCode != Keys.Left && kea.KeyCode != Keys.Right && kea.KeyCode != Keys.End && kea.KeyCode != Keys.Home)
            {
                kea.Handled = true;
            }

            else if (kea.KeyCode == Keys.Back)
            {
                int selectionStart = GetSelectionStart();
                MoveCaret(kea, selectionStart);
            }

            else if (kea.KeyCode == Keys.Delete)
            {
                MoveCaret(kea, this.SelectionStart);
            }
        }

        private void MoveCaret(KeyEventArgs kea, int selectionStart)
        {
            tempString = this.Text;
            int selectionLength = GetSelectionLength();
            try
            {
                tempString = tempString.Remove(selectionStart, selectionLength);
            }

            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }

            if (CheckIfUserInputIsGreaterThenMaxValue(tempString) || (tempString.Length > numOfDigit && !tempString.Contains(",")))
            {
                kea.SuppressKeyPress = true;
                this.SelectionStart -= 1;
                this.SelectionLength = 0;
            }
        }

        private int GetSelectionStart()
        {
            if (this.SelectionStart > 0 && this.SelectionLength > 0 && this.Text != string.Empty)
            {
                return this.SelectionStart;
            }

            if (this.SelectionStart > 0 && this.Text != string.Empty)
            {
                return this.SelectionStart - 1;
            }

            return this.SelectionStart;
        }

        private int GetSelectionLength()
        {
            if (this.SelectionLength == 0 && this.Text != string.Empty)
            {
                return 1;
            }

            return this.SelectionLength;

        }

        private bool CheckIfIntegersNumsIsGreaterThanFour(string tempString)
        {
            if (!CheckIfCommaIsPresent())
            {
                string subString = tempString.Substring(0, tempString.Length);
                if (subString.Length > numOfDigit)
                {
                    return true;
                }
            }

            else if (tempString.Length >= numOfDigit && !CheckIfCommaIsPresent())
            {
                return true;
            }


            else if (tempString.Length >= numOfDigit && CheckIfCommaIsPresent())
            {
                string subString = tempString.Substring(0, IndexComma(tempString));
                if (subString.Length > numOfDigit)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckIfUserInputIsGreaterThenMaxValue(string tempString)
        {
            decimal result;
            if (decimal.TryParse(tempString, out result))
            {
                if (result > maxValue)
                {
                    return true;
                }
            }
            return false;
        }


        private bool CheckIfCommaIsPresent()
        {
            if (this.Text.Contains(','))
            {
                return true;
            }

            return false;
        }

        private int IndexComma(string tempString)
        {
            int commaIndex = tempString.IndexOf(',');
            return commaIndex;
        }
    }
}
