using BeeckerLearningGround.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IDynamicHttp, DynamicHttp>();

await builder.Build().RunAsync();
