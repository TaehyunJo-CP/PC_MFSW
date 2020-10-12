using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Recyclebot
    {
        public List<Item> RecycleItems { get; } = new List<Item>();
        public List<Item> NonRecycleItems { get; } = new List<Item>();


        public void Add(Item item)
        {
            // 재활용 기준
            // 만약 아이템이 종이(paper), 가구(furniture) 또는 전기제품(electronics)이라면, 그 아이템의 무게는 5kg 미만이고 2kg 이상이다.
            // (paper or funiture or electronics) -> (weight < 5 && weight >= 2)
            if ((item.Type == EType.Paper || item.Type == EType.Furniture || item.Type == EType.Electronics) && !(item.Weight < 5 && item.Weight >= 2))
            {
                NonRecycleItems.Add(item);
            }
            else
            {
                RecycleItems.Add(item);
            }
        }

        public List<Item> Dump()
        {
            // 강에 버리는 기준
            // 아이템의 부피가 10L, 11L 또는 15L가 아니다.
            // 이는 그 아이템이 유독 폐기물임을 함의한다.
            // 이는 다시 그 아이템이 가구나 전기제품임을 함의한다.

            List<Item> toReturn = new List<Item>();
            foreach (Item item in this.NonRecycleItems)
            {

                bool bool1 = (item.Volume != 10.0 || item.Volume != 11.0 || item.Volume != 15.0);
                bool bool2 = (item.IsToxicWaste);
                bool bool3 = (item.Type == EType.Furniture || item.Type == EType.Electronics);

                if (!bool1 && bool2 && !bool3)
                {
                }
                else if (bool1 && bool2 && !bool3)
                {
                }
                else
                {
                    toReturn.Add(item);
                }
            }
            return toReturn;

        }
    }
}
