using System;
using System.Collections.Generic;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.Mock
{
    public class MockMealCollection : IMealCollection
    {
        public MockMealCollection()
        {
        }

        public Category Category { get; set; }
        public List<IMeal> Meals { get; set; }
    }
}

