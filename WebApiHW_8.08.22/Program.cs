using WebApiHW_8._08._22.DBContext;
using WebApiHW_8._08._22.Repository;
using WebApiHW_8._08._22.Services;
using Microsoft.Extensions.Configuration;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Interfaces.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<UserDbContext>();
//builder.Services.AddDbContext<CECIDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UserDbContext>();
builder.Services.AddSingleton<CECIDbContext>();

builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IEmployerRepository, EmployerRepository>();
builder.Services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddSingleton<IContractRepository, ContractRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddSingleton<IClientService, ClientService>();
builder.Services.AddSingleton<IEmployerService, EmployerService>();
builder.Services.AddSingleton<IInvoiceService, InvoiceService>();
builder.Services.AddSingleton<IContractService, ContractService>();
builder.Services.AddSingleton<IUserService, UserService>();




var app = builder.Build();
app.UseWelcomePage("/started");
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
