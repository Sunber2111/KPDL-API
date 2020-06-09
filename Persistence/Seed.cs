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

            var sub = context.Subjects.Where(x=>x.Id>=7).ToList();

            foreach (var i in sub)
            {
                var num_ran_stu = GetRandom(1, 6);

                for (int j = 0; j < num_ran_stu; j++)
                {
                    var ran_stu = GetRandom(1, 20);
                    var order = new Order
                    {
                        StudentId = ran_stu + 1,
                        SubjectId = i.Id,
                        OrderDate = DateTime.Now
                    };
                    context.Orders.Add(order);
                    await context.SaveChangesAsync();

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