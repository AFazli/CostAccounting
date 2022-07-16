using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shoniz.CostAccounting.Ui.BlazorApp;
using Shoniz.CostAccounting.Ui.BlazorApp.Services;
using Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5160") });

builder.Services.AddScoped<IFormulationService, FormulationService>();
builder.Services.AddScoped<IFormulationDetailService, FormulationDetailService>();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();
