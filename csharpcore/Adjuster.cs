using System;

namespace csharpcore
{
    public class Adjuster
    {
        public bool HasExpired(Item item)
        {
            return item.SellIn < 0;
        }

        public void IncreaseQuality(Item item, int inccrementValue)
        {
            item.Quality = Math.Min(item.Quality + inccrementValue, 50);
        }

        public void DecreaseQualityBy(Item item, int decrementValue)
        {
            item.Quality = Math.Max(item.Quality - decrementValue, 0);
        }

        public void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}