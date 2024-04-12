using SentynelAndroidClient.Services.Candidat;
using SentynelAndroidClient.Services.User;

namespace SentynelAndroidClient.Services.AppEnvironment;

public interface IAppEnvironmentService
{
    ICandidatService CandidatService { get; }
    IUserService UserService { get; }

    void UpdateDependencies(bool useMockServices);
}