using Microsoft.Extensions.FileProviders;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings()
                .GetCurrentClassLogger(); logger.Debug("init main");

try {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    var imagePath = app.Configuration["ImagePath"];
    if (String.IsNullOrEmpty(imagePath)) 
    {
        logger.Warn("No image path found. Cannot serve images to clients.");
    }
    else
    {
        var fileProvider = new PhysicalFileProvider(Path.GetFullPath(imagePath));
        var requestPath = new PathString("/images");
        
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = fileProvider,
            RequestPath = requestPath
        } );
        
        logger.Info($"Serving images to clients from path: {imagePath}");
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    app.MapGet("/", () => {
        var html = $"""
            <html><body>
                <h2>HaaV Catalog Service</h2>
                <br/>
            </body></html>
        """;
        return Results.Content(html, "text/html");
    });

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();   
}
