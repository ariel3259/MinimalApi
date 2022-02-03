using MinimalApi.Controllers;

namespace MinimalApi.Routes
{
    public class UserRoutes
    {

        private UserController userController;

        public UserRoutes()
        {

            this.userController = new();
        
        }

        public void Routes(WebApplication app)
        {
            
            app.MapPost("/api/users/register", userController.Register);

            app.MapPost("/api/users/auth", userController.Auth);

        }
    }
}
