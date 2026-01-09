using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using vcapp.Movies.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();


// Add services to the container.
//builder.Services.AddSingleton<IMovieService, MovieService>();

builder.Services.AddInfrastructure();


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                Console.WriteLine("TOKEN RECIBIDO: [" + context.Token + "]");
                return Task.CompletedTask;
            },            
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("AUTH FAILED: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                Console.WriteLine("AUTH CHALLENGE: " + context.ErrorDescription);
                return Task.CompletedTask;
            }
        };

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "videoclub",
            ValidAudience = "videoclub",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key-1234-super-secret-key-1234"))
        };
    });

//.AddJwtBearer("Bearer", options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = "videoclub",
//        ValidAudience = "videoclub",
//        IssuerSigningKey = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes("super-secret-key-1234-super-secret-key-1234"))
//    };
//});


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
