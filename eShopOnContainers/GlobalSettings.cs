﻿namespace SentynelAndroidClient;

public class GlobalSetting
{
    public const string AzureTag = "Azure";
    public const string MockTag = "Mock";
    public const string DefaultEndpoint = "http://192.168.1.18:5065"; // i.e.: "http://YOUR_IP" or "http://YOUR_DNS_NAME"

    private string _baseIdentityEndpoint;
    private string _baseSentynelApiEndpoint;
    private string _baseGatewayMarketingEndpoint;

    public GlobalSetting()
    {
        AuthToken = "INSERT AUTHENTICATION TOKEN";

        BaseIdentityEndpoint = DefaultEndpoint;
        BaseSentynelApiEndpoint = DefaultEndpoint;
        BaseGatewayMarketingEndpoint = DefaultEndpoint;
    }

    public static GlobalSetting Instance { get; } = new GlobalSetting();

    public string BaseIdentityEndpoint
    {
        get => _baseIdentityEndpoint;
        set
        {
            _baseIdentityEndpoint = value;
            UpdateEndpoint(_baseIdentityEndpoint);
        }
    }

    public string BaseSentynelApiEndpoint
    {
        get => _baseSentynelApiEndpoint;
        set
        {
            _baseSentynelApiEndpoint = value;
            UpdateSentynelApiEndpoint(_baseSentynelApiEndpoint);
        }
    }

    public string BaseGatewayMarketingEndpoint
    {
        get => _baseGatewayMarketingEndpoint;
        set
        {
            _baseGatewayMarketingEndpoint = value;
            UpdateGatewayMarketingEndpoint(_baseGatewayMarketingEndpoint);
        }
    }

    public string ClientId { get; } = "xamarin";

    public string ClientSecret { get; } = "secret";

    public string AuthToken { get; set; }

    public string RegisterWebsite { get; set; }

    public string AuthorizeEndpoint { get; set; }

    public string UserInfoEndpoint { get; set; }

    public string TokenEndpoint { get; set; }

    public string LogoutEndpoint { get; set; }

    public string Callback { get; set; }

    public string LogoutCallback { get; set; }

    public string SentynelApiEndpoint { get; set; }

    public string GatewayMarketingEndpoint { get; set; }

    private void UpdateEndpoint(string endpoint)
    {
        RegisterWebsite = $"{endpoint}/Account/Register";
        LogoutCallback = $"{endpoint}/Account/Redirecting";

        var connectBaseEndpoint = $"{endpoint}/connect";
        AuthorizeEndpoint = $"{connectBaseEndpoint}/authorize";
        UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
        TokenEndpoint = $"{connectBaseEndpoint}/token";
        LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

        var baseUri = ExtractBaseUri(endpoint);
        Callback = $"{baseUri}/xamarincallback";
    }

    private void UpdateSentynelApiEndpoint(string endpoint)
    {
        SentynelApiEndpoint = endpoint;
    }

    private void UpdateGatewayMarketingEndpoint(string endpoint)
    {
        GatewayMarketingEndpoint = endpoint;
    }

    private static string ExtractBaseUri(string endpoint)
    {
        try
        {
            var uri = new Uri(endpoint);
            var baseUri = uri.GetLeftPart(UriPartial.Authority);

            return baseUri;
        }
        catch (Exception ex)
        {
            _ = ex;
            return DefaultEndpoint;
        }
    }
}
