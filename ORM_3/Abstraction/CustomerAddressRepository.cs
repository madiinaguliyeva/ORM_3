using ORM_3.DataAcces;
using ORM_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ORM_3.Abstraction
{
    public class CustomerAddressRepository
    {
        private readonly ShopDbContext _context;

        public CustomerAddressRepository(ShopDbContext context)
        {
            _context = context;
        }

        public CustomerAddress Add(CustomerAddress obj)
        {
            _context.CustomerAddresses.Add(obj);
            SaveChanges();
            return obj;
        }

        public CustomerAddress? Get(Expression<Func<CustomerAddress, bool>> exp)
        {
            return _context.CustomerAddresses.FirstOrDefault(exp);
        }

        public CustomerAddress? Get(int id)
        {
            return _context.CustomerAddresses.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<CustomerAddress> GetAll()
        {
            return _context.CustomerAddresses.ToList();
        }

        public IEnumerable<CustomerAddress> GetByFilter(Expression<Func<CustomerAddress, bool>> exp)
        {
            return _context.CustomerAddresses.Where(exp).ToList();
        }

        public CustomerAddress Update(CustomerAddress obj)
        {
            _context.CustomerAddresses.Update(obj);
            SaveChanges();
            return obj;
        }

        public bool Delete(CustomerAddress obj)
        {
            _context.CustomerAddresses.Remove(obj);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}