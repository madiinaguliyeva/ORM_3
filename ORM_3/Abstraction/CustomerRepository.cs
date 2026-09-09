using ORM_3.DataAcces;
using ORM_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ORM_3.Abstraction
{
    public class CustomerRepository
    {
        private readonly ShopDbContext _context;

        public CustomerRepository(ShopDbContext context)
        {
            _context = context;
        }

        public Customer Add(Customer obj)
        {
            _context.Customers.Add(obj);
            SaveChanges();
            return obj;
        }

        public Customer? Get(Expression<Func<Customer, bool>> exp)
        {
            return _context.Customers.FirstOrDefault(exp);
        }

        public Customer? Get(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public IEnumerable<Customer> GetByFilter(Expression<Func<Customer, bool>> exp)
        {
            return _context.Customers.Where(exp).ToList();
        }

        public Customer Update(Customer obj)
        {
            _context.Customers.Update(obj);
            SaveChanges();
            return obj;
        }

        public bool Delete(Customer obj)
        {
            _context.Customers.Remove(obj);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}