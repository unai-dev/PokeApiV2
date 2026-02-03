using Microsoft.EntityFrameworkCore;
using PokeApiV2.Data;

var builder = WebApplication.CreateBuilder(args);

// === Services Area ===
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

var app = builder.Build();

// === Middlewares Area ===
app.MapControllers();
app.Run();
