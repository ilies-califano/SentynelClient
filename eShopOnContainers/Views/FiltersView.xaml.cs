namespace SentynelAndroidClient.Views;

public partial class FiltersView : ContentPage
{
    public FiltersView(CandidatViewModel viewModel)
    {
        BindingContext = viewModel;

        InitializeComponent();
    }
}
