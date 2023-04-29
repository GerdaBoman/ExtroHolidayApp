using ExtroHoliday.Core.Logic;
using ExtroHoliday.Core.Logic.Interface;
using ExtroHoliday.Core.Mapper;
using ExtroHoliday.Core.Mapper.Interface;
using ExtroHoliday.Domain.Repositories;
using ExtroHoliday.Domain.Repositories.Interface;
using ExtroHoliday.Domain.Services;
using ExtroHoliday.Domain.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IThirdPartyApiRepository, ThirdPartyApiRepository>();
builder.Services.AddScoped<IThirdPartyApiService, ThirdPartyApiService>();
builder.Services.AddScoped<ICalendarValueMapper, CalendarValueMapper>();
builder.Services.AddScoped<ICalendar, Calendar>();
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
app.UseCors(options => options
.WithOrigins(new[] { "extroholidayapp.azurewebsites.net" })
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
