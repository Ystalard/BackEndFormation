using BackEndFormation.Core.Selfies.Domain;
using BackEndFormation.Core.Selfies.Infrastructures.Data;
using BackEndFormation.Core.Selfies.Infrastructures.Repositories;
using Microsoft.EntityFrameworkCore;
using BackEndFormation.ExtensionMethods;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// inform the services where the context select, update, insert the datas. Here it comes from a sql database.
builder.Services.AddDbContext<SelfiesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SelfiesDatabase"), sqlOptions => {});
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<SelfiesContext>();

builder.Services.AddInjections();
builder.Services.AddCustomOptions(builder.Configuration);
builder.Services.AddCustomSecurity(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(SecurityMethods.DEFAULT_POLICY);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
