//using Android.OS;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services;
using RecipeApp.Infrastructure.Timers;
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
        // TODO: register domain services (interfaces -> implementations)
        builder.Services.AddSingleton<ITimerService, CountdownTimerService>();
        // TODO: register ViewModels
        builder.Services.AddTransient<MainViewModel>();
        // TODO: register Pages
        builder.Services.AddTransient<MainPage>();
    }
}