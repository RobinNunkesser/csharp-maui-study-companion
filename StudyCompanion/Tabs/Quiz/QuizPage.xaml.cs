namespace StudyCompanion;

public partial class QuizPage : ContentPage
{
    private QuizViewModel viewModel = new QuizViewModel();

    public QuizPage()
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    async void Answer_Clicked(object sender, System.EventArgs e)
    {
        falseButton.IsEnabled = false;
        trueButton.IsEnabled = false;
        skipButton.IsEnabled = false;
        await answerLabel.FadeTo(1, 1000);
        await answerLabel.FadeTo(0, 200);
        falseButton.IsEnabled = true;
        trueButton.IsEnabled = true;
        skipButton.IsEnabled = true;
    }

    async void Statistics_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new QuizStatisticsPage(viewModel));
    }
}
