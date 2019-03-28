using crawler_shopping.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping.src.Repository
{
    internal interface ICategoryRepository
    {
        Category GetByUid(string uid);
        Category GetByName(string name);
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(string uid);
        bool AddCategories(List<Category> categories);
        IEnumerable<Category> GetAll();
    }
}
