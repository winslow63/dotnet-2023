using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server;
using server.Repository;
using shopOnline;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<ShopProgramDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("shopProgram")!);
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

var mapperConrig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConrig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<IShopOnlintRepository, ShopOnlintRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
