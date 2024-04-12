using SentynelAndroidClient.Models.Candidat;

namespace SentynelAndroidClient.Services.Candidat;

public interface ICandidatService
{
    Task<IEnumerable<CandidatItem>> FilterAsync(string candidatPosteName, string candidatEtatName);
    Task<IEnumerable<CandidatItem>> GetsAsync();
    Task<CandidatItem> GetAsync(string candidatId);
    Task<IEnumerable<CandidatPoste>> GetCandidatPostesAsync();
    Task<IEnumerable<CandidatEtat>> GetCandidatEtatsAsync();
}