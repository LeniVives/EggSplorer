using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EggSplorer.Data;
using System;
using System.Linq;

namespace EggSplorer.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EggsplorerContext())
            {
                // Look for any movies.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                context.Products.AddRange(
                    new Products { Name = "Kleine eitjes melkchocolade", Description = "Een zakje van 250g met kleine paaseitjes van melkchocolade", ProductPrice = 5.99m },
                    new Products { Name = "Kleine eitjes pure chocolade", Description = "Een zakje van 250g met kleine paaseitjes van pure chocolade", ProductPrice = 5.99m },
                    new Products { Name = "Kleine eitjes witte chocolade", Description = "Een zakje van 250g met kleine paaseitjes van witte chocolade", ProductPrice = 5.99m },
                    new Products { Name = "Kleine eitjes mengeling", Description = "Een zakje van 250g mengeling van kleine paaseitjes van witte, pure en melkchocolade", ProductPrice = 6.49m },
                    new Products { Name = "Groot ei melkchocolade", Description = "3 grote paaseieren van melkchocolade", ProductPrice = 3.99m },
                    new Products { Name = "Groot ei pure chocolade", Description = "3 grote paaseieren van pure chocolade", ProductPrice = 3.99m },
                    new Products { Name = "Groot ei witte chocolade", Description = "3 grote paaseieren van witte chocolade", ProductPrice = 3.99m },
                    new Products { Name = "Groot ei mengeling", Description = "3 grote paaseieren mengeling van witte, pure en melkchocolade", ProductPrice = 4.49m },
                    new Products { Name = "Paashaas", Description = "1 grote paashaas van witte en melkchocolade", ProductPrice = 2.99m },
                    new Products { Name = "Kinder Surprise", Description = "Doosje met 3 Kinder Surprise eieren", ProductPrice = 2.49m },
                    new Products { Name = "Eggsplorer Special", Description = "Onze special. 1 groot gedecoreerd ei met een leuk paastafereel. Ideaal als geschenk!", ProductPrice = 9.99m }
                );
                context.SaveChanges();
            }
        }
    }
}

