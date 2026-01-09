#pragma warning disable CA1506 // Avoid excessive class coupling
using Asp.Versioning;
using Serilog;
using StackifyLib;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Azure.Identity;
using RiskScore.Api.Documentation;
using RiskScore.Api.Extensions;
using RiskScore.Application;
using RiskScore.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Logger
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Controllers
builder.Services.AddControllers(c => c.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// AzureKeyVault
if (!builder.Environment.IsDevelopment())
{
    var keyVaultName = builder.Configuration["KeyVaultName"];
    var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");
    builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
}

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

// Application + Infrastructure
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Localization
builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var defaultCulture = "en-US";
    IList<CultureInfo> supportedCultures =
    [
        new(defaultCulture),
        new("es-ES")
    ];

    opt.DefaultRequestCulture = new RequestCulture(culture: defaultCulture, uiCulture: defaultCulture);
    opt.SupportedCultures = supportedCultures;
    opt.SupportedUICultures = supportedCultures;
    opt.RequestCultureProviders = [new AcceptLanguageHeaderRequestCultureProvider()];
});

builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Swagger en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

// Middlewares
app.UseRequestLocalization();
app.UseRequestContextLogging();
app.UseSerilogRequestLogging();
app.UseCustomExceptionHandler();

// Stackify
app.ConfigureStackifyLogging(app.Configuration);

app.MapControllers();

// API Versioning
var apiVersion = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();

var routeGroupBuilder = app
    .MapGroup("api/v{version:apiVersion}")
    .WithApiVersionSet(apiVersion);

await app.RunAsync();
public partial class Program { }

#pragma warning restore CA1506 // Avoid excessive class coupling
