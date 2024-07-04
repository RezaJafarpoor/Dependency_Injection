using Dependency_Injection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<LifeTimeIndicator>();
// Transient implementation
// builder.Services.AddTransient<IdGenerator>();

// Singleton implementation
// builder.Services.AddSingleton<IdGenerator>();

//Scope implementation
//builder.Services.AddScoped<IdGenerator>();

//Manual Injection for AddScoped

builder.Services.AddScoped(provider =>
{
    var idGenerator = provider.GetRequiredService<IdGenerator>();
    var logger = provider.GetRequiredService<ILogger<LifeTimeIndicator>>();
    return new LifeTimeIndicator(idGenerator, logger);

});

// Manual Injection for AddSingleton
//Because Singleton can only have a single instance, it doesn't need that lambda logic.
builder.Services.AddSingleton(new IdGenerator()); 

// Manual Injection AddTransient
//Transient needs a new instance everytime
builder.Services.AddTransient(_ => new IdGenerator());





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

