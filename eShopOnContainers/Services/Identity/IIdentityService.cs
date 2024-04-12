using SentynelAndroidClient.Models.Token;

namespace SentynelAndroidClient.Services.Identity;

public interface IIdentityService
{
    string CreateAuthorizationRequest();
    string CreateLogoutRequest(string token);
    Task<UserToken> GetTokenAsync(string code);
}