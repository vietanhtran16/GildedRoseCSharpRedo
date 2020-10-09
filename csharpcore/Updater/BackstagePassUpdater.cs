namespace csharpcore
{
    public class BackstagePassUpdater : Updater
    {
        private Adjuster adjuster;
        public BackstagePassUpdater(Adjuster adjuster)
        {
            this.adjuster = adjuster;
        }
        public void Update(Item item)
        {
            this.adjuster.DecreaseSellIn(item);
            UpdateQualityForBackstagePass(item);
            if (this.adjuster.HasExpired(item))
            {
                item.Quality = 0;
            }
        }

        private void UpdateQualityForBackstagePass(Item item)
        {
            this.adjuster.IncreaseQuality(item, 1);
            if (item.SellIn < 10)
            {
                this.adjuster.IncreaseQuality(item, 1);
            }

            if (item.SellIn < 5)
            {
                this.adjuster.IncreaseQuality(item, 1);
            }
        }
    }
}