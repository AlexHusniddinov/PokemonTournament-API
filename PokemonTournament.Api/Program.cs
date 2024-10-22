
using PokemonTournament.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Register services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
ConfigureMiddleware(app);

app.Run();

// Separate methods for cleaner structure
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{

    // Add Service dependencies
    services.AddDependencies();

    // Add controllers
    services.AddControllers();

    // Swagger configuration
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Configure CORS
    services.AddCors(options =>
    {
        options.AddPolicy("CorsApiAnyPolicy", policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });
}

void ConfigureMiddleware(WebApplication app)
{
    // Swagger only in development
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Global CORS policy
    app.UseCors("CorsApiAnyPolicy");

    // HTTPS redirection and authorization
    app.UseHttpsRedirection();
    app.UseAuthorization();

    // Map controllers
    app.MapControllers();

    // Optional: add a health check endpoint
    app.MapGet("/health", () => Results.Ok("API is running")).WithTags("Health Check");
}