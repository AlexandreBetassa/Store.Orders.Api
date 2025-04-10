using Fatec.Store.Orders.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InjectDependencies(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
