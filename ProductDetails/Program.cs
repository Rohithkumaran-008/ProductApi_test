using Microsoft.EntityFrameworkCore;
using ProductDetails.Data;
using ProductDetails.Repository.IRepository;
using ProductDetails.Repository;
using ProductDetails.Common;

var builder = WebApplication.CreateBuilder(args);

#region Configure CORS
builder.Services.AddCors(Options =>
{
    Options.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion 

#region Configure Database

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

#endregion

#region
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IIssueRepository, IssueRepository>();
builder.Services.AddTransient<IIssueDetailRepository, IssueDetailRepository>();

#endregion

#region Configure AutoMapper

builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion

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

app.UseCors("CustomPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
