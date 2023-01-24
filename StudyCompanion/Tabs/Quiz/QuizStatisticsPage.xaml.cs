namespace StudyCompanion;

public partial class QuizStatisticsPage : ContentPage
{
    readonly QuizViewModel _viewModel;

    public QuizStatisticsPage(QuizViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}
