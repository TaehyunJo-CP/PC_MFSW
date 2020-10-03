using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public sealed class MultiSet
    {
        private List<string> mElements = new List<string>();

        public void Add(string element)
        {
            this.mElements.Add(element);
            this.mElements.Sort();
        }

        public bool Remove(string element)
        {
            return this.mElements.Remove(element);
        }

        public uint GetMultiplicity(string element)
        {
            uint count = 0;
            foreach (string s in this.mElements)
            {
                if (s.Equals(element))
                {
                    count++;
                }
            }
            return count;
        }

        public List<string> ToList()
        {
            return this.mElements;
        }

        public MultiSet Union(MultiSet other)
        {
            MultiSet newMultiSet = new MultiSet();

            HashSet<string> hashSet = new HashSet<string>(this.ToList().Concat(other.ToList()).ToList());
            foreach (string s in hashSet)
            {
                uint max = Math.Max(this.GetMultiplicity(s), other.GetMultiplicity(s));
                for (uint i = 0; i < max; i++)
                {
                    newMultiSet.Add(s);
                }
            }

            return newMultiSet;
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet newMultiSet = new MultiSet();

            HashSet<string> hashSet = new HashSet<string>(this.ToList().Concat(other.ToList()).ToList());
            foreach (string s in hashSet)
            {
                uint max = Math.Min(this.GetMultiplicity(s), other.GetMultiplicity(s));
                for (uint i = 0; i < max; i++)
                {
                    newMultiSet.Add(s);
                }
            }

            return newMultiSet;
        }

        public MultiSet Subtract(MultiSet other)
        {
            MultiSet newMultiSet = new MultiSet();

            HashSet<string> hashSet = new HashSet<string>(this.ToList().Concat(other.ToList()).ToList());
            foreach (string s in hashSet)
            {
                uint max = Math.Max(this.GetMultiplicity(s) - other.GetMultiplicity(s), 0);
                for (uint i = 0; i < max; i++)
                {
                    newMultiSet.Add(s);
                }
            }

            return newMultiSet;
        }

        private void findPowerSetRecursive(List<MultiSet> target, MultiSet toCopy, List<string> remainElements)
        {

            if (remainElements.Count == 0)
            {
                target.Add(toCopy);
            }
            else
            {
                string ele = remainElements[0];
                uint multiplicity = this.GetMultiplicity(ele);

                for (uint i = 0; i < multiplicity + 1; i++)
                {
                    MultiSet multiSet = new MultiSet();
                    foreach (string s in toCopy.ToList())
                    {
                        multiSet.Add(s);
                    }

                    for (int j = 0; j < i; j++)
                    {
                        multiSet.Add(ele);
                    }
                    this.findPowerSetRecursive(target, multiSet, remainElements.Skip(1).ToList());
                }
            }
        }

        private int compare(MultiSet a, MultiSet b)
        {
            List<string> aElements = a.mElements;
            List<string> bElements = b.mElements;

            int idx = Math.Min(aElements.Count, bElements.Count);

            for (int i = 0; i < idx; i++)
            {
                if (aElements[i].Equals(bElements[i]))
                {
                    continue;
                }
                else
                {
                    return String.Compare(aElements[i], bElements[i]);
                }
            }

            return aElements.Count - bElements.Count;

        }


        public List<MultiSet> FindPowerSet()
        {
            List<MultiSet> powerSet = new List<MultiSet>();
            HashSet<string> remainElements = new HashSet<string>(this.ToList());
            this.findPowerSetRecursive(powerSet, new MultiSet(), remainElements.ToList());
            powerSet.Sort(this.compare);
            return powerSet;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            HashSet<string> hashSet = new HashSet<string>(this.ToList());

            bool bIsSubset = true;
            foreach (string s in hashSet)
            {
                if (other.GetMultiplicity(s) < this.GetMultiplicity(s))
                {
                    bIsSubset = false;
                    break;
                }
            }

            return bIsSubset;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            HashSet<string> hashSet = new HashSet<string>(this.ToList());

            bool bIsSuperSet = true;
            foreach (string s in hashSet)
            {
                if (other.GetMultiplicity(s) > this.GetMultiplicity(s))
                {
                    bIsSuperSet = false;
                    break;
                }
            }

            return bIsSuperSet;
        }
    }
}