using System;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.OpenMensa
{
    public class MockPrice : IPrice
    {
        public MockPrice()
        {
        }

        public double? Students { get; set; }
        public double? Employees { get; set; }
        public double? Pupils { get; set; }
        public double? Others { get; set; }
    }
}

