using System;

namespace Italbytz.Ports.Meal
{
    [Flags]
    public enum Allergens
    {
        None = 0,
        Gluten = 1 << 0,
        Shellfish = 1 << 1,
        Eggs = 1 << 2,
        Fish = 1 << 3,
        Peanuts = 1 << 4,
        Soy = 1 << 5,
        Milk = 1 << 6,
        Nuts = 1 << 7,
        Celery = 1 << 8,
        Mustard = 1 << 9,
        Sesame = 1 << 10,
        Sulfur = 1 << 11,
        Lupine = 1 << 12,
        Mollusk = 1 << 13
    }
}