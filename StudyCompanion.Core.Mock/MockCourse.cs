using System;
using StudyCompanion.Ports;

namespace StudyCompanion
{
    public class MockCourse : ICourse
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public string Lecturer { get; set; }
        public string Detail => $"{Room} ({Lecturer})";
        public string StartDate { get; set; }
        public int Semester { get; set; }
        public int Length { get; set; } = 120;
        public bool Biweekly { get; set; } = false;
    }
}

