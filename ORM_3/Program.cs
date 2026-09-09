<<<<<<< HEAD
﻿using ORM_3.Abstraction;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> 2225d341cbc1fd2c7b30acd64c2fba65a15f21d9
using ORM_3.DataAcces;
using ORM_3.Entities;

namespace ORM_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ShopDbContext();
<<<<<<< HEAD
            var categoryRepo = new CategoryRepository(context);

            Category category = new Category()
            {
                Name = "Laptops"
            };

            categoryRepo.Add(category);

            var categories = categoryRepo.GetAll();
            foreach (var item in categories)
            {
                Console.WriteLine($"Category: {item.Name}");
            }
        }
    }
}
=======

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

    

>>>>>>> 2225d341cbc1fd2c7b30acd64c2fba65a15f21d9
