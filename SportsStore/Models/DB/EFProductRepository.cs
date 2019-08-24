using SportsStore.Models.Interface;
using System.Linq;

namespace SportsStore.Models.DB
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;

        public Product DeleteProduct(int ID)
        {
            Product product = context.Products
                                     .FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }        

        public void SaveProduct(Product product)
        {
            if (product.ID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products
                                         .FirstOrDefault(p => p.ID == product.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
    }
}
