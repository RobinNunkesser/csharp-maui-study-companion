using System;
using Italbytz.Ports.Meal;

namespace StudyCompanion
{
    public enum WelcomeStatusType
    {
        Unfinished = 0,
        Finished = 1
    }

    public static class Settings
    {
        private static readonly int StatusDefault = 0;
        private static readonly int WelcomeStatusDefault = 0;
        private static readonly int AllergensDefault = 0b11111111111111;
        private static readonly int AdditivesDefault = 0b111111111111111;


        public static int WelcomeStatus
        {
            get => Preferences.Get(nameof(WelcomeStatus), WelcomeStatusDefault);
            set => Preferences.Set(nameof(WelcomeStatus), value);
        }
        public static int Status
        {
            get => Preferences.Get(nameof(Status), StatusDefault);
            set => Preferences.Set(nameof(Status), value);
        }

        public static Allergens Allergens
        {
            get => (Allergens)Preferences.Get(nameof(Allergens), AllergensDefault);
            set => Preferences.Set(nameof(Allergens), (int)value);
        }
        public static Additives Additives
        {
            get => (Additives)Preferences.Get(nameof(Additives), AdditivesDefault);
            set => Preferences.Set(nameof(Additives), (int)value);
        }

    }
}

