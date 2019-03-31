using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crawler_shopping.src.Entities;
using crawler_shopping.src.DbConnection;
using Dapper;
using System.Data;

namespace crawler_shopping.src.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private IConnectionFactory _connectionFactory;
        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public bool Add(Product product)
        {
            throw new NotImplementedException();
        }

        public bool AddProducts(List<Product> products)
        {
            string querySql = "insert into product values (@Uid, @Name, @Price, @UnitInfo, @Category, @ImageUrl)";

            try
            {
                IDbTransaction transaction = _connectionFactory.GetConnection.BeginTransaction();
                _connectionFactory.GetConnection.Execute(querySql, products, transaction: transaction);
                transaction.Commit();
                Console.WriteLine("Products Added into BDD");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error BDD => {exception}");
                return false;
            }

            return true;
        }

        public bool Delete(string uid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetByUid(string uid)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
