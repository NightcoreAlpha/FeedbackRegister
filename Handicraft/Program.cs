using Handicraft.Data;
using Handicraft.Infrastructure;
using Handicraft.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<DataGridService>();
builder.Services.AddScoped<Counter>();
builder.Services.AddScoped<AddEmployee>();
builder.Services.AddScoped<UpdateEmployee>();
builder.Services.AddScoped<GetDataClass>();
builder.Services.AddScoped<AddComment>();
builder.Services.AddScoped<Product>();
builder.Services.AddScoped<Radzen.NotificationService>();
builder.Services.AddScoped<AddProductPage>();
//
builder.Services.AddOptions();
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

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

public class TokenAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;
    public TokenAuthenticationStateProvider(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }


    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        AuthenticationState CreateAnonymous()
        {
            var anonymousIdentity = new ClaimsIdentity();
            var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
            return new AuthenticationState(anonymousPrincipal);

        }
        var token = await _localStorageService.GetAsync<SecurityToken>(nameof(SecurityToken));

        if (token == null)
        {
            return CreateAnonymous();
        }

        if (string.IsNullOrEmpty(token.AccessToken) || token.ExpiredAt < DateTime.UtcNow)
        {
            return CreateAnonymous();
        }

        //Create real user state

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Country,"Russia"),
            new Claim(ClaimTypes.Name,token.UserName),
            new Claim(ClaimTypes.Expired,token.ExpiredAt.ToShortDateString()),
            new Claim(ClaimTypes.Role,"Administrator1"),
            new Claim(ClaimTypes.Role,"User1"),
            new Claim("warmachine","ruled")
    };

        var identity = new ClaimsIdentity(claims, "Token");
        var principal = new ClaimsPrincipal(identity);
        return new AuthenticationState(principal);
    }

    public void MakeUserAnonymous()
    {
        _localStorageService.RemoveAsync(nameof(SecurityToken));
        var anonymousIdentity = new ClaimsIdentity();
        var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
        var authState = Task.FromResult(new AuthenticationState(anonymousPrincipal));
        NotifyAuthenticationStateChanged(authState);
    }
}