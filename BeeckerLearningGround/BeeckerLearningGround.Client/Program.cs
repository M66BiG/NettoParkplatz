using BeeckerLearningGround.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("JsonPlaceholder", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

await builder.Build().RunAsync();
