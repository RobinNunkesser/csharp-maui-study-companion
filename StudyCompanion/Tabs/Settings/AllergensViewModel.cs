using Italbytz.Ports.Meal;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudyCompanion
{
    public class AllergensViewModel : INotifyPropertyChanged
    {
        public AllergensViewModel()
        {
        }

        public bool A1
        {
            get => Settings.Allergens.HasFlag(Allergens.Gluten);
            set
            {
                if (value != A1)
                {
                    Settings.Allergens |= Allergens.Gluten;
                    if (!value) Settings.Allergens ^= Allergens.Gluten;
                    OnPropertyChanged();
                }
            }
        }

        public bool A2
        {
            get => Settings.Allergens.HasFlag(Allergens.Shellfish);
            set
            {
                if (value != A2)
                {
                    Settings.Allergens |= Allergens.Shellfish;
                    if (!value) Settings.Allergens ^= Allergens.Shellfish;
                    OnPropertyChanged();
                }
            }
        }

        public bool A3
        {
            get => Settings.Allergens.HasFlag(Allergens.Eggs);
            set
            {
                if (value != A3)
                {
                    Settings.Allergens |= Allergens.Eggs;
                    if (!value) Settings.Allergens ^= Allergens.Eggs;
                    OnPropertyChanged();
                }
            }
        }

        public bool A4
        {
            get => Settings.Allergens.HasFlag(Allergens.Fish);
            set
            {
                if (value != A4)
                {
                    Settings.Allergens |= Allergens.Fish;
                    if (!value) Settings.Allergens ^= Allergens.Fish;
                    OnPropertyChanged();
                }
            }
        }

        public bool A5
        {
            get => Settings.Allergens.HasFlag(Allergens.Peanuts);
            set
            {
                if (value != A5)
                {
                    Settings.Allergens |= Allergens.Peanuts;
                    if (!value) Settings.Allergens ^= Allergens.Peanuts;
                    OnPropertyChanged();
                }
            }
        }

        public bool A6
        {
            get => Settings.Allergens.HasFlag(Allergens.Soy);
            set
            {
                if (value != A6)
                {
                    Settings.Allergens |= Allergens.Soy;
                    if (!value) Settings.Allergens ^= Allergens.Soy;
                    OnPropertyChanged();
                }
            }
        }

        public bool A7
        {
            get => Settings.Allergens.HasFlag(Allergens.Milk);
            set
            {
                if (value != A7)
                {
                    Settings.Allergens |= Allergens.Milk;
                    if (!value) Settings.Allergens ^= Allergens.Milk;
                    OnPropertyChanged();
                }
            }
        }

        public bool A8
        {
            get => Settings.Allergens.HasFlag(Allergens.Nuts);
            set
            {
                if (value != A8)
                {
                    Settings.Allergens |= Allergens.Nuts;
                    if (!value) Settings.Allergens ^= Allergens.Nuts;
                    OnPropertyChanged();
                }
            }
        }

        public bool A9
        {
            get => Settings.Allergens.HasFlag(Allergens.Celery);
            set
            {
                if (value != A9)
                {
                    Settings.Allergens |= Allergens.Celery;
                    if (!value) Settings.Allergens ^= Allergens.Celery;
                    OnPropertyChanged();
                }
            }
        }

        public bool A10
        {
            get => Settings.Allergens.HasFlag(Allergens.Mustard);
            set
            {
                if (value != A10)
                {
                    Settings.Allergens |= Allergens.Mustard;
                    if (!value) Settings.Allergens ^= Allergens.Mustard;
                    OnPropertyChanged();
                }
            }
        }

        public bool A11
        {
            get => Settings.Allergens.HasFlag(Allergens.Sesame);
            set
            {
                if (value != A11)
                {
                    Settings.Allergens |= Allergens.Sesame;
                    if (!value) Settings.Allergens ^= Allergens.Sesame;
                    OnPropertyChanged();
                }
            }
        }

        public bool A12
        {
            get => Settings.Allergens.HasFlag(Allergens.Sulfur);
            set
            {
                if (value != A12)
                {
                    Settings.Allergens |= Allergens.Sulfur;
                    if (!value) Settings.Allergens ^= Allergens.Sulfur;
                    OnPropertyChanged();
                }
            }
        }

        public bool A13
        {
            get => Settings.Allergens.HasFlag(Allergens.Lupine);
            set
            {
                if (value != A13)
                {
                    Settings.Allergens |= Allergens.Lupine;
                    if (!value) Settings.Allergens ^= Allergens.Lupine;
                    OnPropertyChanged();
                }
            }
        }

        public bool A14
        {
            get => Settings.Allergens.HasFlag(Allergens.Mollusk);
            set
            {
                if (value != A14)
                {
                    Settings.Allergens |= Allergens.Mollusk;
                    if (!value) Settings.Allergens ^= Allergens.Mollusk;
                    OnPropertyChanged();
                }
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
