using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Controllers
{
    public class BeerController
    {
        private CSharpDBContext context = new();

        public async Task<List<Beer>> GetAllBeers()
        {

            List<Beer> beers = await context.Beers.ToListAsync();

            return beers;

        }

        public async Task<object> SaveBeer(Beer beer)
        {

            await context.Beers.AddAsync(beer);

            await context.SaveChangesAsync();

            return new { mensaje = "Saved a beer" };

        }

        public async Task<object> ModifyBeer(Beer beer)
        {

            context.Beers.Update(beer);

            await context.SaveChangesAsync();

            return new {message = "Modified a beer"};
        
        }

        public async Task<object> DeleteBeer(int id)
        {

            Beer beer = await context.Beers.FindAsync(id);

            if (beer == null)
            {
                return new { message = "The beer doesn't exists" };
            }
            
            context.Beers.Remove(beer);

             await context.SaveChangesAsync();

            return new {message = "Deleted a beer"} ;
        }
    }

}
