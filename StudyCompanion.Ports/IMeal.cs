using System;
namespace Italbytz.Ports.Meal
{
    public interface IMeal
    {
        string Name { get; set; }
        string Image { get; set; }
        IPrice Price { get; set; }
        Allergens Allergens { get; set; }
        Additives Additives { get; set; }
        Category Category { get; set; }
    }
}
