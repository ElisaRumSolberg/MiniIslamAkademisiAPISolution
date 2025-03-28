// Import necessary namespaces for building and running the web application
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Create a new WebApplicationBuilder instance
var builder = WebApplication.CreateBuilder(args);

// Add support for controllers (used in API structure)
builder.Services.AddControllers();

// Enable endpoint discovery for minimal API and Swagger support
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation services (OpenAPI documentation)
builder.Services.AddSwaggerGen(c =>
{
    // Use full class names to prevent schema name conflicts in Swagger
    c.CustomSchemaIds(type => type.FullName);
});

// Build the application from the builder configuration
var app = builder.Build();

// Enable Swagger and Swagger UI in development environment only
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();         // Serve Swagger JSON endpoint
    app.UseSwaggerUI();       // Serve interactive Swagger UI
}

// Serve static files (like JSON, CSS, JS, images) from wwwroot folder
app.UseStaticFiles();

// Redirect all HTTP requests to HTTPS (for secure communication)
app.UseHttpsRedirection();

// Enable authorization middleware (checks access permissions)
app.UseAuthorization();

// Map attribute-routed controllers (e.g., [Route("api/degerler")])
app.MapControllers();

// Start the web application and listen for incoming HTTP requests
app.Run();
