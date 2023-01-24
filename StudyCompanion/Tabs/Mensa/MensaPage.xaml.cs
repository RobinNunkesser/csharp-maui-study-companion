using System.Diagnostics;
using Italbytz.Ports.Meal;

namespace StudyCompanion;

public partial class MensaPage : ContentPage
{
    private readonly IGetMealsService _service;
    readonly MensaViewModel _viewModel;

    public MensaPage(MensaViewModel viewModel, IGetMealsService service)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        _service = service;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            Success(await _service.Execute(new MealQuery() { Mensa = 42, Date = DateTime.Now }));
        }
        catch (Exception ex)
        {
            Error(ex);
        }
    }

    private async void Success(List<IMealCollection> meals)
    {
        Debug.WriteLine(meals);
    }

    private async void Error(Exception ex)
    {
        await DisplayAlert(StudyCompanion.Resources.Strings.AppResources.Error, StudyCompanion.Resources.Strings.AppResources.ErrorMessage, StudyCompanion.Resources.Strings.AppResources.OK);
    }
}
