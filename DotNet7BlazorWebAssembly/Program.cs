using DotNet7BlazorWebAssembly;
using DotNet7BlazorWebAssembly.Services.SuperHeroService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var uri = builder.Configuration.GetValue<string>("superhero:uri");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(uri) });

builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();

await builder.Build().RunAsync();
