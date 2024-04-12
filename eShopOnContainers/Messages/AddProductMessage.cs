using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SentynelAndroidClient.Messages;

public class AddProductMessage : ValueChangedMessage<int>
{
    public AddProductMessage(int count) : base(count)
    {
    }
}

