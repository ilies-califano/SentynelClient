using SentynelAndroidClient.Helpers;
using SentynelAndroidClient.Models.Candidat;
using SentynelAndroidClient.Services.RequestProvider;

namespace SentynelAndroidClient.Services.Candidat;

public class CandidatService : ICandidatService
{
    private readonly IRequestProvider _requestProvider;

    private const string ApiUrlBase = "api/Candidat";

    public CandidatService(IRequestProvider requestProvider)
    {
        _requestProvider = requestProvider;
    }

    public async Task<IEnumerable<CandidatItem>> FilterAsync(string candidatName)
    {
        var uri = UriHelper.CombineUri(GlobalSetting.Instance.SentynelApiEndpoint, $"{ApiUrlBase}/gets/principale");

        Lister elements = await _requestProvider.GetAsync<Lister>(uri).ConfigureAwait(false);

        return elements?.Donnees ?? Enumerable.Empty<CandidatItem>();
    }

    public async Task<IEnumerable<CandidatItem>> FilterAsync(string candidatPosteName, string candidatEtatName)
    {
        var data = await this.GetsAsync();

        if (data.Any())
        {
            var filtred = data.Where(d => d.Poste == candidatPosteName && d.candidat_etat == candidatEtatName).ToArray();
            return filtred.Any() 
                ? filtred
                : Enumerable.Empty<CandidatItem>();
        }
        else
            return Enumerable.Empty<CandidatItem>();

    }

    public async Task<IEnumerable<CandidatItem>> GetsAsync()
    {
        var uri = UriHelper.CombineUri(GlobalSetting.Instance.SentynelApiEndpoint, $"{ApiUrlBase}/gets/principale");

        Lister elements = await _requestProvider.GetAsync<Lister>(uri).ConfigureAwait(false);

        if (elements?.Donnees != null)
        {
            return elements.Donnees;
        }
        else
            return Enumerable.Empty<CandidatItem>();
    }

    public async Task<CandidatItem> GetAsync(string candidatId)
    {
        try
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.SentynelApiEndpoint, $"{ApiUrlBase}/get/{candidatId}");

            CandidatItem element =
                await _requestProvider.GetAsync<CandidatItem>(uri).ConfigureAwait(false);

            return element;
        }
        catch
        {
            return new CandidatItem();
        }
    }

    private readonly IEnumerable<CandidatPoste> MockCandidatPostes =
        new[]
        {
            new CandidatPoste { Id = 1, Poste = "Developpeur" },
            new CandidatPoste { Id = 2, Poste = "C#" },
        };

    private readonly IEnumerable<CandidatEtat> MockCandidatEtats =
        new[]
        {
            new CandidatEtat { Id = 1, Etat = "CMD" },
            new CandidatEtat { Id = 2, Etat = "LBR" }
        };


    public async Task<IEnumerable<CandidatPoste>> GetCandidatPostesAsync()
    {
        await Task.Delay(10);

        return MockCandidatPostes;
    }

    public async Task<IEnumerable<CandidatEtat>> GetCandidatEtatsAsync()
    {
        await Task.Delay(10);

        return MockCandidatEtats;
    }
}