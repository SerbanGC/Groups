using Midleware;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<GroupExceptionMiddleware>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<GroupService>();
builder.Services.AddSingleton<DbContext>();

var app = builder.Build();
app.UseMiddleware<GroupExceptionMiddleware>();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
