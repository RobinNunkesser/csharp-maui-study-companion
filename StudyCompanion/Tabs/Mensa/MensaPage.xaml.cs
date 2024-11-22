using System.Diagnostics;
using Italbytz.Ports.Meal;
using StudyCompanion.Resources.Strings;

namespace StudyCompanion;

public partial class MensaPage : ContentPage
{
    private readonly IGetMealsService _service;
    private readonly MensaViewModel _viewModel;

    public MensaPage(MensaViewModel viewModel, IGetMealsService service)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        _service = service;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            await Task.Delay(500);
            Success(await _service.Execute(new MealQuery() { Mensa = 35, Date = DateTime.Now }));
        }
        catch (Exception ex)
        {
            Error(ex);
        }
    }

    private async void Success(List<IMealCollection> meals)
    {
        await Task.Delay(500);
        if (Settings.WelcomeStatus == (int)WelcomeStatusType.Unfinished)
        {
            var statusChoices = new List<string> { AppResources.Student, AppResources.Staff, AppResources.Guest };
            var chosenStatus = AppResources.Student;
            // TODO: Remove this when DisplayActionSheet is working again on Mac Catalyst
#if MACCATALYST
#else            
            chosenStatus = await DisplayActionSheet(AppResources.StatusQuery, AppResources.Cancel, null, statusChoices.ToArray());
#endif
            if (!chosenStatus.Equals(AppResources.Cancel))
            {
                Settings.WelcomeStatus = (int)WelcomeStatusType.Finished;
                Settings.Status = statusChoices.IndexOf(chosenStatus);
            }
        }
        if (meals.Count > 0)
        {
            _viewModel.SetMeals(meals);
        }
        else
        {
            await DisplayAlert(AppResources.Error, AppResources.NoMeals, AppResources.OK);
        }
    }

    private async void Error(Exception ex)
    {
        await DisplayAlert(AppResources.Error, AppResources.ErrorMessage, AppResources.OK);
    }

    async void ToolbarItem_Clicked(object sender, System.EventArgs e) => await this.ToolbarItemClicked();

}
