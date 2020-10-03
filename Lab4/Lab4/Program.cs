using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                MultiSet set = new MultiSet();

                set.Add("cattle");
                set.Add("bee");
                set.Add("cattle");
                set.Add("bee");
                set.Add("happy");
                set.Add("zachariah");

                Debug.Assert(set.Remove("zachariah"));
                Debug.Assert(!set.Remove("fun"));

                Debug.Assert(set.GetMultiplicity("cattle") == 2);

                List<string> expectedList = new List<string> { "bee", "bee", "cattle", "cattle", "happy" };
                List<string> list = set.ToList();

                Debug.Assert(list.Count == 5);

                for (int i = 0; i < expectedList.Count; i++)
                {
                    Debug.Assert(expectedList[i] == list[i]);
                }

                MultiSet set2 = new MultiSet();

                set2.Add("cattle");
                set2.Add("cattle");
                set2.Add("bee");

                list = set.Union(set2).ToList();
                Debug.Assert(list.Count == 5);

                for (int i = 0; i < expectedList.Count; i++)
                {
                    Debug.Assert(expectedList[i] == list[i]);
                }

                expectedList = new List<string> { "bee", "cattle", "cattle" };
                list = set.Intersect(set2).ToList();
                Debug.Assert(list.Count == 3);

                for (int i = 0; i < expectedList.Count; i++)
                {
                    Debug.Assert(expectedList[i] == list[i]);
                }

                expectedList = new List<string> { "bee", "happy" };
                list = set.Subtract(set2).ToList();
                Debug.Assert(list.Count == 2);

                for (int i = 0; i < expectedList.Count; i++)
                {
                    Debug.Assert(expectedList[i] == list[i]);
                }

                List<MultiSet> expectedPowerset = getExpectedPowerset();
                List<MultiSet> set2PowerSet = set2.FindPowerSet();
                Debug.Assert(set2PowerSet.Count == expectedPowerset.Count);

                for (int i = 0; i < expectedPowerset.Count; i++)
                {
                    expectedList = expectedPowerset[i].ToList();
                    list = set2PowerSet[i].ToList();

                    Debug.Assert(expectedList.Count == list.Count);

                    for (int j = 0; j < expectedList.Count; j++)
                    {
                        Debug.Assert(expectedList[j] == list[j]);
                    }
                }

                Debug.Assert(!set.IsSubsetOf(set2));
                Debug.Assert(set.IsSupersetOf(set2));
            }

            // wiki
            {
                var set1 = new MultiSet();
                set1.Add("a");
                set1.Add("a");
                set1.Add("b");
                set1.Add("c");
                set1.Add("c");
                set1.Add("c");
                var set2 = new MultiSet();
                set2.Add("a");
                set2.Add("a");
                set2.Add("a");
                set2.Add("a");
                set2.Add("b");
                set2.Add("c");

                var interSet = set1.Intersect(set2);
                var interSetList = interSet.ToList();

                var expectedElements = new string[] { "a", "a", "b", "c" };
                Debug.Assert(interSetList.Count == 4);
                for (int i = 0; i < expectedElements.Length; i++)
                {
                    Debug.Assert(expectedElements[i] == interSetList[i]);
                }

            }

            { 
                MultiSet emptySet = new MultiSet();
                List<string> emptySetList = emptySet.ToList();
                Debug.Assert(emptySetList.Count == 0);

                List<MultiSet> powerSetOfEmptySet = emptySet.FindPowerSet();
                Debug.Assert(powerSetOfEmptySet.Count == 1);
                emptySetList = powerSetOfEmptySet[0].ToList();
                Debug.Assert(emptySetList.Count == 0);
            }

            {
                MultiSet set = new MultiSet();
                set.Add("a");
                set.Add("b");
                set.Add("c");
                set.Add("d");
                set.Add("e");
                List<MultiSet> powerSet = set.FindPowerSet();
                Debug.Assert(powerSet.Count == 32);

                MultiSet set2 = new MultiSet();
                set2.Add("a");
                set2.Add("b");
                set2.Add("c");
                set2.Add("b");
                set2.Add("a");
                List<MultiSet> powerSet2 = set2.FindPowerSet();
                Debug.Assert(powerSet2.Count == 18);

            }

            {
                MultiSet set = new MultiSet();

                set.Add("a");
                set.Add("a");
                set.Add("b");
                set.Add("c");

                List<MultiSet> powerSet = set.FindPowerSet();
                Debug.Assert(powerSet.Count == 12);
            }



            System.Console.WriteLine("Done");
        }

        private static List<MultiSet> getExpectedPowerset()
        {
            List<MultiSet> powerset = new List<MultiSet>();

            MultiSet set = new MultiSet();
            powerset.Add(set);

            set = new MultiSet();
            set.Add("bee");

            powerset.Add(set);

            set = new MultiSet();
            set.Add("bee");
            set.Add("cattle");

            powerset.Add(set);

            set = new MultiSet();
            set.Add("bee");
            set.Add("cattle");
            set.Add("cattle");

            powerset.Add(set);

            set = new MultiSet();
            set.Add("cattle");

            powerset.Add(set);

            set = new MultiSet();
            set.Add("cattle");
            set.Add("cattle");

            powerset.Add(set);

            return powerset;
        }
    }
}