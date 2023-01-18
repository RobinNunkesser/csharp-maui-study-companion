namespace StudyCompanion;

public partial class QuizPage : ContentPage
{
    public QuizPage()
    {
        InitializeComponent();
    }

    async void Statistics_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new QuizStatisticsPage());
    }
}
