using System;
using System.Text;

namespace Assignment1
{
    public class StringMultiplication
    {
        public string Result { get; }

        public StringMultiplication(string a, string b)
        {
            int aLength = a.Length;
            int bLength = b.Length;

            int aIdx;
            int bIdx;

            int aNum;
            int bNum;

            int toBeAdded;

            string result = "0";

            for (int i = 0; i < aLength; i++)
            {
                for (int j = 0; j < bLength; j++)
                {
                    aIdx = aLength - 1 - i;
                    bIdx = bLength - 1 - j;

                    aNum = Int32.Parse(a[aIdx].ToString());
                    bNum = Int32.Parse(b[bIdx].ToString());

                    toBeAdded = aNum * bNum;
                    StringBuilder sb = new StringBuilder(toBeAdded.ToString());
                    for (int k = 0; k < i + j; k++)
                    {
                        sb.Append("0");
                    }

                    StringAdder sa = new StringAdder(result, sb.ToString(), 10);
                    result = sa.Result;
                }
            }

            this.Result = result;
        }
    }
}
