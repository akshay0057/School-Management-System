using BlazorServerUIApp.Redux.Effects.Auth;
using BlazorServerUIApp.Redux.Reducers.Auth;
using BlazorServerUIApp.Services;
using BlazorServerUIApp.Services.IServices;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using MatBlazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap(); // Custom add
builder.Services.AddMatBlazor(); // Custom Add


// Register HttpClient and IHttpClientFactory
builder.Services.AddHttpClient();

builder.Services.AddScoped<CommonCallAPI>();
builder.Services.AddScoped<IMasterService, MasterService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<LoginEffect>();
builder.Services.AddScoped<LoginRequestReducer>();

// Add Fluxor (Custom Add)
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);
    options.UseReduxDevTools(rdt =>
    {
        rdt.Name = "School Management System";
    });
});


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
