using Microsoft.Extensions.Logging;

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
                break;
            case Environment.Staging:
            case Environment.Production:
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
        return mauiAppBuilder;
    }
}
