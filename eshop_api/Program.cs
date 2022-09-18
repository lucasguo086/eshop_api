using System.Text;
using eshop_api;
using Microsoft.AspNetCore.Authentication;
using eshop_api.Handler;
using eshop_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//authentication 给不同的claim
builder.Services
    .AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, EshopHandler>("EshopAuthentication", null);
//.AddScheme<AuthenticationSchemeOptions, AdminHandler>("AdminAuthentication", null);
builder.Services.AddDbContext<EshopDbContext>(
    options => options.UseSqlServer($"Server=tcp:lucasguo811.database.windows.net,1433;Initial Catalog=eshop;Persist Security Info=False;User ID={Encoding.UTF8.GetString(Convert.FromBase64String(Key.User))};Password={Encoding.UTF8.GetString(Convert.FromBase64String(Key.Psw))};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
);
builder.Services.AddControllers();
builder.Services.AddScoped<IEshopRepo, EshopRepo>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("admin"));
    // options.AddPolicy("UserOnly", policy => policy.RequireClaim("user"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();