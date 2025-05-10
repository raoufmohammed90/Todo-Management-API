using GTS.TodoMgmt.WebApi.Middlewares;
using GTS.ToDoMgmt.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigins",
        policy =>
        {
            policy
                .WithOrigins("http://localhost", "http://127.0.0.1") 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.Run();
