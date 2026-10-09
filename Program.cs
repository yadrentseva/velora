using velora.Extensions;
using velora.Handlers;
using velora.Mapping;
using velora.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<CentralExceptionHandler>();

builder.Services.AddControllers().AddCustomValidationResponse(); 

builder.Services.AddSingleton<IEventService, EventService>();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();