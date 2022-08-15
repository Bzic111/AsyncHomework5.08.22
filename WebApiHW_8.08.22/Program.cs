using WebApiHW_8._08._22.Holders;
using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Repository;
using WebApiHW_8._08._22.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IClientHolder, ClientHolder>();
builder.Services.AddSingleton<IEmployerHolder, EmployerHolder>();
builder.Services.AddSingleton<IInvoiceHolder, InvoiceHolder>();
builder.Services.AddSingleton<IContractHolder, ContractHolder>();
builder.Services.AddSingleton<IClientService, ClientService>();
builder.Services.AddSingleton<IEmployerService, EmployerService>();
builder.Services.AddSingleton<IInvoiceService, InvoiceService>();
builder.Services.AddSingleton<IContractService, ContractService>();
builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IEmployerRepository, EmployerRepository>();
builder.Services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddSingleton<IContractRepository, ContractRepository>();

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
