using System;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.OpenMensa
{
    public static class Extensions
    {
        public static IMeal ToIMeal(this Italbytz.Infrastructure.OpenMensa.OpenMensaMeal meal)
        {
            var category = Category.Dish;
            switch (meal.Category)
            {
                case "Desserts": category = Category.Dessert; break;
                case "Beilagen": category = Category.Sidedish; break;
                default:
                    break;
            }
            return new Meal()
            {
                Name = meal.Name,
                Image = "",
                Price = new Price() { Employees = meal.Prices.Employees, Others = meal.Prices.Others, Pupils = meal.Prices.Pupils, Students = meal.Prices.Students },
                Allergens = Allergens.None,
                Additives = Additives.None,
                Category = category
            };
        }

    }
}
