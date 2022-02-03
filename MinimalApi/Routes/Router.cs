namespace MinimalApi.Routes
{
    public class Router
    {
        private BeerRoutes beerRoutes;

        private UserRoutes userRoutes;

        public Router()
        {
            this.beerRoutes = new();

            this.userRoutes = new();

        }

        public void Start(WebApplication app)
        {

            beerRoutes.Routes(app);

            userRoutes.Routes(app);

        }
    }
}
