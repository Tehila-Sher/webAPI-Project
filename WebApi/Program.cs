using BLL;
using DAL;
using DAL.Models;
using DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddAutoMapper(typeof(UserAuto));

builder.Services.AddScoped<IProductBLL, ProductBLL>();
builder.Services.AddScoped<IProductDAL, ProductDAL>();
builder.Services.AddAutoMapper(typeof(ProductAuto));

builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddAutoMapper(typeof(CategoryAuto));

builder.Services.AddScoped<IOrderBLL, OrderBLL>();
builder.Services.AddScoped<IOrderDAL, OrderDAL>();
builder.Services.AddAutoMapper(typeof(OrderAuto));

builder.Services.AddDbContext<ShopContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
