﻿using Microsoft.Maui.Controls.Maps;

namespace SentynelAndroidClient.Views;

public partial class MapView : ContentPageBase
{
    public MapView(MapViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();

        var map = new Microsoft.Maui.Controls.Maps.Map(new Microsoft.Maui.Maps.MapSpan(new Location(0, 0), 0,0));
    }

    async void Pin_MarkerClicked(System.Object sender, PinClickedEventArgs e)
    {
        e.HideInfoWindow = true;

        if (sender is not Pin pin)
        {
            return;
        }

        await pin.Location.OpenMapsAsync();
    }
}
