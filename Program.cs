using velora;
using velora.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IEventService, EventService>();
    
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile)); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();