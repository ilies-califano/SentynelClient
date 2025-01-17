﻿using SentynelAndroidClient.Helpers;
using SentynelAndroidClient.Models.User;
using SentynelAndroidClient.Services.RequestProvider;

namespace SentynelAndroidClient.Services.User;

public class UserService : IUserService
{
    private readonly IRequestProvider _requestProvider;

    public UserService(IRequestProvider requestProvider)
    {
        _requestProvider = requestProvider;
    }

    public async Task<UserInfo> GetUserInfoAsync(string authToken)
    {
        var uri = UriHelper.CombineUri(GlobalSetting.Instance.UserInfoEndpoint);

        var userInfo = await _requestProvider.GetAsync<UserInfo>(uri, authToken);
        return userInfo;
    }
}