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
            // Id Subject: 9D9FE1A5-60D6-46D1-917A-529AB927909D	
        }
    }
}