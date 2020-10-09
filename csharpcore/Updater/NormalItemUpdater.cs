namespace csharpcore
{
    public class NormalItemUpdater : Updater
    {
        private Adjuster adjuster;
        public NormalItemUpdater(Adjuster adjuster)
        {
            this.adjuster = adjuster;
        }
        public void Update(Item item)
        {
            this.adjuster.DecreaseSellIn(item);
            if (this.adjuster.HasExpired(item))
            {
                this.adjuster.DecreaseQualityBy(item, 2);
            }
            else
            {
                this.adjuster.DecreaseQualityBy(item, 1);
            }
        }
    }
}