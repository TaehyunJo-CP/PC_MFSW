using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class StringDivider
    {
        private readonly string num;
        private readonly int divider;

        private int tempQuotient;
        private int tempRemainder = 0;

        public string Q { get; }
        public string R { get; }

        public StringDivider(string num, int divider)
        {
            this.num = num;
            this.divider = divider;

            StringBuilder sbResult = new StringBuilder();
            StringBuilder sbRemain = new StringBuilder();

            foreach (char c in this.num)
            {
                sbRemain.Append(c);
                this.DivideWithIntegers(Int32.Parse(sbRemain.ToString()), this.divider);

                if (this.tempQuotient > 0)
                {
                    sbRemain = new StringBuilder();
                    sbRemain.Append(this.tempRemainder);
                }
                //else
                //{
                //    sbRemain.Append(this.remainder);
                //}

                sbResult.Append(this.tempQuotient);

            }

            Q = sbResult.ToString().TrimStart('0');
            if (Q == "")
            {
                Q = "0";
            }
            R = tempRemainder.ToString();

        }



        public void DivideWithIntegers(int num, int divider)
        {
            this.tempQuotient = num / divider;
            this.tempRemainder = num % divider;
        }


    }
}
