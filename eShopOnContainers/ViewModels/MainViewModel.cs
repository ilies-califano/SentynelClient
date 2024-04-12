using SentynelAndroidClient.Services.Navigation;
using SentynelAndroidClient.ViewModels.Base;

namespace SentynelAndroidClient.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel(INavigationService navigationService)
        : base(navigationService)
    {
    }

    [RelayCommand]
    private async Task SettingsAsync()
    {
        await NavigationService.NavigateToAsync("Settings");
    }
}