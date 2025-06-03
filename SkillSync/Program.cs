using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using SkillSync.Extensions;
using SkillSync.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//Please refer ServiceExtension.cs  for this configuration.
builder.Services.ConfigureDatabase(builder.Configuration)
    .ConfigureCors()
    .ConfigureJwt(builder.Configuration)
    .ConfigureSerilog(builder);

builder.Services.AddServiceCollection();
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Custom middleware for exception handling
app.UseMiddleware<RateLimitingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();

app.Run();
