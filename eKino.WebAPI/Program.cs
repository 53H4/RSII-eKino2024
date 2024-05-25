using eKino.Model.Requests;
using eKino.Model.SearchObjects;
using eKino.Services.Database;
using eKino.Services.Implementations;
using eKino.Services.Interfaces;
using eKino.WebAPI;
using eKino.WebAPI.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
        }
    });
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IService<eKino.Model.Role, BaseSearchObject>, BaseService<eKino.Model.Role, Role, BaseSearchObject>>();
builder.Services.AddTransient<IAuditoriumService, AuditoriumService>();
builder.Services.AddTransient<IDirectorService, DirectorService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IProjectionService, ProjectionService>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();


builder.Services.AddAutoMapper(typeof(IUserService));
builder.Services.AddAutoMapper(typeof(IAuditoriumService));
builder.Services.AddAutoMapper(typeof(IDirectorService));
builder.Services.AddAutoMapper(typeof(IGenreService));
builder.Services.AddAutoMapper(typeof(IMovieService));
builder.Services.AddAutoMapper(typeof(IProjectionService));
builder.Services.AddAutoMapper(typeof(IRatingService));
builder.Services.AddAutoMapper(typeof(IReservationService));
builder.Services.AddAutoMapper(typeof(ITransactionService));

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<eKinoContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<eKinoContext>();
    dataContext.Database.Migrate();
}

app.Run();
