using Italbytz.Adapters.Meal.OpenMensa;
using Italbytz.Infrastructure.OpenMensa;

namespace StudyCompanion.Infra.Tests;

public class DataSourceTests
{
    OpenMensaMealDataSource source;

    [SetUp]
    public void Setup()
    {
        source = new OpenMensaMealDataSource(8, DateTime.Now);
    }

    [Test]
    public async Task TestRetrieveAll()
    {
        try
        {
            var meals = await source.RetrieveAll();
            Assert.NotNull(meals);
        }
        catch (Exception ex)
        {
            Assert.True(ex is MensaClosedException || ex is NoMealsForDateException);
        }
    }



}

