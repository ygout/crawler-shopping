using crawler_shopping.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping.src.Repository
{
    internal interface IProductRepository
    {
        Product GetById(int id);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(int id);
        bool AddProducts(List<Product> products);
        IEnumerable<Product> GetAll();
    }
}
