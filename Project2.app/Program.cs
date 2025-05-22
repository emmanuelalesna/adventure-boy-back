using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project2.app.DataAccess;
using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;
using Project2.app.Services;
using Project2.app.Services.Interface;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

builder.Services.AddCors(co =>
{
    co.AddPolicy("CORS", pb =>
    {
        pb.WithOrigins("*")
        .AllowAnyHeader();
        pb.AllowAnyMethod();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalTest")));

builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IRepo<Enemy>, EnemyRepo>();
builder.Services.AddScoped<IRepo<Item>, ItemRepo>();
builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
builder.Services.AddScoped<IRepo<Room>, RoomRepo>();
builder.Services.AddScoped<IRepo<Spell>, SpellRepo>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IService<Enemy>, EnemyService>();
builder.Services.AddScoped<IService<Item>, ItemService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IService<Room>, RoomService>();
builder.Services.AddScoped<IService<Spell>, SpellService>();

builder.Services.AddControllers()
.AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddIdentityApiEndpoints<Account>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGroup("api/Account").MapIdentityApi<Account>();

app.Run();
