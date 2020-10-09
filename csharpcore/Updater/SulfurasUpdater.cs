namespace csharpcore
{
    public class SulfurasUpdater : Updater
    {
        private Adjuster adjuster;
        public SulfurasUpdater(Adjuster adjuster)
        {
            this.adjuster = adjuster;
        }
        public void Update(Item item)
        {
            return;
        }
    }
}