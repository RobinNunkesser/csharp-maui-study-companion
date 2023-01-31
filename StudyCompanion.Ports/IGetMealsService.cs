using System;
using System.Collections.Generic;
using Italbytz.Ports.Common;

namespace Italbytz.Ports.Meal
{
    public interface IGetMealsService : IAsyncService<IMealQuery, List<IMealCollection>>
    {
    }
}

