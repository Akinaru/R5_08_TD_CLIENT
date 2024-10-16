using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TD1Client;
using TD1Client.Models;
using TD1Client.Models.DTO;
using TD1Client.Services;
using TD1Client.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Enregistrement du HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Enregistrement du service IService<Produit> avec ProduitService
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7231/") });


builder.Services.AddScoped<IService<Produit>, WSServiceProduit>();
builder.Services.AddScoped<IService<ProduitDto>, WSServiceProduitDto>();
builder.Services.AddScoped<IService<Marque>, WSServiceMarque>();
builder.Services.AddScoped<IService<TypeProduit>, WSServiceTypeProduit>();

builder.Services.AddScoped<ProduitViewModel>();
builder.Services.AddScoped<AddProduitsViewModel>();
builder.Services.AddScoped<EditProduitViewModel>();

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();