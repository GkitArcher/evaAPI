using Evaluacion2.Data;
using Evaluacion2.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProyectoServices>();
builder.Services.AddScoped<RolServices>();
builder.Services.AddScoped<UsuariosServices>();
builder.Services.AddScoped<HerramientaServices>();
builder.Services.AddScoped<TareaServices>();

builder.Services.AddControllers();

builder.Services.AddDbContext<ProyectoDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
