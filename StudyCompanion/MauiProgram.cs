using Italbytz.Adapters.Meal.Mock;
using Italbytz.Ports.Meal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Italbytz.Adapters.Meal.OpenMensa;

namespace StudyCompanion;

enum Environment
{
    Development,
    Staging,
    Production
}

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var env = Environment.Production;
#if DEBUG
        //env = Environment.Development;
#endif
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().RegisterServices();

        switch (env)
        {
            case Environment.Development:
                builder.Logging.AddDebug();
                builder.Services.AddSingleton<IGetMealsService, MockGetMealsService>();
                break;
            case Environment.Staging:
            case Environment.Production:
                builder.Services.AddSingleton<IGetMealsService>(new OpenMensaGetMealsService(new OpenMensaMealDataSource(35, DateTime.Now)));
                break;
            default:
                break;
        }
        return builder.Build();
    }

    private static MauiAppBuilder RegisterServices(
        this MauiAppBuilder mauiAppBuilder
    )
    {
        mauiAppBuilder.Services.AddLocalization();
        mauiAppBuilder.Services.AddSingleton<QuizPage>();
        mauiAppBuilder.Services.AddSingleton<QuizViewModel>();
        mauiAppBuilder.Services.AddSingleton<QuizStatisticsPage>();
        mauiAppBuilder.Services.AddSingleton<MensaPage>();
        mauiAppBuilder.Services.AddSingleton<MensaViewModel>();
        return mauiAppBuilder;
    }
}
