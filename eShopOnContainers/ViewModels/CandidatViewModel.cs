using SentynelAndroidClient.Models.Candidat;
using SentynelAndroidClient.Services.AppEnvironment;
using SentynelAndroidClient.Services.Navigation;
using SentynelAndroidClient.Services.Settings;
using SentynelAndroidClient.ViewModels.Base;

namespace SentynelAndroidClient.ViewModels;

public partial class CandidatViewModel : ViewModelBase
{
    private readonly IAppEnvironmentService _appEnvironmentService;
    private readonly ISettingsService _settingsService;

    private readonly ObservableCollectionEx<CandidatItem> _candidats = new();
    private readonly ObservableCollectionEx<CandidatPoste> _postes = new();
    private readonly ObservableCollectionEx<CandidatEtat> _etats = new();

    [ObservableProperty]
    private CandidatItem _selectedCandidat;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsFilter))]
    [NotifyCanExecuteChangedFor(nameof(FilterCommand))]
    private CandidatPoste _poste;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsFilter))]
    [NotifyCanExecuteChangedFor(nameof(FilterCommand))]
    private CandidatEtat _etat;

    [ObservableProperty]
    private int _badgeCount;

    private bool _initialized;

    public IReadOnlyList<CandidatItem> Candidats => _candidats;

    public IReadOnlyList<CandidatPoste> Postes => _postes;

    public IReadOnlyList<CandidatEtat> Etats => _etats;

    public bool IsFilter => Poste is not null && Etat is not null;

    public CandidatViewModel(
        IAppEnvironmentService appEnvironmentService,
        INavigationService navigationService, ISettingsService settingsService)
        : base(navigationService)
    {
        _appEnvironmentService = appEnvironmentService;
        _settingsService = settingsService;

        _candidats = new ObservableCollectionEx<CandidatItem>();
        _postes = new ObservableCollectionEx<CandidatPoste>();
        _etats = new ObservableCollectionEx<CandidatEtat>();
    }

    public override async Task InitializeAsync()
    {
        if (_initialized)
            return;

        _initialized = true;
        await IsBusyFor(
            async () =>
            {
                // Get Candidat, Postes and etast 
                var candidats = await _appEnvironmentService.CandidatService.GetsAsync();
                var postes = await _appEnvironmentService.CandidatService.GetCandidatPostesAsync();
                var etats = await _appEnvironmentService.CandidatService.GetCandidatEtatsAsync();

                var authToken = _settingsService.AuthAccessToken;
                var userInfo = await _appEnvironmentService.UserService.GetUserInfoAsync(authToken);

                BadgeCount = 0;

                _candidats.ReloadData(candidats);
                _postes.ReloadData(postes);
                _etats.ReloadData(etats);
            });
    }

    [RelayCommand]
    private async Task ShowFilterAsync()
    {
        await NavigationService.NavigateToAsync("Filter");
    }

    [RelayCommand(CanExecute = nameof(IsFilter))]
    private async Task FilterAsync()
    {
        await IsBusyFor(
            async () =>
            {
                if (Poste != null || Etat != null)
                {
                    var filteredCandidats = await _appEnvironmentService.CandidatService.FilterAsync(Poste.Poste, Etat.Etat);
                    _candidats.ReloadData(filteredCandidats);
                }

                await NavigationService.PopAsync();
            });
    }

    [RelayCommand]
    private async Task ClearFilterAsync()
    {
        await IsBusyFor(
            async () =>
            {
                Poste = null;
                Etat = null;
                var allCandidats = await _appEnvironmentService.CandidatService.GetsAsync();
                _candidats.ReloadData(allCandidats);

                await NavigationService.PopAsync();
            });
    }

    [RelayCommand]
    private async Task CandidatDetailAsync(CandidatItem candidat)
    {
        if (candidat is null || IsBusy)
        {
            return;
        }

        await NavigationService.NavigateToAsync(
            "CandidatDetail",
            new Dictionary<string, object> { { nameof(CandidatItem.Id), candidat.Id } });
    }
}
