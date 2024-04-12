﻿using SentynelAndroidClient.ViewModels;

namespace SentynelAndroidClient.Views;

public partial class SettingsView : ContentPage
{
    public SettingsView(SettingsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}