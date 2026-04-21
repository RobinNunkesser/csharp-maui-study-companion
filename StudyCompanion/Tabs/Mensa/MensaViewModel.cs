using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Italbytz.Ports.Meal;
using StudyCompanion.Resources.Strings;

namespace StudyCompanion
{
    public class MealSectionViewModel : SectionViewModel<IMeal> { }

    public class MensaViewModel : INotifyPropertyChanged
    {
        public List<MealSectionViewModel> Meals { get; set; }

        private MealSectionViewModel _mainDishes;
        private MealSectionViewModel _soups;
        private MealSectionViewModel _sideDishes;
        private MealSectionViewModel _desserts;

        public MensaViewModel()
        {
            Meals = [];
        }

        internal void SetMeals(List<IMealCollection> meals)
        {
            var receivedMeals = new List<MealSectionViewModel>();
            _mainDishes = new MealSectionViewModel()
            {
                Header = AppResources.Maindishes
            };
            _soups = new MealSectionViewModel()
            {
                Header = AppResources.Soups
            };
            _sideDishes = new MealSectionViewModel()
            {
                Header = AppResources.Sidedishes
            };
            _desserts = new MealSectionViewModel()
            {
                Header = AppResources.Desserts
            };
            receivedMeals.Add(_mainDishes);
            receivedMeals.Add(_soups);
            receivedMeals.Add(_sideDishes);
            receivedMeals.Add(_desserts);
            foreach (var mealCollection in meals)
            {
                switch (mealCollection.Category)
                {
                    case Category.Dessert:
                        foreach (var meal in mealCollection.Meals.Where(meal => !ExcludeMeal(meal)))
                        {
                            _desserts.Add(meal);
                        }
                        break;
                    case Category.Dish:
                        foreach (var meal in mealCollection.Meals.Where(meal => !ExcludeMeal(meal)))
                        {
                            _mainDishes.Add(meal);
                        }
                        break;
                    case Category.Soup:
                        foreach (var meal in mealCollection.Meals.Where(meal => !ExcludeMeal(meal)))
                        {
                            _soups.Add(meal);
                        }
                        break;
                    case Category.None:
                    case Category.Sidedish:
                    default:
                        foreach (var meal in mealCollection.Meals.Where(meal => !ExcludeMeal(meal)))
                        {
                            _sideDishes.Add(meal);
                        }
                        break;
                }
            }

            Meals = receivedMeals;
            OnPropertyChanged(nameof(Meals));
        }

        private static bool ExcludeMeal(IMeal meal)
        {
            var excludeMeal = Enum.GetValues(typeof(Allergens)).Cast<Allergens>().Any(flagToCheck => flagToCheck != Allergens.None && meal.Allergens.HasFlag(flagToCheck) && !Settings.Allergens.HasFlag(flagToCheck)) || Enum.GetValues(typeof(Additives)).Cast<Additives>().Any(flagToCheck => flagToCheck != Additives.None &&
                meal.Additives.HasFlag(flagToCheck) &&
                !Settings.Additives.HasFlag(flagToCheck));
            return excludeMeal;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}