using System.Linq;

namespace SportsStore.Models.Interface
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }       
        void SaveProduct(Product product);
        Product DeleteProduct(int ID);
    }
}


