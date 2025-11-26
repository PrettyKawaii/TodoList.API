var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Greetings! Soon enough I'll rule the world!");
app.MapGet("/map_get", () => "A bit of testing how .MapGet() works.");

app.Run();