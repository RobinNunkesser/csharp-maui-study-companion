using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.Mock
{
    public class MockGetMealsService : IGetMealsService
    {
        public MockGetMealsService()
        {
        }

        public Task<List<IMealCollection>> Execute(IMealQuery inDTO)
        {
            var collectionsList = new List<IMealCollection>() {
                new MockMealCollection() {
                    Category = Category.Dish,
                    Meals = Mocks.Dishes
                },
                new MockMealCollection() {
                    Category = Category.Dessert,
                    Meals = Mocks.Desserts
                }};
            return Task.FromResult(collectionsList);
        }
    }
}

