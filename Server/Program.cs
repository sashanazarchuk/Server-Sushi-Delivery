using BusinessLogic.Interfaces;
using BusinessLogic.Service;
using Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add ConntectionString
string connectionStr = builder.Configuration.GetConnectionString("AzureDB"); //AzureDB
builder.Services.AddDbContext<DeliveryDbContext>(options => options.UseSqlServer(connectionStr));

//add Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<DeliveryDbContext>()
    .AddDefaultTokenProviders();

//add FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

//add custom service
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IAccountService, AccountService>();

//add CORS
builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://jolly-meadow-0a7b36510.2.azurestaticapps.net").AllowAnyMethod().AllowAnyHeader();
    }
    ));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("NgOrigins");
app.UseAuthorization();
app.MapControllers();

app.Run();
