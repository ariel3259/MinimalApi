using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;
using BCrypt.Net;
using MinimalApi.Utils;

namespace MinimalApi.Controllers
{
    public class UserController
    {
        CSharpDBContext context;

        Token jwt;

        public UserController()
        {
            this.context = new();

            this.jwt = new();
        }

        public async Task<object> Register(User user)
        {

            string passwordHashed = BCrypt.Net.BCrypt.HashPassword(user.Password, 8);

            user.Password = passwordHashed;

            await this.context.Users.AddAsync(user);

            await this.context.SaveChangesAsync();

            return new { message = "Congratulations, your new account " };

        }

        public async void Auth(User user, HttpContext ctx)
        {
            try
            {

                List<User> users = this.context.Users.Where(element => element.Email == user.Email).ToList();

                User verifyUser = users[0];

                bool result = BCrypt.Net.BCrypt.Verify(user.Password, verifyUser.Password);

                if (!result)
                {
                    ctx.Response.StatusCode = 400;

                    await ctx.Response.WriteAsJsonAsync(new { message = "Wrong password" });

                    return;
                }

                await ctx.Response.WriteAsJsonAsync(new { message = $"Welcome {verifyUser.Name} {verifyUser.LastName}", token = jwt.GenToken() });

            }

            catch (Exception)
            {

                ctx.Response.StatusCode = 400;

                await ctx.Response.WriteAsJsonAsync(new { message = "The user doesn't exists" });
                
            }

        }
    }
}
