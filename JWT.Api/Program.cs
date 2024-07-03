using JWT.Api.DAL;
using JWT.Api.Jwt;
using JWT.Api.Mapping;
using JWT.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("JWT"));
builder.Services.AddIdentity<AppUser,IdentityRole<Guid>>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<JwtProvider>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
