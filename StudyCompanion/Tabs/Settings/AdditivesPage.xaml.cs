﻿namespace StudyCompanion;

public partial class AdditivesPage : ContentPage
{
    public AdditivesPage()
    {
        InitializeComponent();
        BindingContext = new AdditivesViewModel();
    }
}
