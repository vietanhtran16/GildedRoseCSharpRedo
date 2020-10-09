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
                this.itemUpdater.UpdateItem(Items[i]);
            }
        }
    }
}
