using EpsilonTest.Application.Implementations;
using EpsilonTest.Application.Interfaces;
using EpsilonTest.BlazorWasm.Client;
using EpsilonTest.Data.Context;
using EpsilonTest.Data.Interfaces;
using EpsilonTest.Data.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddDbContext<CustomerDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
	);

await builder.Build().RunAsync();
