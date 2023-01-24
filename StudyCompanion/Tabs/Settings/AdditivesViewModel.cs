using Italbytz.Ports.Meal;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudyCompanion
{
    public class AdditivesViewModel : INotifyPropertyChanged
    {
        public AdditivesViewModel()
        {
        }

        public bool A1
        {
            get => Settings.Additives.HasFlag(Additives.FoodColoring);
            set
            {
                if (value != A1)
                {
                    Settings.Additives |= Additives.FoodColoring;
                    if (!value) Settings.Additives ^= Additives.FoodColoring;
                    OnPropertyChanged();
                }
            }
        }

        public bool A2
        {
            get => Settings.Additives.HasFlag(Additives.Preservatives);
            set
            {
                if (value != A2)
                {
                    Settings.Additives |= Additives.Preservatives;
                    if (!value) Settings.Additives ^= Additives.Preservatives;
                    OnPropertyChanged();
                }
            }
        }

        public bool A3
        {
            get => Settings.Additives.HasFlag(Additives.Antioxidants);
            set
            {
                if (value != A3)
                {
                    Settings.Additives |= Additives.Antioxidants;
                    if (!value) Settings.Additives ^= Additives.Antioxidants;
                    OnPropertyChanged();
                }
            }
        }

        public bool A4
        {
            get => Settings.Additives.HasFlag(Additives.FlavorEnhancer);
            set
            {
                if (value != A4)
                {
                    Settings.Additives |= Additives.FlavorEnhancer;
                    if (!value) Settings.Additives ^= Additives.FlavorEnhancer;
                    OnPropertyChanged();
                }
            }
        }

        public bool A5
        {
            get => Settings.Additives.HasFlag(Additives.Phosphate);
            set
            {
                if (value != A5)
                {
                    Settings.Additives |= Additives.Phosphate;
                    if (!value) Settings.Additives ^= Additives.Phosphate;
                    OnPropertyChanged();
                }
            }
        }

        public bool A6
        {
            get => Settings.Additives.HasFlag(Additives.Sulphureted);
            set
            {
                if (value != A6)
                {
                    Settings.Additives |= Additives.Sulphureted;
                    if (!value) Settings.Additives ^= Additives.Sulphureted;
                    OnPropertyChanged();
                }
            }
        }

        public bool A7
        {
            get => Settings.Additives.HasFlag(Additives.Waxed);
            set
            {
                if (value != A7)
                {
                    Settings.Additives |= Additives.Waxed;
                    if (!value) Settings.Additives ^= Additives.Waxed;
                    OnPropertyChanged();
                }
            }
        }

        public bool A8
        {
            get => Settings.Additives.HasFlag(Additives.Blackend);
            set
            {
                if (value != A8)
                {
                    Settings.Additives |= Additives.Blackend;
                    if (!value) Settings.Additives ^= Additives.Blackend;
                    OnPropertyChanged();
                }
            }
        }

        public bool A9
        {
            get => Settings.Additives.HasFlag(Additives.Sweetener);
            set
            {
                if (value != A9)
                {
                    Settings.Additives |= Additives.Sweetener;
                    if (!value) Settings.Additives ^= Additives.Sweetener;
                    OnPropertyChanged();
                }
            }
        }

        public bool A10
        {
            get => Settings.Additives.HasFlag(Additives.Phenylalanine);
            set
            {
                if (value != A10)
                {
                    Settings.Additives |= Additives.Phenylalanine;
                    if (!value) Settings.Additives ^= Additives.Phenylalanine;
                    OnPropertyChanged();
                }
            }
        }

        public bool A11
        {
            get => Settings.Additives.HasFlag(Additives.Taurine);
            set
            {
                if (value != A11)
                {
                    Settings.Additives |= Additives.Taurine;
                    if (!value) Settings.Additives ^= Additives.Taurine;
                    OnPropertyChanged();
                }
            }
        }

        public bool A12
        {
            get => Settings.Additives.HasFlag(Additives.NitritePicklingSalt);
            set
            {
                if (value != A12)
                {
                    Settings.Additives |= Additives.NitritePicklingSalt;
                    if (!value) Settings.Additives ^= Additives.NitritePicklingSalt;
                    OnPropertyChanged();
                }
            }
        }

        public bool A13
        {
            get => Settings.Additives.HasFlag(Additives.Caffeinated);
            set
            {
                if (value != A13)
                {
                    Settings.Additives |= Additives.Caffeinated;
                    if (!value) Settings.Additives ^= Additives.Caffeinated;
                    OnPropertyChanged();
                }
            }
        }

        public bool A14
        {
            get => Settings.Additives.HasFlag(Additives.Quinine);
            set
            {
                if (value != A14)
                {
                    Settings.Additives |= Additives.Quinine;
                    if (!value) Settings.Additives ^= Additives.Quinine;
                    OnPropertyChanged();
                }
            }
        }

        public bool A15
        {
            get => Settings.Additives.HasFlag(Additives.MilkProtein);
            set
            {
                if (value != A15)
                {
                    Settings.Additives |= Additives.MilkProtein;
                    if (!value) Settings.Additives ^= Additives.MilkProtein;
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
