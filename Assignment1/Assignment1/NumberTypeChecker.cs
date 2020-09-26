using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class NumberTypeChecker
    {
        private NumberType numberType;
        private string numberPart;
        private bool hasNegativeSign = false;

        public NumberTypeChecker(string num)
        {
            this.SetNumberTypeAndNumberPart(num);
        }

        public NumberType NumberType { get => numberType; set => numberType = value; }
        public string NumberPart { get => numberPart; set => numberPart = value; }
        public bool HasNegativeSign { get => hasNegativeSign; set => hasNegativeSign = value; }

        public void SetNumberTypeAndNumberPart(string num)
        {
            if (num == null || num.Length == 0)
            {
                this.NumberType = NumberType.None;
            }
            else if (num[0] == '0')
            {
                if (num.Length > 2)
                {
                    if (num[1] == 'b')
                    {
                        this.NumberType = NumberType.Binary;
                        this.NumberPart = num.Substring(2);

                    }
                    else if (num[1] == 'x')
                    {
                        this.NumberType = NumberType.Hex;
                        this.NumberPart = num.Substring(2);
                    }
                    else
                    {
                        this.NumberType = NumberType.None;
                    }

                }
                else if (num.Length == 1)
                {
                    this.NumberType = NumberType.Decimal;
                    this.NumberPart = num.Substring(0);
                }
                else
                {
                    this.NumberType = NumberType.None;
                }
            }
            else if (num[0] == '-')
            {
                if (num.Length >= 2 && num[1] != '0')
                {
                    this.NumberType = NumberType.Decimal;
                    this.hasNegativeSign = true;
                    this.NumberPart = num.Substring(1);
                }
                else
                {
                    this.NumberType = NumberType.None;
                }
            }
            else
            {
                this.NumberType = NumberType.Decimal;
                this.NumberPart = num.Substring(0);
            }


            if (this.NumberType == NumberType.Decimal)
            {
                foreach (char c in NumberPart)
                {
                    if (!char.IsDigit(c))
                    {
                        this.NumberType = NumberType.None;
                    }
                }
            }
            else if (this.NumberType == NumberType.Hex)
            {
                foreach (char c in NumberPart)
                {
                    char lowerC = char.ToLower(c);
                    if (char.IsDigit(lowerC))
                    {
                    }
                    else if (lowerC == 'a' || lowerC == 'b' || lowerC == 'c' || lowerC == 'd' || lowerC == 'e' || lowerC == 'f')
                    {
                    }
                    else
                    {
                        this.NumberType = NumberType.None;
                    }
                }
            }
            else if (this.NumberType == NumberType.Binary)
            {
                foreach (char c in NumberPart)
                {
                    if (c == '1' || c == '0')
                    {
                    }
                    else
                    {
                        this.NumberType = NumberType.None;
                    }
                }
            }








            //if (num.StartsWith("0b"))
            //{
            //    this.NumberPart = num.Substring(2);
            //    this.NumberType = NumberType.Binary;
            //}
            //else if (num.StartsWith("0x"))
            //{
            //    this.NumberPart = num.Substring(2);
            //    this.NumberType = NumberType.Hex;
            //}
            //else
            //{
            //    if (num.Length > 0 && num[0] == '-')
            //    {
            //        this.HasNegativeSign = true;
            //        this.NumberPart = num.Substring(1);
            //    }
            //    else
            //    {
            //        this.NumberPart = num.Substring(0);
            //    }
            //    this.NumberType = NumberType.Decimal;
            //}

            //if (NumberPart.Length == 0)
            //{
            //    this.NumberType = NumberType.None;
            //}

            //if (this.NumberType == NumberType.Decimal)
            //{
            //    foreach (char c in NumberPart)
            //    {
            //        if (!char.IsDigit(c))
            //        {
            //            this.NumberType = NumberType.None;
            //        }
            //    }
            //}
            //else if (this.NumberType == NumberType.Hex)
            //{
            //    foreach (char c in NumberPart)
            //    {
            //        char lowerC = char.ToLower(c);
            //        if (char.IsDigit(lowerC))
            //        {
            //        }
            //        else if (lowerC == 'a' || lowerC == 'b' || lowerC == 'c' || lowerC == 'd' || lowerC == 'e' || lowerC == 'f')
            //        {
            //        }
            //        else
            //        {
            //            this.NumberType = NumberType.None;
            //        }
            //    }
            //}
            //else if (this.NumberType == NumberType.Binary)
            //{
            //    foreach (char c in NumberPart)
            //    {
            //        if (c == '1' || c == '0')
            //        {
            //        }
            //        else
            //        {
            //            this.NumberType = NumberType.None;
            //        }
            //    }
            //}

        }


    }
}
