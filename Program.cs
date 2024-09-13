using Midleware;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<GroupExceptionMiddleware>();
builder.Services.AddControllers();
builder.Services.AddTransient<GroupService>();
builder.Services.AddSingleton<DbContext>();

var app = builder.Build();
app.UseMiddleware<GroupExceptionMiddleware>();
app.MapControllers();
app.Run();
