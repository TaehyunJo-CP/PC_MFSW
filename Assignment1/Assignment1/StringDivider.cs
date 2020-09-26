using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class StringDivider
    {
        private readonly string mNum;
        private readonly int mDivider;

        private int mTempQuotient;
        private int mTempRemainder = 0;

        public string Q { get; }
        public string R { get; }

        public StringDivider(string num, int divider)
        {
            this.mNum = num;
            this.mDivider = divider;

            StringBuilder sbResult = new StringBuilder();
            StringBuilder sbRemain = new StringBuilder();

            foreach (char c in this.mNum)
            {
                sbRemain.Append(c);
                this.DivideWithIntegers(Int32.Parse(sbRemain.ToString()), this.mDivider);

                if (this.mTempQuotient > 0)
                {
                    sbRemain = new StringBuilder();
                    sbRemain.Append(this.mTempRemainder);
                }
                //else
                //{
                //    sbRemain.Append(this.remainder);
                //}

                sbResult.Append(this.mTempQuotient);

            }

            Q = sbResult.ToString().TrimStart('0');
            if (Q == "")
            {
                Q = "0";
            }
            R = mTempRemainder.ToString();

        }



        public void DivideWithIntegers(int num, int divider)
        {
            this.mTempQuotient = num / divider;
            this.mTempRemainder = num % divider;
        }


    }
}
