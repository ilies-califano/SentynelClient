using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SentynelAndroidClient.Services.AppEnvironment;
using SentynelAndroidClient.Services.Candidat;
using SentynelAndroidClient.Services.Dialog;
using SentynelAndroidClient.Services.Identity;
using SentynelAndroidClient.Services.Location;
using SentynelAndroidClient.Services.Navigation;
using SentynelAndroidClient.Services.OpenUrl;
using SentynelAndroidClient.Services.RequestProvider;
using SentynelAndroidClient.Services.Settings;
using SentynelAndroidClient.Services.Theme;
using SentynelAndroidClient.Services.User;
using SentynelAndroidClient.Views;

namespace SentynelAndroidClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
        => MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureEffects(
                effects =>
                {
                })
            .UseMauiCommunityToolkit()
            .ConfigureFonts(
                fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font_Awesome_5_Free-Regular-400.otf", "FontAwesome-Regular");
                    fonts.AddFont("Font_Awesome_5_Free-Solid-900.otf", "FontAwesome-Solid");
                    fonts.AddFont("Montserrat-Bold.ttf", "Montserrat-Bold");
                    fonts.AddFont("Montserrat-Regular.ttf", "Montserrat-Regular");
                    fonts.AddFont("SourceSansPro-Regular.ttf", "SourceSansPro-Regular");
                    fonts.AddFont("SourceSansPro-Solid.ttf", "SourceSansPro-Solid");
                })
            .ConfigureEssentials(
                essentials =>
                {
                    essentials
                        .AddAppAction(AppActions.ViewProfileAction)
                        .OnAppAction(App.HandleAppActions);
                })
            .UseMauiMaps()
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews()
            .Build();

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
        mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
        mauiAppBuilder.Services.AddSingleton<IOpenUrlService, OpenUrlService>();
        mauiAppBuilder.Services.AddSingleton<IRequestProvider, RequestProvider>();
        mauiAppBuilder.Services.AddSingleton<IIdentityService, IdentityService>();
        mauiAppBuilder.Services.AddSingleton<ILocationService, LocationService>();

        mauiAppBuilder.Services.AddSingleton<ITheme, Theme>();

        mauiAppBuilder.Services.AddSingleton<IAppEnvironmentService, AppEnvironmentService>(
            serviceProvider =>
            {
                var requestProvider = serviceProvider.GetService<IRequestProvider>();
                var settingsService = serviceProvider.GetService<ISettingsService>();

                var aes =
                    new AppEnvironmentService(
                        new CandidatMockService(), new CandidatService(requestProvider),
                        new UserMockService(), new UserService(requestProvider));

                aes.UpdateDependencies(settingsService.UseMocks);
                return aes;
            });

#if DEBUG
        mauiAppBuilder.Logging.AddDebug();
#endif

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainViewModel>();
        mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
        mauiAppBuilder.Services.AddSingleton<MapViewModel>();
        mauiAppBuilder.Services.AddSingleton<ProfileViewModel>();

        mauiAppBuilder.Services.AddTransient<SettingsViewModel>();

        mauiAppBuilder.Services.AddTransient<CandidatViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<FiltersView>();
        mauiAppBuilder.Services.AddTransient<LoginView>();
        mauiAppBuilder.Services.AddTransient<MapView>();
        mauiAppBuilder.Services.AddTransient<ProfileView>();
        mauiAppBuilder.Services.AddTransient<SettingsView>();

        mauiAppBuilder.Services.AddTransient<CandidatView>();

        return mauiAppBuilder;
    }
}