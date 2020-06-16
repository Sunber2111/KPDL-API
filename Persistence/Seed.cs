using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {

            var listSub = await context.Subjects.ToListAsync();

            var listStu = await context.Students.ToListAsync();

            foreach(var su in listSub)
            {
                var skip = GetRandom(0,20);

                var ds = listStu.Skip(skip);

                foreach(var s in ds)
                {
                    var od = new Order
                    {
                        StudentId = s.Id,
                        SubjectId = su.Id,
                        OrderDate=DateTime.Now
                    };
                    await context.Orders.AddAsync(od);
                }
            }

            await context.SaveChangesAsync();

        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return Math.Round((random.NextDouble() * (maximum - minimum) + minimum), 2, MidpointRounding.AwayFromZero);
        }

        public static int GetRandom(int minimum, int maximum)
        {
            Random random = new Random();
            return random.Next(minimum, maximum);
        }
    }
}

