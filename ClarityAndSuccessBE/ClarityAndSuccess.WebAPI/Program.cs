using ClarityAndSuccess.Application.Interface;
using ClarityAndSuccess.Application.Service;
using ClarityAndSuccess.Domain.Data;
using ClarityAndSuccess.Infrastructure.Interface;
using ClarityAndSuccess.Infrastructure.Mapping;
using ClarityAndSuccess.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ClarityAndSuccessDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("JeweltabYunoDB")));
builder.Services.AddControllers();

// for returning validation error in ApiResponse Formate
// builder.Services.Configure<ApiBehaviorOptions>(options =>
// {
//     var isDev = builder.Environment.IsDevelopment();

//     options.InvalidModelStateResponseFactory = context =>
//         ValidationConvertor.CreateValidationErrorResponse(context, isDev);
// });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(IAutoMapper).Assembly);
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
