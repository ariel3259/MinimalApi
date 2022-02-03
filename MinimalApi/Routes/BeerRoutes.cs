using MinimalApi.Controllers;

namespace MinimalApi.Routes
{
    public class BeerRoutes
    {
        private BeerController beerController;

        public BeerRoutes()
        {
            this.beerController = new();
        }

        public  void Routes(WebApplication app)
        {
             
            app.MapGet("/api/beer", beerController.GetAllBeers);
        
            app.MapPost("/api/beer", beerController.SaveBeer);

            app.MapPut("/api/beer", beerController.ModifyBeer);

            app.MapDelete("/api/beer", beerController.DeleteBeer);
        }

    }
}
