using ORM_3.DataAcces;
using ORM_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ORM_3.Abstraction
{
    public class OrderProductRepository
    {
        private readonly ShopDbContext _context;

        public OrderProductRepository(ShopDbContext context)
        {
            _context = context;
        }

        public OrderProduct Add(OrderProduct obj)
        {
            _context.OrderProducts.Add(obj);
            SaveChanges();
            return obj;
        }

        public OrderProduct? Get(Expression<Func<OrderProduct, bool>> exp)
        {
            return _context.OrderProducts.FirstOrDefault(exp);
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            return _context.OrderProducts.ToList();
        }

        public IEnumerable<OrderProduct> GetByFilter(Expression<Func<OrderProduct, bool>> exp)
        {
            return _context.OrderProducts.Where(exp).ToList();
        }

        public OrderProduct Update(OrderProduct obj)
        {
            _context.OrderProducts.Update(obj);
            SaveChanges();
            return obj;
        }

        public bool Delete(OrderProduct obj)
        {
            _context.OrderProducts.Remove(obj);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}