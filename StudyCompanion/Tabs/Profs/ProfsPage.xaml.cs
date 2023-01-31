namespace StudyCompanion;

public partial class ProfsPage : ContentPage
{
    public ProfsPage()
    {
        InitializeComponent();
        BindingContext = new ProfsViewModel(Navigation);
    }
}
