using System;
using System.Collections.Generic;

namespace Lab11
{
    public static class FrequencyTable
    {
        public static List<Tuple<Tuple<int, int>, int>> GetFrequencyTable(int[] data, int maxBinCount)
        {
            int maxInTable = data[0];
            int minInTable = data[0];

            foreach (int num in data)
            {
                if (maxInTable < num)
                {
                    maxInTable = num;
                }

                if (minInTable > num)
                {
                    minInTable = num;
                }
            }

            int interval = (maxInTable - minInTable) / maxBinCount + 1;

            List<Tuple<Tuple<int, int>, int>> result = new List<Tuple<Tuple<int, int>, int>>();

            int lower = minInTable;
            for (int i = 0; i < maxBinCount; i++)
            {
                int upper = lower + interval;

                if (lower > maxInTable)
                {
                    break;
                }

                Tuple<int, int> keyTuple = new Tuple<int, int>(lower, upper);
                int count = 0;
                foreach (int num in data)
                {
                    if (num >= lower & num < upper)
                    {
                        count += 1;
                    }
                }

                result.Add(new Tuple<Tuple<int, int>, int>(keyTuple, count));
                
                lower = upper;
            }

            return result;

        }
    }
}