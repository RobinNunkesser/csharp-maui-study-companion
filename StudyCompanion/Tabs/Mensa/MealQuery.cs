using Italbytz.Meal.Abstractions;

namespace StudyCompanion
{
    internal class MealQuery : IMealQuery
    {
        public int Mensa { get; set; }
        public DateTime Date { get; set; }
    }
}