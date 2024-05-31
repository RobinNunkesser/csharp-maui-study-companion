using Italbytz.Adapters.Meal.Mock;
using Italbytz.Ports.Meal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Italbytz.Adapters.Meal.OpenMensa;
using StudyCompanion.Core.Mock;
using StudyCompanion.Ports;
using Italbytz.Ports.Trivia;

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
        env = Environment.Development;
#endif
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().RegisterServices();

        switch (env)
        {
            case Environment.Development:
                builder.Logging.AddDebug();
                builder.Services.AddSingleton<IGetMealsService, MockGetMealsService>();
                builder.Services.AddSingleton<IGetCoursesService, MockGetCoursesService>();
                break;
            case Environment.Staging:
            case Environment.Production:
                builder.Services.AddSingleton<IGetMealsService>(new OpenMensaGetMealsService(new OpenMensaMealDataSource(35, DateTime.Now)));
                builder.Services.AddSingleton<IGetCoursesService, MockGetCoursesService>();
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
        mauiAppBuilder.Services.AddTransient<QuizPage>();
        mauiAppBuilder.Services.AddSingleton(new QuizViewModel(QuestionRepository.Questions));
        mauiAppBuilder.Services.AddTransient<QuizStatisticsPage>();
        mauiAppBuilder.Services.AddSingleton<MensaPage>();
        mauiAppBuilder.Services.AddSingleton<MensaViewModel>();
        mauiAppBuilder.Services.AddSingleton<CoursesPage>();
        mauiAppBuilder.Services.AddSingleton<CoursesViewModel>();
        return mauiAppBuilder;
    }
}
