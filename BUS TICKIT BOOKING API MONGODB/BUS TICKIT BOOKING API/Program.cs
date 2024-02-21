using BUS_TICKIT_BOOKING_API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --------------------------- CONTEXT FILE ADDING ----------------------------------
builder.Services.AddSingleton<BusDbContext>();



//------------------------------ CROS LOGICS -------------------------------

builder.Services.AddCors(option => option.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAllOrigins");

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
