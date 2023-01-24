using System;

namespace Italbytz.Ports.Meal
{
    [Flags]
    public enum Additives
    {
        None = 0,
        FoodColoring = 1 << 0,
        Preservatives = 1 << 1,
        Antioxidants = 1 << 2,
        FlavorEnhancer = 1 << 3,
        Phosphate = 1 << 4,
        Sulphureted = 1 << 5,
        Waxed = 1 << 6,
        Blackend = 1 << 7,
        Sweetener = 1 << 8,
        Phenylalanine = 1 << 9,
        Taurine = 1 << 10,
        NitritePicklingSalt = 1 << 11,
        Caffeinated = 1 << 12,
        Quinine = 1 << 13,
        MilkProtein = 1 << 14
    }
}
