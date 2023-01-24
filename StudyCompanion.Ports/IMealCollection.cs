using System.Collections.Generic;

namespace Italbytz.Ports.Meal
{
    public interface IMealCollection
    {
        Category Category { get; set; }
        List<IMeal> Meals { get; set; }
    }
}