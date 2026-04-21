using System;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.OpenMensa
{
    public class MockMeal : IMeal
    {
        public MockMeal()
        {
        }

        public string Name { get; set; } = "";
        public string Image { get; set; } = "";
        public Allergens Allergens { get; set; }
        public Additives Additives { get; set; }
        public Category Category { get; set; }
        public IPrice Price { get; set; } = new MockPrice();
    }
}

