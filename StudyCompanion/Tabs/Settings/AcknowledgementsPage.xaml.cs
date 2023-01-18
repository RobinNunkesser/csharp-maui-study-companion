namespace StudyCompanion;

public partial class AcknowledgementsPage : ContentPage
{
    private const string licenseFile = "acknowledgements.html";

    public AcknowledgementsPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        using var stream = await FileSystem.OpenAppPackageFileAsync(licenseFile);
        using var reader = new StreamReader(stream);

        var html = reader.ReadToEnd();

        var htmlSource = new HtmlWebViewSource
        {
            Html = html
        };
        Browser.Source = htmlSource;
    }
}
