using BulkyBook.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BulkyBook.DataAccess
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuider)
        {
            using (var serviceScope = applicationBuider.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();
                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name="Horror",
                            DisplayOrder=0,
                            CreatedDateTime=DateTime.Now,

                        },
                        new Category()
                        {
                            Name="Fiction",
                            DisplayOrder=0,
                            CreatedDateTime=DateTime.Now,
                        }

                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
