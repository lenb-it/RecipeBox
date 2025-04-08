using Recipe.API.Extensions;
using Recipe.Core.Options;
using Recipe.Infrastracture;

using Serilog;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var environment = builder.Environment;
var services = builder.Services;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

services.AddDbContext(configuration, environment);

services.AddValidation();
services.AddMappingConfigs();
services.AddApiRepositories();
services.AddApiServices();
services.AddApiAuthentication(configuration);

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(options => { });

app.UseApiCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();

app.AddMappedEndPoins();

app.Run();