using System.Configuration;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Wisteria.Domain.Entities;
using Wisteria.Service.Depend_Injections;
using Wisteria.Service.Depend_Injections.Add;
using Wisteria.Service.Depend_Injections.Modify;
using Wisteria.Service.Depend_Injections.Register;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUser,AddUser>();
builder.Services.AddScoped<ModifyUser, Modify>();
builder.Services.AddScoped<RegisterChecker, R_Checker>();
builder.Services.AddScoped<ICommunity, AddCommunity>();
builder.Services.AddScoped<IGet, Get>();
builder.Services.AddDbContext<UserBase>(options =>
{
options.UseSqlServer("Data Source=DESKTOP-OR6CO4J\\SQLEXPRESS;Initial Catalog=Wisteria;Integrated Security=True;Trust Server Certificate=True");
});
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);//yezabat error beta3 recurrsion taba3 el json
builder.Services.AddRazorPages();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
