using MinimalApi.Routes;
using MinimalApi.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
Router router = new();
Middlewares middlewares = new();


app.MapGet("/", () => "Hi word!");

middlewares.Start(app);

router.Start(app);

app.Run();

