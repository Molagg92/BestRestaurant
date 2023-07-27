// FOR DEVELOPMENT ONLY
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models
{
public static class DataInitializer
{
    public static void InitializeData(WebApplication app)
    {
        // Database initialization
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<BestRestaurantsContext>();
                context.Database.Migrate(); // Applies any pending migrations

                // Seeding data
                if (!context.Cuisines.Any()) // Checks if there are any cuisines
                {
                    context.Cuisines.AddRange(
                        new Cuisine { CuisineId = 1, Type = "Italian" },
                        new Cuisine { CuisineId = 2, Type = "Mexican" },
                        new Cuisine { CuisineId = 3, Type = "Chinese" }
                    );
                }

                if (!context.Restaurants.Any()) // Checks if there are any restaurants
                {
                    context.Restaurants.AddRange(
                        new Restaurant { RestaurantId = 1, Name = "The Italian Place", CuisineId = 1 },
                        new Restaurant { RestaurantId = 2, Name = "Mexican Fiesta", CuisineId = 2 },
                        new Restaurant { RestaurantId = 3, Name = "Chinese Delight", CuisineId = 3 }
                    );
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Logging or handling the exception
                Console.WriteLine(ex.Message);
            }
        }
    }
}
}