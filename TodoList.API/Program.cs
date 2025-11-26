var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Greetings! Soon enought I'll rule the world!");

app.Run();