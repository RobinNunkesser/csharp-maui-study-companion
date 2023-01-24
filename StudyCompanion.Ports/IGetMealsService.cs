using System;
using System.Collections.Generic;
using Italbytz.Ports.Common;

namespace Italbytz.Ports.Meal
{
    public interface IGetMealsService : IService<IMealQuery, List<IMealCollection>>
    {
    }
}

