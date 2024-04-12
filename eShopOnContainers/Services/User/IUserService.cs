using SentynelAndroidClient.Models.User;

namespace SentynelAndroidClient.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string authToken);
    }
}