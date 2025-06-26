using BoardApplication.Common.Abstractions.Persistence;
using BoardApplication.Features.Board.Commands.CreateBoard;
using Board.Persistence.Repositories;
using MongoDB.Driver;
using SharedKernel.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICustomMediator, CustomMediator>();
builder.Services.AddScoped<ICommandHandler<CreateBoardCommand, Guid>, CreateBoardHandler>();
builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient("mongodb://localhost:27017"));
builder.Services.AddScoped(sp => sp.GetRequiredService<IMongoClient>().GetDatabase("Ordine"));
builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
