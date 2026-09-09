using Microsoft.EntityFrameworkCore;
using ORM_3.DataAcces;
using ORM_3.Entities;

namespace ORM_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ShopDbContext();

            Category category = new Category()
            {
                Name = "Electronics"
            };

            context.Categories.Add(category);
            context.SaveChanges();

            Product product = new Product()
            {
                Name = "Laptop",
                Price = 1500,
                CategoryId = category.Id
            };

            context.Products.Add(product);
            context.SaveChanges();

            var products = context.Products.Include(p => p.Category);
            foreach (var p in products)
            {
                Console.WriteLine($"Product: {p.Name} | Price: {p.Price} | Category: {p.Category?.Name}");
            }
        }
    }
}

    

