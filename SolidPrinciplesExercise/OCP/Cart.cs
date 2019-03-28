using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesExercise.OCP
{
    public class Cart
    {
        private readonly List<OrderItem> items;

        private readonly IPricingCalculator pricingCalculator;

        public Cart()
        {
            items = new List<OrderItem>();
            pricingCalculator = new PricingCalculator();
        }

        public Cart(IPricingCalculator pricingCalculator)
        {
            items = new List<OrderItem>();
            this.pricingCalculator = pricingCalculator;
        }

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }

        public IEnumerable<OrderItem> GetItems()
        {
            return items;
        }

        public decimal GetCartTotal()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += pricingCalculator.CalculatePrice(item);
            }
            return total;
        }
    }
}
