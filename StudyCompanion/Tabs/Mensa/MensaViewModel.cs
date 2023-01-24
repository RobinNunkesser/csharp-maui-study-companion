using System.Collections.ObjectModel;
using Italbytz.Ports.Meal;

namespace StudyCompanion
{
    public class MensaViewModel
    {
        public ObservableCollection<SectionViewModel<IMeal>> Meals { get; set; }

        private SectionViewModel<IMeal> mainDishes;
        private SectionViewModel<IMeal> soups;
        private SectionViewModel<IMeal> sideDishes;
        private SectionViewModel<IMeal> desserts;

        public MensaViewModel()
        {
            Meals = new ObservableCollection<SectionViewModel<IMeal>>();
            mainDishes = new SectionViewModel<IMeal>()
            {
                Header = "Essen"
            };
            soups = new SectionViewModel<IMeal>()
            {
                Header = "Suppen"
            };
            sideDishes = new SectionViewModel<IMeal>()
            {
                Header = "Beilagen"
            };
            desserts = new SectionViewModel<IMeal>()
            {
                Header = "Desserts"
            };
            Meals.Add(mainDishes);
            Meals.Add(soups);
            Meals.Add(sideDishes);
            Meals.Add(desserts);

        }

        internal void SetMeals(List<IMealCollection> meals)
        {
            mainDishes.Clear();
            soups.Clear();
            sideDishes.Clear();
            desserts.Clear();
            foreach (var mealCollection in meals)
            {
                switch (mealCollection.Category)
                {
                    case Category.Dessert:
                        foreach (var meal in mealCollection.Meals)
                        {
                            desserts.Add(meal);
                        }
                        break;
                    case Category.Dish:
                        foreach (var meal in mealCollection.Meals)
                        {
                            mainDishes.Add(meal);
                        }
                        break;
                    case Category.Soup:
                        foreach (var meal in mealCollection.Meals)
                        {
                            soups.Add(meal);
                        }
                        break;
                    case Category.None:
                    case Category.Sidedish:
                    default:
                        foreach (var meal in mealCollection.Meals)
                        {
                            sideDishes.Add(meal);
                        }
                        break;
                }
            }
        }
    }
}