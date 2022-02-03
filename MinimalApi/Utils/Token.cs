using JWT.Algorithms;
using JWT.Builder;
using System.Text;

namespace MinimalApi.Utils
{
    public class Token
    {
        private string secret;

        public Token()
        {
            this.secret = WebApplication.CreateBuilder().Build().Configuration.GetValue<string>("SecretKey");
        }

        public string GenToken()
        {

            string token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                      .WithSecret(this.secret)
                      .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                      .Encode();

            return token;

        }

        public bool VerifyToken(string token)
        {
            try
            {

                 object json = JwtBuilder.Create()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(this.secret)
                    .MustVerifySignature()
                    .Decode(token);

                return true;

            }

            catch (Exception)
            {

                return false;

            }

        }
    }
}
