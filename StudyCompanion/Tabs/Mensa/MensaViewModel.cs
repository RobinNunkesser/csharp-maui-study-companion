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
        public ObservableCollection<MealSectionViewModel> Meals { get; set; }

        private MealSectionViewModel mainDishes;
        private MealSectionViewModel soups;
        private MealSectionViewModel sideDishes;
        private MealSectionViewModel desserts;

        public MensaViewModel()
        {
        }

        internal void SetMeals(List<IMealCollection> meals)
        {
            Meals = new ObservableCollection<MealSectionViewModel>();
            mainDishes = new MealSectionViewModel()
            {
                Header = AppResources.Maindishes
            };
            soups = new MealSectionViewModel()
            {
                Header = AppResources.Soups
            };
            sideDishes = new MealSectionViewModel()
            {
                Header = AppResources.Sidedishes
            };
            desserts = new MealSectionViewModel()
            {
                Header = AppResources.Desserts
            };
            Meals.Add(mainDishes);
            Meals.Add(soups);
            Meals.Add(sideDishes);
            Meals.Add(desserts);
            foreach (var mealCollection in meals)
            {
                switch (mealCollection.Category)
                {
                    case Category.Dessert:
                        foreach (var meal in mealCollection.Meals)
                        {
                            if (excludeMeal(meal)) continue;
                            desserts.Add(meal);
                        }
                        break;
                    case Category.Dish:
                        foreach (var meal in mealCollection.Meals)
                        {
                            if (excludeMeal(meal)) continue;
                            mainDishes.Add(meal);
                        }
                        break;
                    case Category.Soup:
                        foreach (var meal in mealCollection.Meals)
                        {
                            if (excludeMeal(meal)) continue;
                            soups.Add(meal);
                        }
                        break;
                    case Category.None:
                    case Category.Sidedish:
                    default:
                        foreach (var meal in mealCollection.Meals)
                        {
                            if (excludeMeal(meal)) continue;
                            sideDishes.Add(meal);
                        }
                        break;
                }
            }
            OnPropertyChanged("Meals");
        }

        bool excludeMeal(IMeal meal)
        {
            var excludeMeal = false;
            foreach (Allergens flagToCheck in Enum.GetValues(typeof(Allergens)))
            {
                if (flagToCheck != Allergens.None &&
                    meal.Allergens.HasFlag(flagToCheck) &&
                    !Settings.Allergens.HasFlag(flagToCheck))
                {
                    excludeMeal = true;
                    break;
                }
            }
            foreach (Additives flagToCheck in Enum.GetValues(typeof(Additives)))
            {
                if (flagToCheck != Additives.None &&
                    meal.Additives.HasFlag(flagToCheck) &&
                    !Settings.Additives.HasFlag(flagToCheck))
                {
                    excludeMeal = true;
                    break;
                }
            }
            return excludeMeal;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}