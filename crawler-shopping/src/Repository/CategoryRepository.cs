﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crawler_shopping.src.DbConnection;
using crawler_shopping.src.Entities;
using Dapper;

namespace crawler_shopping.src.Repository
{
    internal class CategoryRepository : ICategoryRepository
    {
        private IConnectionFactory _connectionFactory;
        public CategoryRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public bool Add(Category category)
        {
            string querySql = "insert into category values (@Uid, @Name)";

            try
            {
                _connectionFactory.GetConnection.Execute(querySql, category);
                _connectionFactory.GetConnection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error => {exception}");
                _connectionFactory.GetConnection.Close();
                return false;
            }

            return true;
        }

        public bool AddCategories(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string uid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetByName(string name)
        {
            string query = "SELECT * FROM category WHERE category_name = @NameCategory";

            try
            {
                Category category = _connectionFactory.GetConnection.QuerySingle<Category>(query, new { NameCategory = name});
                _connectionFactory.GetConnection.Close();
                return category;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error => {exception}");
                _connectionFactory.GetConnection.Close();
                return null;
            }

            
        }

        public Category GetByUid(string uid)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
