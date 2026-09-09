using ORM_3.Abstraction;
using ORM_3.DataAcces;
using ORM_3.Entities;

namespace ORM_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ShopDbContext();
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