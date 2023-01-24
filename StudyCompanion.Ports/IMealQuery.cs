using System;

namespace Italbytz.Ports.Meal
{
    public interface IMealQuery
    {
        int Mensa { get; set; }
        DateTime Date { get; set; }
    }
}