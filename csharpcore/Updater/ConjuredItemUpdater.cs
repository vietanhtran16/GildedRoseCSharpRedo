namespace csharpcore
{
    public class ConjuredItemUpdater : Updater
    {
        private Adjuster adjuster;
        public ConjuredItemUpdater(Adjuster adjuster)
        {
            this.adjuster = adjuster;
        }
        public void Update(Item item)
        {
            this.adjuster.DecreaseSellIn(item);
            if (this.adjuster.HasExpired(item))
            {
                this.adjuster.DecreaseQualityBy(item, 4);
            }
            else
            {
                this.adjuster.DecreaseQualityBy(item, 2);
            }
        }
    }
}