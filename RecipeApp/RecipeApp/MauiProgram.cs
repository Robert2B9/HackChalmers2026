//using Android.OS;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services;
using RecipeApp.Infrastructure.Navigation;
using RecipeApp.Infrastructure.Recipes;
using RecipeApp.Infrastructure.Timers;
using RecipeApp.Pages;
using RecipeApp.ViewModels;

namespace RecipeApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        RegisterServices(builder);
        return builder.Build();
    }

    private static void RegisterServices(this MauiAppBuilder builder)
    {
// Services
        builder.Services.AddSingleton<ITimerService, CountdownTimerService>();
        builder.Services.AddSingleton<IRecipeRepository, InMemoryRecipeRepository>();
        builder.Services.AddSingleton<INavigationService, ShellNavigationService>();

// ViewModels
        builder.Services.AddTransient<RecipeListViewModel>();
        builder.Services.AddTransient<CookingViewModel>();

// Pages
        builder.Services.AddTransient<RecipeListPage>();
        builder.Services.AddTransient<CookingPage>();
    }
}