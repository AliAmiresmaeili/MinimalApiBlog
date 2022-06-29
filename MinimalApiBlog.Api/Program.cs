using MinimalApiBlog.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices(builder);

var app = builder.Build();
app.ConfigureApplication();
app.RegisterEndpoints();
app.Run();
