using System;
using System.Collections.Generic;
using Italbytz.Adapters.Meal.OpenMensa;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.Mock
{
    public static class Mocks
    {
        private static readonly DateTime SampleDay = new DateTime(2026, 4, 22);

        // Based on real OpenMensa-style entries (single sample day),
        // with local mock images for fully offline demos.
        // Goal: cover all sections, all badges, and representative filter cases.
        public static List<IMeal> Dishes = new List<IMeal>() {
            new MockMeal() {
                Name = "Hausgemachte Pasta, Barlauchpesto",
                Image = "mock_meal_pasta",
                Price = new MockPrice() { Students = 2.0, Employees = 4.5, Pupils = null, Others = 6.4 },
                Allergens = Allergens.Milk,
                Additives = Additives.None,
                Category = Category.Dish,
                Badges = new[] { Badge.Vegetarian },
                Date = SampleDay
            },
            new MockMeal() {
                Name = "Zitronen-Hahnchen, Brokkoli, Ebly",
                Image = "mock_meal_chicken",
                Price = new MockPrice() { Students = 3.8, Employees = 6.5, Pupils = null, Others = 8.1 },
                Allergens = Allergens.Milk | Allergens.Sulfur,
                Additives = Additives.Sulphureted,
                Category = Category.Dish,
                Badges = new[] { Badge.LowCalorie },
                Date = SampleDay
            },
            new MockMeal() {
                Name = "Orientalische Bulgur-Frikadelle, veganer Kresse-Dip, Fingermohren, Salzkartoffeln",
                Image = "mock_meal_bulgur",
                Price = new MockPrice() { Students = 3.6, Employees = 6.3, Pupils = null, Others = 7.9 },
                Allergens = Allergens.Gluten,
                Additives = Additives.None,
                Category = Category.Dish,
                Badges = new[] { Badge.Vegan, Badge.Nonfat },
                Date = SampleDay
            },
            new MockMeal() {
                Name = "Lachsfilet mit Zitronenreis und Erbsen",
                Image = "mock_meal_chicken",
                Price = new MockPrice() { Students = 4.1, Employees = 6.8, Pupils = null, Others = 8.4 },
                Allergens = Allergens.Fish,
                Additives = Additives.Antioxidants,
                Category = Category.Dish,
                Badges = new[] { Badge.GlutenFree },
                Date = SampleDay
            }
        };

        public static List<IMeal> Soups = new List<IMeal>() {
            new MockMeal() {
                Name = "Tomaten-Linsensuppe",
                Image = "mock_meal_bowl",
                Price = new MockPrice() { Students = 1.7, Employees = 3.2, Pupils = null, Others = 4.6 },
                Allergens = Allergens.Celery,
                Additives = Additives.None,
                Category = Category.Soup,
                Badges = new[] { Badge.Vegan, Badge.LactoseFree },
                Date = SampleDay
            },
            new MockMeal() {
                Name = "Cremige Pilzsuppe",
                Image = "mock_meal_bowl",
                Price = new MockPrice() { Students = 2.1, Employees = 3.7, Pupils = null, Others = 5.1 },
                Allergens = Allergens.Milk,
                Additives = Additives.FlavorEnhancer,
                Category = Category.Soup,
                Badges = new[] { Badge.Vegetarian },
                Date = SampleDay
            }
        };

        public static List<IMeal> SideDishes = new List<IMeal>() {
            new MockMeal() {
                Name = "Fruhlings-Bowl mit Spargel, Cocktailtomaten, Hirtenkase, Ei, Champignons und Bulgur",
                Image = "mock_meal_bowl",
                Price = new MockPrice() { Students = 4.6, Employees = 6.9, Pupils = null, Others = 8.6 },
                Allergens = Allergens.Eggs | Allergens.Milk | Allergens.Sesame | Allergens.Sulfur,
                Additives = Additives.Sulphureted,
                Category = Category.Sidedish,
                Badges = new[] { Badge.Vegetarian },
                Date = SampleDay
            },
            new MockMeal() {
                Name = "Pommes frites mit veganer Knoblauchcreme",
                Image = "mock_meal_bulgur",
                Price = new MockPrice() { Students = 1.4, Employees = 2.6, Pupils = null, Others = 3.4 },
                Allergens = Allergens.None,
                Additives = Additives.Antioxidants,
                Category = Category.Sidedish,
                Badges = new[] { Badge.Vegan, Badge.LactoseFree },
                Date = SampleDay
            },
            new MockMeal() {
                Name = "Erdnuss-Salat mit Sesam-Dressing",
                Image = "mock_meal_bowl",
                Price = new MockPrice() { Students = 2.3, Employees = 3.9, Pupils = null, Others = 5.3 },
                Allergens = Allergens.Peanuts | Allergens.Sesame | Allergens.Soy,
                Additives = Additives.Preservatives,
                Category = Category.Sidedish,
                Badges = new[] { Badge.GlutenFree },
                Date = SampleDay
            }
        };

        public static List<IMeal> Desserts = new List<IMeal>() {
            new MockMeal() {
                Name = "Blaubeercreme",
                Image = "mock_meal_blueberry",
                Price = new MockPrice() { Students = 0.9, Employees = 1.3, Pupils = null, Others = 1.7 },
                Allergens = Allergens.None,
                Additives = Additives.None,
                Category = Category.Dessert,
                Badges = new[] { Badge.Vegan },
                Date = SampleDay
            },
            new MockMeal() {
                Name = "Schoko-Mousse Light",
                Image = "mock_meal_blueberry",
                Price = new MockPrice() { Students = 1.1, Employees = 1.6, Pupils = null, Others = 2.1 },
                Allergens = Allergens.Milk | Allergens.Eggs,
                Additives = Additives.Sweetener,
                Category = Category.Dessert,
                Badges = new[] { Badge.LowCalorie },
                Date = SampleDay
            },
            new MockMeal() {
                Name = "Eiskaffee to go",
                Image = "mock_meal_blueberry",
                Price = new MockPrice() { Students = 1.8, Employees = 2.4, Pupils = null, Others = 3.0 },
                Allergens = Allergens.Milk,
                Additives = Additives.Caffeinated | Additives.MilkProtein,
                Category = Category.Dessert,
                Badges = new[] { Badge.Nonfat },
                Date = SampleDay
            }
        };
    }
}
