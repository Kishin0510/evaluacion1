using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evaluacion1.Src.Models;

namespace evaluacion1.Src.Data
{
    public class Seeder
    {
        public static async Task Seed(DataContext context)
        {
            if (context.Users.Any()) return;

            var gender = new string[] { "masculino", "femenino", "otro", "prefiero no decirlo" };
            var random = new Random();

            
            for (int i = 0; i < 20; i++)
            {
                var part1 = random.Next(10, 100); 
                var part2 = random.Next(100, 1000); 
                var part3 = random.Next(100, 1000); 
                var part4 = random.Next(0, 10);
                var user = new User 
                {
                    RUT = $"{part1:00}.{part2:000}.{part3:000}-{part4}",
                    Name = "User " + i.ToString(),
                    Email = "user" + i.ToString() + "@example.com",
                    Gender = gender[random.Next(0, gender.Length)],
                    Birthdate = new DateTime(random.Next(1990, 2010), random.Next(1, 13), random.Next(1, 29))
                };

                await context.Users.AddAsync(user);
            }

            await context.SaveChangesAsync();
            
        }
    }
}