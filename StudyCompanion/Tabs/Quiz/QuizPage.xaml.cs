using Italbytz.Ports.Trivia;

namespace StudyCompanion;

public partial class QuizPage : ContentPage
{
    readonly QuizViewModel _viewModel;

    public QuizPage(QuizViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    async void Answer_Clicked(object sender, System.EventArgs e)
    {
        _viewModel.ButtonsEnabled = false;
        await answerLabel.FadeTo(1, 1000);
        await answerLabel.FadeTo(0, 200);
        _viewModel.ButtonsEnabled = true;
    }

    async void Statistics_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new QuizStatisticsPage(_viewModel));
    }
}
