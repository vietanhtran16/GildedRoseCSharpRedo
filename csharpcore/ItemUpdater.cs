using System;

namespace csharpcore
{
    public class ItemUpdater
    {
        public void UpdateAgedBried(Item item)
        {
            DecreaseSellIn(item);
            if (HasExpired(item))
            {
                IncreaseQuality(item, 2);
            }
            else
            {
                IncreaseQuality(item, 1);
            }
        }

        public void UpdateBackstagePass(Item item)
        {
            UpdateQualityForBackstagePass(item);
            DecreaseSellIn(item);

            if (HasExpired(item))
            {
                item.Quality = 0;
            }
        }
        private void UpdateQualityForBackstagePass(Item item)
        {
            IncreaseQuality(item, 1);
            if (item.SellIn < 11)
            {
                IncreaseQuality(item, 1);
            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item, 1);
            }
        }

        public void UpdateNormalItems(Item item)
        {
            DecreaseSellIn(item);
            if (HasExpired(item))
            {
                DecreaseQualityBy(item, 2);
            }
            else
            {
                DecreaseQualityBy(item, 1);
            }
        }

        private bool HasExpired(Item item)
        {
            return item.SellIn < 0;
        }

        private void IncreaseQuality(Item item, int inccrementValue)
        {
            item.Quality = Math.Min(item.Quality + inccrementValue, 50);
        }

        private void DecreaseQualityBy(Item item, int decrementValue)
        {
            item.Quality = Math.Max(item.Quality - decrementValue, 0);
        }

        private void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}