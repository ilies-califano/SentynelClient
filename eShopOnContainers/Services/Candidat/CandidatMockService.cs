using SentynelAndroidClient.Models.Candidat;

namespace SentynelAndroidClient.Services.Candidat;

public class CandidatMockService : ICandidatService
{
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

    private readonly IEnumerable<CandidatItem> MockCandidat =
        new[]
        {
            new CandidatItem { Id = "guid1", Nom = "CALIFANO", Prenom = "Ilyes", Tjm30 = 19.50M, Experience = 2, Nationalite = "France",   Poste = "Developer" },
            new CandidatItem { Id = "guid2", Nom = "BOUKERT", Prenom = "Mahfoud", Tjm30 = 19.50M, Experience = 2, Nationalite = "Algeria",  Poste = "Fullstack" },
            new CandidatItem { Id = "guid3", Nom = "KHALIL", Prenom = "Khalil", Tjm30 = 20.00M, Experience = 5, Nationalite = "Algeria",  Poste = "Java" },
            new CandidatItem { Id = "guid4", Nom = "CALIFANO", Prenom = "Mehdi", Tjm30 = 99.00M, Experience = 2, Nationalite = "France",  Poste = "BOSS" },
            new CandidatItem { Id = "guid5", Nom = "BOUDISSA", Prenom = "Djamel", Tjm30 = 19.50M, Experience = 1, Nationalite = "Tunisia",  Poste = "NoCode" }
        };

    public async Task<IEnumerable<CandidatItem>> GetsAsync()
    {
        await Task.Delay(10);

        return MockCandidat;
    }

    public async Task<IEnumerable<CandidatItem>> FilterAsync(string candidatPosteName, string candidatEtatName)
    {
        await Task.Delay(10);

        return MockCandidat
            .Where(
                c => c.Poste == candidatPosteName && c.candidat_etat == candidatEtatName)
            .ToArray();
    }

    public async Task<CandidatItem> GetAsync(string candidatId)
    {
        await Task.Delay(10);

        return MockCandidat
            .Where(
                c => c.Id == candidatId)
            .SingleOrDefault();
    }


}
