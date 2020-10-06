using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = ItemName.DexterityVest, SellIn = 10, Quality = 20},
                new Item {Name = ItemName.AgedBried, SellIn = 2, Quality = 0},
                new Item {Name = ItemName.Elixir, SellIn = 5, Quality = 7},
                new Item {Name = ItemName.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = ItemName.Sulfuras, SellIn = -1, Quality = 80},
                new Item
                {
                    Name = ItemName.BackstagePass,
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = ItemName.BackstagePass,
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = ItemName.BackstagePass,
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
