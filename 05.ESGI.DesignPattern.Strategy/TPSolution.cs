using System.Collections.Generic;
using System.Linq;

namespace _05.ESGI.DesignPattern.Strategy
{
    public interface IPayement
    {
        string Pay(int amount);
    }

    public class CreditCard : IPayement
    {
        public string Pay(int amount)
        {
            return $"{amount} has been charged to my credit card";
        }
    }

    public class Paypal : IPayement
    {
        public string Pay(int amount)
        {
            return $"{amount} has been charged to my paypal account";
        }
    }

    public class ShoppingCard
    {
        private List<(string, int)> _items;

        public ShoppingCard()
        {
            _items = new List<(string, int)>();
        }

        public void AddItem(string item, int price)
        {
            _items.Add((item, price));
        }

        public string Pay(IPayement payementStrategy)
        {
            var amount = _items.Select(i => i.Item2).Sum();

            return payementStrategy.Pay(amount);
        }
    }
}
