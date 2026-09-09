using ORM_3.DataAcces;
using ORM_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ORM_3.Abstraction
{
    public class CategoryRepository
    {
        private readonly ShopDbContext _context;

        public CategoryRepository(ShopDbContext context)
        {
            _context = context;
        }

        public Category Add(Category obj)
        {
            _context.Categories.Add(obj);
            SaveChanges();
            return obj;
        }

        public Category? Get(Expression<Func<Category, bool>> exp)
        {
            return _context.Categories.FirstOrDefault(exp);
        }

        public Category? Get(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Category> GetByFilter(Expression<Func<Category, bool>> exp)
        {
            return _context.Categories.Where(exp).ToList();
        }

        public Category Update(Category obj)
        {
            _context.Categories.Update(obj);
            SaveChanges();
            return obj;
        }

        public bool Delete(Category obj)
        {
            _context.Categories.Remove(obj);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}