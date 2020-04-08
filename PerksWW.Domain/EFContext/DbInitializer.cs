using Microsoft.EntityFrameworkCore.Internal;
using PerksWW.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerksWW.Domain.EFContext
{
   public class DbInitializer
    {
        public static void Initalize(CarContext context)
        {
            context.Database.EnsureCreated();

#pragma warning disable EF1001 // Internal EF Core API usage.
            if (context.Cars.Any())
#pragma warning restore EF1001 // Internal EF Core API usage.
            {
                return;
            }

            var cars = new Car[]
            {
                new Car{Make="Ford", IsDeleted=false, Model="F150", Type="Truck"},
                new Car{Make="Ford", IsDeleted=false, Model="fusion", Type="Car"},
                new Car{Make="Ford", IsDeleted=false, Model="Expedition", Type="SUV"},
                new Car{Make="Ford", IsDeleted=false, Model="Explorer", Type="SUV"},
                new Car{Make="GMC", IsDeleted=false, Model="Sierra", Type="Truck"},
                new Car{Make="Chevy", IsDeleted=false, Model="Silverado", Type="Truck"},
                new Car{Make="Cevy", IsDeleted=false, Model="Tahoe", Type="SUV"}
            };
            foreach (Car c in cars)
            {
                context.Cars.Add(c);
            }
            context.SaveChanges();
        }
    }
}
