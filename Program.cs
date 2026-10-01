using velora;
using velora.Extensions;
using velora.Handlers;
using velora.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<CentralExceptionHandler>();

builder.Services.AddControllers().AddCustomValidationResponse(); 

builder.Services.AddSingleton<IEventService, EventService>();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();