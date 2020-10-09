using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        private ItemUpdater itemUpdater;
        public GildedRose(IList<Item> Items, ItemUpdater itemUpdater)
        {
            this.Items = Items;
            this.itemUpdater = itemUpdater;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var currentItem = Items[i];
                switch (currentItem.Name)
                {
                    case ItemName.Sulfuras:
                        break;
                    case ItemName.AgedBried:
                        this.itemUpdater.UpdateAgedBried(currentItem);
                        break;
                    case ItemName.BackstagePass:
                        this.itemUpdater.UpdateBackstagePass(currentItem);
                        break;
                    default:
                        this.itemUpdater.UpdateNormalItems(currentItem);
                        break;
                }
            }
        }
    }
}
