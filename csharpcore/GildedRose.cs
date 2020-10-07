using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == ItemName.Sulfuras)
                {
                    continue;
                }

                if (IsNormalItems(i))
                {
                    UpdateNormalItems(i);
                    continue;
                }

                if (Items[i].Name == ItemName.BackstagePass)
                {
                    UpdateQualityForBackstagePass(i);
                    DecreaseSellIn(i);
                    if (HasExpired(i))
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                    continue;
                }

                if (Items[i].Name == ItemName.AgedBried)
                {
                    IncreaseQuality(i);

                    DecreaseSellIn(i);

                    if (HasExpired(i))
                    {
                        IncreaseQuality(i);
                    }
                }
            }
        }

        private void UpdateNormalItems(int i)
        {
            DecreaseQuality(i);

            DecreaseSellIn(i);

            if (HasExpired(i))
            {
                DecreaseQuality(i);
            }
        }

        private bool IsNormalItems(int i)
        {
            return Items[i].Name != ItemName.AgedBried && Items[i].Name != ItemName.BackstagePass;
        }

        private void UpdateQualityForBackstagePass(int i)
        {
            IncreaseQuality(i);
            if (Items[i].SellIn < 11)
            {
                IncreaseQuality(i);
            }

            if (Items[i].SellIn < 6)
            {
                IncreaseQuality(i);
            }
        }

        private bool HasExpired(int i)
        {
            return Items[i].SellIn < 0;
        }

        private void IncreaseQuality(int index)
        {
            Items[index].Quality = Math.Min(Items[index].Quality + 1, 50);
        }

        private void DecreaseQuality(int index)
        {
            Items[index].Quality = Math.Max(Items[index].Quality - 1, 0);
        }

        private void DecreaseSellIn(int i)
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }
    }
}
