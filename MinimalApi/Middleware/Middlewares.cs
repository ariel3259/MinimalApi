using MinimalApi.Utils;

namespace MinimalApi.Middleware
{
    public class Middlewares
    {

        private Token jwt;

        public Middlewares()
        {

            this.jwt = new();
        
        }

        public void Start(WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/api/users/register" || context.Request.Path == "/api/users/auth" || context.Request.Path == "/")
                {

                   await next.Invoke();

                   return;

                }

                 

                if (context.Request.Headers.Authorization == "")
                {
                    context.Response.StatusCode = 400;

                    await context.Response.WriteAsJsonAsync(new {message = "There's not token, no access" });

                    return;

                }

                string token = context.Request.Headers.Authorization; 

                if (jwt.VerifyToken(token) == false)
                {
                    context.Response.StatusCode = 400;

                    await context.Response.WriteAsJsonAsync(new { message = "Invalid token, no acces" });

                    return;
                }

                await next.Invoke();

            });
        }
    }
}
