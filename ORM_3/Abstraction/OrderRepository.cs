using ORM_3.DataAcces;
using ORM_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ORM_3.Abstraction
{
    public class OrderRepository
    {
        private readonly ShopDbContext _context;

        public OrderRepository(ShopDbContext context)
        {
            _context = context;
        }

        public Order Add(Order obj)
        {
            _context.Orders.Add(obj);
            SaveChanges();
            return obj;
        }

        public Order? Get(Expression<Func<Order, bool>> exp)
        {
            return _context.Orders.FirstOrDefault(exp);
        }

        public Order? Get(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetByFilter(Expression<Func<Order, bool>> exp)
        {
            return _context.Orders.Where(exp).ToList();
        }

        public Order Update(Order obj)
        {
            _context.Orders.Update(obj);
            SaveChanges();
            return obj;
        }

        public bool Delete(Order obj)
        {
            _context.Orders.Remove(obj);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}