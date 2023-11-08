namespace StudyCompanion;

public partial class InternalBrowserPage : ContentPage
{
    public InternalBrowserPage(WebViewSource source)
    {
        InitializeComponent();
        Browser.Source = source;
    }
}
