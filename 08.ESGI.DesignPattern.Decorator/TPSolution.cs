using System;

namespace _08.ESGI.DesignPattern.Decorator
{
    public interface Item
    {
        string Name { get; }
        decimal Price { get; }
    }

    public class Book : Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Book(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Coffee : Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Coffee(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public abstract class ItemDecorator : Item 
    {
        protected readonly Item item;

        public ItemDecorator(Item item)
        {
            this.item = item;
        }
        public virtual string Name => item.Name;

        public virtual decimal Price => item.Price;
    }

    public class SpecialOffer : ItemDecorator
    {
        private readonly int discountPercentage;

        public SpecialOffer(Item item, int discountPercentage) : base(item)
        {
            this.discountPercentage = discountPercentage;
        }

        public override decimal Price 
        { 
            get 
            {
                return Math.Round(base.Price - (base.Price * discountPercentage / 100M), 2);
            } 
        }
    }

    public class SoldOut : ItemDecorator
    {
        public SoldOut(Item item) : base(item)
        {
        }

        public override decimal Price
        {
            get
            {
                throw new Exception("Sold out sorry");
            }
        }
    }
}
