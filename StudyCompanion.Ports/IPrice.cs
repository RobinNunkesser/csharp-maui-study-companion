using System;
namespace Italbytz.Ports.Meal
{
    public interface IPrice
    {
        double? Students { get; set; }
        double? Employees { get; set; }        
        double? Pupils { get; set; }
        double? Others { get; set; }
    }
}
