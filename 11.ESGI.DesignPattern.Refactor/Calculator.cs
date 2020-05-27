using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.ESGI.DesignPattern.Refactor
{
    public abstract class UpdateStrategy
    {
        public abstract void Update(Item item);

        public void DecQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality -= 1;
        }

        public void IncQuality(Item item)
        {
            if (item.Quality  < 50)
                item.Quality += 1;
        }
    }

    public class LegendaryUpdateStrategy : UpdateStrategy
    {
        public override void Update(Item item)
        { }
    }

    public class AgedBrieUpdateStragegy : UpdateStrategy
    {
        public override void Update(Item item)
        {
            IncQuality(item);

            item.SellIn -= 1;

            if (item.SellIn < 0)
                IncQuality(item);
        }
    }

    public class SimpleUpdateStragegy : UpdateStrategy
    {
        public override void Update(Item item)
        {
            DecQuality(item);

            item.SellIn -= 1;

            if (item.SellIn < 0)
                DecQuality(item);
        }
    }

    public class BackstagePassesUpdateStrategy : UpdateStrategy
    {
        public override void Update(Item item)
        {
            IncQuality(item);

            if (item.SellIn < 11)
                IncQuality(item);

            if (item.SellIn < 6)
                IncQuality(item);

            item.SellIn -= 1;

            if (item.SellIn < 0)
                item.Quality = 0;
        }
    }

    public class UpdateStrategyFactory
    { 
        public static UpdateStrategy Create(Item item)
        {
            if (item.Name == "Aged Brie")
                return new AgedBrieUpdateStragegy();

            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new LegendaryUpdateStrategy();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return new BackstagePassesUpdateStrategy();

            return new SimpleUpdateStragegy();
        }
    }

    public class Calculator
    {
        IList<Item> Items;

        public Calculator(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var updateStrategy = UpdateStrategyFactory.Create(item);

                updateStrategy.Update(item);
            }
        }
    }
}
