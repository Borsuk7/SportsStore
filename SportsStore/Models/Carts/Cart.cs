using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models.Carts
{
    public class Cart
    {
        private readonly List<CartLine> LineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine tempLine = LineCollection.Where(p => p.Product.ID == product.ID)
                                              .FirstOrDefault();
            if (tempLine == null)
            {
                LineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                tempLine.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Product product)
        {
            CartLine tempLine = LineCollection.Where(p => p.Product.ID == product.ID)
                                              .FirstOrDefault();

            if (tempLine.Quantity == 1)
            {
                LineCollection.RemoveAll(l => l.Product.ID == product.ID);
            }
            else
            {
                tempLine.Quantity--;
            }

        }

        public virtual decimal ComputeTotalValue() => LineCollection.Sum(l => l.Product.Price * l.Quantity);

        public virtual void Clear() => LineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => LineCollection;
    }

    public class CartLine
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
