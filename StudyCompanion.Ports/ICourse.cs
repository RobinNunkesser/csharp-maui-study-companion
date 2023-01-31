using System;
namespace StudyCompanion.Ports
{
    public interface ICourse
    {
        string Name { get; set; }
        string Room { get; set; }
        string Lecturer { get; set; }
        string Detail { get; }
        string StartDate { get; set; }
        string DateFormat { get; set; }
        int Semester { get; set; }
        int Length { get; set; }
        bool Biweekly { get; set; }
    }
}

