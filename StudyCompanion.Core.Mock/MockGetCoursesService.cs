using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Italbytz.Ports.Common;
using StudyCompanion.Ports;

namespace StudyCompanion.Core.Mock
{
    public class MockGetCoursesService : IGetCoursesService
    {
        private readonly List<ICourse> Courses = new List<ICourse>
            {
            new MockCourse {
                Semester = 1,
                StartDate = $"{DateTime.Now.ToString("dd.MM.yyyy")} 08:00",
                Name = "Chemie VL",
                Lecturer = "Maria Rossi",
                Room = "Hörsaal Stadtwerke Hamm",
                Length = 120,
                Biweekly = false
            },
            new MockCourse {
                Semester = 2,
                StartDate = $"{DateTime.Now.ToString("dd.MM.yyyy")} 10:00",
                Name = "Technisches Englisch I VL",
                Lecturer = "Mario Rossi",
                Room = "Hörsaal Stadtwerke Hamm",
                Length = 60,
                Biweekly = false
            },
            new MockCourse {
                Semester = 3,
                StartDate = $"{DateTime.Now.ToString("dd.MM.yyyy")} 12:00",
                Name = "Mathematik I VL",
                Lecturer = "Kari Nordmann",
                Room = "Hörsaal HAM 6",
                Length = 60,
                Biweekly = false
            },
            new MockCourse {
                Semester = 4,
                StartDate = $"{DateTime.Now.ToString("dd.MM.yyyy")} 14:00",
                Name = "Grundlagen der Programmierung VL",
                Lecturer = "Ola Nordmann",
                Room = "Hörsaal HAM 6",
                Length = 120,
                Biweekly = false
            },
            new MockCourse {
                Semester = 5,
                StartDate = $"{DateTime.Now.ToString("dd.MM.yyyy")} 16:00",
                Name = "Technische Informatik I VL",
                Lecturer = "Pinco Pallino",
                Room = "Hörsaal WESTPRESS",
                Length = 120,
                Biweekly = false
            },
            new MockCourse {
                Semester = 6,
                StartDate = $"{DateTime.Now.ToString("dd.MM.yyyy")} 18:00",
                Name = "Personal Skills I VL/ÜB",
                Lecturer = "Bianca Rossi",
                Room = "Hörsaal HAM 6",
                Length = 120,
                Biweekly = false
            }
            };

        public List<ICourse> Execute() => Courses;
    }
}

