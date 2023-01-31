using System;
using StudyCompanion.Ports;

namespace StudyCompanion
{
    public class MockCourse : ICourse
    {
        public string Name { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public string Lecturer { get; set; } = string.Empty;
        public string Detail => $"{Room} ({Lecturer})";
        public string StartDate { get; set; } = string.Empty;
        public int Semester { get; set; }
        public int Length { get; set; } = 120;
        public bool Biweekly { get; set; } = false;
        public string DateFormat { get; set; } = "dd.MM.yyyy HH:mm";
    }
}

