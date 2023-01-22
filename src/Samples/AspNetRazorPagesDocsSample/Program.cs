using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phoenix.Docs.Configuration;
using Phoenix.Docs.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Adding Options for Phoenix.Docs
// Todo: Add to docs
builder.Services.Configure<DocsOptions>(builder.Configuration.GetSection(DocsOptions.CONFIG_KEY));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Registering the Phoenix.Docs controllers
// Todo: Add to docs
app.MapPhoenixDocsControllers();

app.Run();
