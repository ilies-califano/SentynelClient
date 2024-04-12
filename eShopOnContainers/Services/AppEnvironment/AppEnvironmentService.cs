using SentynelAndroidClient.Services.Candidat;
using SentynelAndroidClient.Services.User;

namespace SentynelAndroidClient.Services.AppEnvironment;

public class AppEnvironmentService : IAppEnvironmentService
{
    private readonly ICandidatService _mockCandidatService;
    private readonly ICandidatService _candidatService;

    private readonly IUserService _mockUserService;
    private readonly IUserService _userService;

    public ICandidatService CandidatService { get; private set; }

    public IUserService UserService { get; private set; }

    public AppEnvironmentService(
        ICandidatService mockCandidatService, ICandidatService candidatService,
        IUserService mockUserService, IUserService userService)
    {
        _mockCandidatService = mockCandidatService;
        _candidatService = candidatService;

        _mockUserService = mockUserService;
        _userService = userService;
    }

    public void UpdateDependencies(bool useMockServices)
    {
        if (useMockServices)
        {
            CandidatService = _mockCandidatService;

            UserService = _mockUserService;
        }
        else
        {
            CandidatService = _candidatService;

            UserService = _mockUserService;
        }
    }
}

