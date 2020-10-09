namespace csharpcore
{
    public class AgedBriedUpdater : Updater
    {
        private Adjuster adjuster;
        public AgedBriedUpdater(Adjuster adjuster)
        {
            this.adjuster = adjuster;
        }
        public void Update(Item item)
        {
            this.adjuster.DecreaseSellIn(item);
            if (this.adjuster.HasExpired(item))
            {
                this.adjuster.IncreaseQuality(item, 2);
            }
            else
            {
                this.adjuster.IncreaseQuality(item, 1);
            }
        }
    }
}