using Fatec.Store.Orders.Api.IoC;
using Fatec.Store.Orders.Infrastructure.Data.v1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.InjectDependencies(builder);

var app = builder.Build();

DatabaseManagementService.MigrationInitialisation(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
