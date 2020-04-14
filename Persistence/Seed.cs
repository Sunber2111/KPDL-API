using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            await context.SaveChangesAsync();
            // Id student: 7BAC7374-48CA-4B61-9911-E315CF4E438F
            // Id Subject: 8D2A4BDC-6B58-4EE9-97F1-39A39DF5BC17
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return Math.Round((random.NextDouble() * (maximum - minimum) + minimum), 2, MidpointRounding.AwayFromZero);
        }
    }
}