using Board.Application.Common.Abstractions.Persistence;
using SharedKernel.Messaging;
using User.Applicatiom.Common.Abstractions.Authentication;
using User.Applicatiom.Common.Abstractions.Security;
using User.Application.Features.User.Commands.SocialLogin;
using User.Application.Features.User.Commands.CreateUser;
using User.Infrastructure.Auth;
using User.Infrastructure.Security;
using User.Application.Common.Abstractions.Persistence;
using User.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICustomMediator, CustomMediator>();
builder.Services.AddScoped<ICommandHandler<SocialLoginCommand, string>, SocialLoginHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IExternalAuthService, GoogleAuthService>();
builder.Services.AddHttpClient<IExternalAuthService, FacebookAuthService>();
builder.Services.AddScoped<ITokenGenerator, JwtTokenGenerator>();

builder.Services.AddEndpointsApiExplorer();
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
