using SentynelAndroidClient.Services.AppEnvironment;
using SentynelAndroidClient.Services.Navigation;
using SentynelAndroidClient.Services.Settings;
using SentynelAndroidClient.ViewModels.Base;

namespace SentynelAndroidClient.ViewModels;

public partial class ProfileViewModel : ViewModelBase
{
    private readonly IAppEnvironmentService _appEnvironmentService;
    private readonly ISettingsService _settingsService;

    public ProfileViewModel(
        IAppEnvironmentService appEnvironmentService, ISettingsService settingsService,
        INavigationService navigationService)
        : base(navigationService)
    {
        _appEnvironmentService = appEnvironmentService;
        _settingsService = settingsService;

    }



    [RelayCommand]
    private async Task LogoutAsync()
    {
        await IsBusyFor(
            async () =>
            {
                // Logout
                await NavigationService.NavigateToAsync(
                    "//Login",
                    new Dictionary<string, object> { { "Logout", true } });
            });
    }


}