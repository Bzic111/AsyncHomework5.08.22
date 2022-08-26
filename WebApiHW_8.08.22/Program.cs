using WebApiHW_8._08._22.DBContext;
using WebApiHW_8._08._22.Repository;
using WebApiHW_8._08._22.Services;
using Microsoft.Extensions.Configuration;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Interfaces.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<UserDbContext>();
//builder.Services.AddDbContext<CECIDbContext>();

builder.Services.AddControllers();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(UserService.SecretCode)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Geekbrains.AuSample",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme(Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geekbrains.AuSample v1"));
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
.SetIsOriginAllowed(origin => true)
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
