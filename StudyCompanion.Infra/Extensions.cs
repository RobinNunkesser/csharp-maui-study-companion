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

            var allergens = Allergens.None;
            var additives = Additives.None;

            foreach (var note in meal.Notes)
            {
                var abbreviation = note.Substring(note.Length - 4);
                abbreviation = abbreviation.TrimStart();
                switch (abbreviation)
                {
                    case "(A)": allergens |= Allergens.Gluten; break;
                    case "(A1)": allergens |= Allergens.Gluten; break;
                    case "(B)": allergens |= Allergens.Shellfish; break;
                    case "(C)": allergens |= Allergens.Eggs; break;
                    case "(D)": allergens |= Allergens.Fish; break;
                    case "(E)": allergens |= Allergens.Peanuts; break;
                    case "(F)": allergens |= Allergens.Soy; break;
                    case "(G)": allergens |= Allergens.Milk; break;
                    case "(H)": allergens |= Allergens.Nuts; break;
                    case "(I)": allergens |= Allergens.Celery; break;
                    case "(J)": allergens |= Allergens.Mustard; break;
                    case "(K)": allergens |= Allergens.Sesame; break;
                    case "(L)": allergens |= Allergens.Sulfur; break;
                    case "(M)": allergens |= Allergens.Lupine; break;
                    case "(N)": allergens |= Allergens.Mollusk; break;
                    case "(1)": additives |= Additives.FoodColoring; break;
                    case "(2)": additives |= Additives.Preservatives; break;
                    case "(3)": additives |= Additives.Antioxidants; break;
                    case "(4)": additives |= Additives.FlavorEnhancer; break;
                    case "(5)": additives |= Additives.Sulphureted; break;
                    case "(6)": additives |= Additives.Blackend; break;
                    case "(7)": additives |= Additives.Waxed; break;
                    case "(8)": additives |= Additives.Phosphate; break;
                    case "(9)": additives |= Additives.Sweetener; break;
                    case "(10)": additives |= Additives.Phenylalanine; break;
                }
            }

            return new Meal()
            {
                Name = meal.Name,
                Image = $"https:{meal.Image}",
                Price = new Price() { Employees = meal.Prices.Employees, Others = meal.Prices.Others, Pupils = meal.Prices.Pupils, Students = meal.Prices.Students },
                Allergens = allergens,
                Additives = additives,
                Category = category
            };
        }

    }
}
