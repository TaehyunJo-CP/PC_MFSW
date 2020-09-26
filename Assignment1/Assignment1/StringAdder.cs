using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class StringAdder
    {
        public string Result { get; }
        public string NotTrimedResult { get; }

        public StringAdder(string a, string b, int digit)
        {
            StringBuilder sb = new StringBuilder();

            int aLength = a.Length;
            int bLength = b.Length;

            int biggerLength = Math.Max(aLength, bLength);

            int aIdx;
            int bIdx;

            int aNum;
            int bNum;

            int added;

            int forNextDigitAdded = 0;

            int tenDigit;
            int oneDigit;

            for (int i = 0; i < biggerLength; i++)
            {
                aIdx = aLength - 1 - i;
                bIdx = bLength - 1 - i;

                if (aIdx >= 0)
                {
                    aNum = Int32.Parse(a[aIdx].ToString());
                }
                else
                {
                    aNum = 0;
                }

                if (bIdx >= 0)
                {
                    bNum = Int32.Parse(b[bIdx].ToString());
                }
                else
                {
                    bNum = 0;
                }

                added = aNum + bNum + forNextDigitAdded;

                tenDigit = added / digit;
                oneDigit = added % digit;

                forNextDigitAdded = tenDigit;

                sb.Append(oneDigit);

            }

            if (forNextDigitAdded != '0')
            {
                sb.Append(forNextDigitAdded);
            }

            StringBuilder resultSb = new StringBuilder();
            string toReverse = sb.ToString();
            for (int i = toReverse.Length - 1; i >= 0; i--)
            {
                resultSb.Append(toReverse[i]);
            }

            this.Result = resultSb.ToString().TrimStart('0');
            this.NotTrimedResult = resultSb.ToString();
        }


    }
}
