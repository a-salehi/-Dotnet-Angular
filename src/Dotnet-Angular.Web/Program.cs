using Dotnet_Angular.Application;
using Dotnet_Angular.Database;
using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Logging;
using DotNetCore.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddResponseCompression();
builder.Services.AddSwaggerGen();
builder.Services.AddSpaStaticFiles("Frontend");
builder.Services.AddContext<Context>(options => options.UseSqlServer(builder.Services.GetConnectionString(nameof(Context))));
builder.Services.AddClassesMatchingInterfaces(typeof(IUserService).Assembly, typeof(IUserRepository).Assembly);
builder.Services.AddControllers().AddJsonOptions();

var app = builder.Build();

app.UseException();
// app.UseHttps();
app.UseResponseCompression();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseSpaAngular("Frontend", "start", "http://localhost:4200");

// app.MapGet("/", () => "Hello World!");

app.Run();