using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class ItemUpdater
    {
        private Updater defaultUpdater = new NormalItemUpdater(new Adjuster());
        private Dictionary<string, Updater> updaterRegistry = new Dictionary<string, Updater>();
        public ItemUpdater()
        {
            this.updaterRegistry.Add(ItemName.AgedBried, new AgedBriedUpdater(new Adjuster()));
            this.updaterRegistry.Add(ItemName.BackstagePass, new BackstagePassUpdater(new Adjuster()));
            this.updaterRegistry.Add(ItemName.Sulfuras, new SulfurasUpdater(new Adjuster()));
        }

        public void UpdateItem(Item item)
        {
            if (this.updaterRegistry.ContainsKey(item.Name))
            {
                this.updaterRegistry[item.Name].Update(item);
            }
            else
            {
                this.defaultUpdater.Update(item);
            }
        }
    }
}