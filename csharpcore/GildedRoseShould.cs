using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseShould
    {
        public static IEnumerable<object[]> NormalItemData =>
        new List<object[]>
        {
            new object[] { ItemName.DexterityVest },
            new object[] { ItemName.Elixir },
        };

        [Fact]
        public void IncreaseAgedBrieByOneWhenSellInIsPositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ItemName.AgedBried, SellIn = 1, Quality = 5 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(ItemName.AgedBried, item.Name);
            Assert.Equal(0, item.SellIn);
            Assert.Equal(6, item.Quality);
        }

        [Fact]
        public void IncreaseAgedBrieByTwoWhenSellInIsNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ItemName.AgedBried, SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(ItemName.AgedBried, item.Name);
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(2, item.Quality);
        }

        [Fact]
        public void NotIncreaseAgedBrieQualityOverFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ItemName.AgedBried, SellIn = -1, Quality = 49 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(ItemName.AgedBried, item.Name);
            Assert.Equal(-2, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void NeverAlterSulufrasLegendaryItem()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ItemName.Sulfuras, SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(ItemName.Sulfuras, item.Name);
            Assert.Equal(0, item.SellIn);
            Assert.Equal(80, item.Quality);
        }

        [Theory]
        [MemberData(nameof(NormalItemData))]
        public void DecreaseNormalItemQualityByOneWhenSellInIsPositive(string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = 40 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(itemName, item.Name);
            Assert.Equal(9, item.SellIn);
            Assert.Equal(39, item.Quality);
        }

        [Theory]
        [MemberData(nameof(NormalItemData))]
        public void DecreaseNormalItemQualityByTwoWhenSellInIsPositive(string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = 40 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(itemName, item.Name);
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(38, item.Quality);
        }

        [Theory]
        [MemberData(nameof(NormalItemData))]
        public void NotDecreseNormalItemQualityBelowZero(string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(itemName, item.Name);
            Assert.Equal(0, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void IncreaseBackstagePassQualityByOneWhenSellInMoreThanTen()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ItemName.BackstagePass, SellIn = 11, Quality = 20 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(ItemName.BackstagePass, item.Name);
            Assert.Equal(10, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void IncreaseBackstagePassQualityByTwoWhenSellInLessThanEleven()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ItemName.BackstagePass, SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(ItemName.BackstagePass, item.Name);
            Assert.Equal(9, item.SellIn);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void IncreaseBackstagePassQualityByThreeWhenSellInLessThanSix()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ItemName.BackstagePass, SellIn = 5, Quality = 20 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(ItemName.BackstagePass, item.Name);
            Assert.Equal(4, item.SellIn);
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void DropBackstagePassQualityToZeroAfterConcert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ItemName.BackstagePass, SellIn = 0, Quality = 20 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item = Items[0];
            Assert.Equal(ItemName.BackstagePass, item.Name);
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }
    }
}