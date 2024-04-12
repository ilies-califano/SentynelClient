namespace SentynelAndroidClient.Services.Location;

public interface ILocationService
{
    Task UpdateUserLocation(Models.Location.Location newLocReq, string token);
}