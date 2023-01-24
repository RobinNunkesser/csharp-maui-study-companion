using System;
using System.Collections.Generic;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.Mock
{
    public static class Mocks
    {
        public static List<IMeal> Dishes = new List<IMeal>() {
            new Meal() {
                Name = "Lorem Ipsum Dish with gluten and flavor enhancer",
                Image = "https://images.unsplash.com/photo-1546069901-ba9599a7e63c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=100&q=80",
                Price = new Price() { Students = 1.0, Employees = 2.0, Pupils = 3.0, Others = 4.0 },
                Allergens = Allergens.Gluten,
                Additives = Additives.FlavorEnhancer,
                Category = Category.Dish
            },
            new Meal() {
                Name = "Lorem Ipsum Dish with eggs and food coloring",
                Image = "https://images.unsplash.com/photo-1569718212165-3a8278d5f624?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=100&q=80",
                Price = new Price() { Students = 5.0, Employees = 6.0, Pupils = 7.0, Others = 8.0 },
                Allergens = Allergens.Eggs,
                Additives = Additives.FoodColoring,
                Category = Category.Dish
            }
        };

        public static List<IMeal> Desserts = new List<IMeal>() {
            new Meal() {
                Name = "Lorem Ipsum Dessert with eggs and flavor enhancer",
                Image = "https://images.unsplash.com/photo-1509482560494-4126f8225994?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=100&q=80",
                Price = new Price() { Students = 1.1, Employees = 2.1, Pupils = 3.1, Others = 4.1 },
                Allergens = Allergens.Eggs,
                Additives = Additives.FlavorEnhancer,
                Category = Category.Dessert
            }
        };
    }
}
