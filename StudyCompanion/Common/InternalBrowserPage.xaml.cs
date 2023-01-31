namespace StudyCompanion;

public partial class InternalBrowserPage : ContentPage
{
    public InternalBrowserPage(string source)
    {
        InitializeComponent();
        Browser.Source = source;
    }
}
