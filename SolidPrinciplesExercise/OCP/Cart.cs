using System.Collections.Generic;

namespace SolidPrinciplesExercise.OCP
{
    public class Cart
    {
        private readonly List<OrderItem> _items;

        private readonly IPricingCalculator _pricingCalculator;

        public Cart()
        {
            _items = new List<OrderItem>();
            _pricingCalculator = new PricingCalculator();
        }

        public Cart(IPricingCalculator pricingCalculator)
        {
            _items = new List<OrderItem>();
            this._pricingCalculator = pricingCalculator;
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public IEnumerable<OrderItem> GetItems()
        {
            return _items;
        }

        public decimal GetCartTotal()
        {
            decimal total = 0;
            foreach (var item in _items)
            {
                total += _pricingCalculator.CalculatePrice(item);
            }
            return total;
        }
    }
}
