namespace StudyCompanion;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    async void Acknowledgments_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AcknowledgementsPage());
    }

    async void Additives_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AdditivesPage());
    }

    async void Allergens_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AllergensPage());
    }


}
