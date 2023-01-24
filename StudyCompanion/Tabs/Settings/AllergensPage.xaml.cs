namespace StudyCompanion;

public partial class AllergensPage : ContentPage
{
    public AllergensPage()
    {
        InitializeComponent();
        BindingContext = new AllergensViewModel();
    }
}
