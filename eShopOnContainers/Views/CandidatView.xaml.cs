//using CommunityToolkit.Mvvm.Messaging;

using SentynelAndroidClient.Views;

namespace SentynelAndroidClient.Views;

public partial class CandidatView : ContentPageBase
{
    public CandidatView(CandidatViewModel viewModel)
    {
        BindingContext = viewModel;

        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        //WeakReferenceMessenger.Default
        //    .Register<CatalogView, Messages.AddProductMessage>(
        //        this,
        //        async (recipient, message) =>
        //        {
        //            await recipient.Dispatcher.DispatchAsync(
        //                async () =>
        //                {
        //                    await recipient.badge.ScaleTo(1.2);
        //                    await recipient.badge.ScaleTo(1.0);
        //                });
        //        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        //WeakReferenceMessenger.Default.Unregister<Messages.AddProductMessage>(this);
    }
}