using PISI_MOBILE.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureSubscribeRepo();
builder.Services.ConfigureServiceRepo();
builder.Services.ConfigureSubscribeService();
builder.Services.ConfigureService();
builder.Services.ConfigureTokenService();
builder.Services.ConfigureHttpContext();
builder.Services.ConfigureSubscribeValidator();
builder.Services.ConfigureLoginValidator();


var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "PISI-Assessment.API v1"));
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseJwtConfiguration();
app.MapControllers();

app.Run();
