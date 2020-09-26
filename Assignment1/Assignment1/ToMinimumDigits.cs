using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class ToMinimumDigits
    {
        public static string MakeBinaryOrNull(string binaryNum)
        {

            if (binaryNum.StartsWith("0b"))
            {
                StringBuilder sb = new StringBuilder("0b");

                char firstChar = binaryNum[2];
                sb.Append(firstChar);

                bool bIsContinue = true;

                foreach (char c in binaryNum.Substring(3))
                {
                    if (c == firstChar && bIsContinue)
                    {
                        continue;
                    }
                    else if (c != firstChar && bIsContinue)
                    {
                        bIsContinue = false;
                    }

                    sb.Append(c);
                }

                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

    }
}
