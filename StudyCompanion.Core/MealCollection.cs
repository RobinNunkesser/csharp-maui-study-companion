using System;
using System.Collections.Generic;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal
{
    public class MealCollection : IMealCollection
    {
        public MealCollection()
        {
        }

        public Category Category { get; set; }
        public List<IMeal> Meals { get; set; } = new();
    }
}

