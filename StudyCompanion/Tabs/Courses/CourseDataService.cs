using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Plugin.Calendars;
using Plugin.Calendars.Abstractions;
using Calendar = Plugin.Calendars.Abstractions.Calendar;

namespace StudyCompanion
{
    public static class CourseDataService
    {
        private static readonly string shortFormat = "dd.MM.yyyy";
        public static readonly string longFormat = "dd.MM.yyyy HH:mm";

        public static DateTime SemesterEnd { get; } = DateTime.ParseExact("15.01.2023", shortFormat, CultureInfo.InvariantCulture);

        public static List<DateTime> Holidays { get; } = new List<DateTime>
        {
            DateTime.ParseExact("03.10.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("01.11.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("24.12.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("25.12.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("26.12.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("27.12.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("28.12.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("29.12.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("30.12.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("31.12.2022",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("01.01.2023",shortFormat, CultureInfo.InvariantCulture)
        };

        public static List<CourseViewModel> Courses { get; } = new List<CourseViewModel>
            {
            new CourseViewModel {
                Semester = 1,
                StartDate = "19.09.2022 08:00",
                Name = "Chemie VL",
                Lecturer = "Berndt",
                Room = "Hörsaal Stadtwerke Hamm",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "19.09.2022 10:00",
                Name = "Technisches Englisch I VL",
                Lecturer = "Strack",
                Room = "Hörsaal Stadtwerke Hamm",
                Length = 60,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "19.09.2022 12:00",
                Name = "Mathematik I VL",
                Lecturer = "Ponick",
                Room = "Hörsaal HAM 6",
                Length = 60,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "19.09.2022 13:00",
                Name = "Grundlagen der Programmierung VL",
                Lecturer = "Stuckenholz",
                Room = "Hörsaal HAM 6",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "20.09.2022 08:00",
                Name = "Technische Informatik I VL",
                Lecturer = "Krenz-Baath",
                Room = "Hörsaal WESTPRESS",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "20.09.2022 10:00",
                Name = "Mathematik I VL",
                Lecturer = "Ponick",
                Room = "Hörsaal WESTPRESS",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "20.09.2022 14:00",
                Name = "Technische Informatik I ÜB - Gruppe A",
                Lecturer = "Krenz-Baath",
                Room = "PC-Pool H4.2-E00-140, Labor H3.3-E01-220",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "21.09.2022 13:00",
                Name = "Technische Informatik I ÜB - Gruppe B",
                Lecturer = "Krenz-Baath",
                Room = "PC-Pool H4.2-E00-140, Labor H3.3-E01-220",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "22.09.2022 08:00",
                Name = "Personal Skills I VL/ÜB",
                Lecturer = "Grewe",
                Room = "Hörsaal HAM 6",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "22.09.2022 10:00",
                Name = "Mathematik I ÜB",
                Lecturer = "Ponick",
                Room = "Seminarraum H1.2-E01-010",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "22.09.2022 14:00",
                Name = "Technisches Englisch I ÜB",
                Lecturer = "Strack",
                Room = "Seminarraum H1.2-E01-010",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "22.09.2022 16:00",
                Name = "Physik ÜB - Gruppe A",
                Lecturer = "Kientopf",
                Room = "Seminarraum H7.2-E00-002",
                Length = 60,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "21.09.2022 11:00",
                Name = "Physik ÜB - Gruppe B",
                Lecturer = "Kientopf",
                Room = "Hörsaal HAM 6",
                Length = 60,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "23.09.2022 08:00",
                Name = "Physik VL",
                Lecturer = "Kientopf",
                Room = "Seminarraum H4.2-E00-110",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "23.09.2022 10:00",
                Name = "Biologie VL",
                Lecturer = "Tickenbrock",
                Room = "Seminarraum H4.2-E00-110",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "23.09.2022 14:00",
                Name = "Grundlagen der Programmierung ÜB - Gruppe A",
                Lecturer = "Stuckenholz",
                Room = "PC-Pool H4.2-E00-140",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 1,
                StartDate = "21.09.2022 09:00",
                Name = "Grundlagen der Programmierung ÜB - Gruppe B",
                Lecturer = "Stuckenholz",
                Room = "PC-Pool H4.2-E00-140",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "19.09.2022 08:00",
                Name = "Digitaltechnik I VL",
                Lecturer = "Krenz-Baath",
                Room = "Seminarraum H1.1-E01-150",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "19.09.2022 10:00",
                Name = "Embedded Systems I VL",
                Lecturer = "Pelzl",
                Room = "Seminarraum H1.1-E01-150",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "19.09.2022 12:00",
                Name = "Technisches Englisch III VL",
                Lecturer = "Strack",
                Room = "Seminarraum H1.1-E01-150",
                Length = 60,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "19.09.2022 13:00",
                Name = "System Modellierung II VL",
                Lecturer = "Runovska",
                Room = "PC-Pool H4.2-E00-140",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "20.09.2022 08:00",
                Name = "Mathematik III VL",
                Lecturer = "Ponick",
                Room = "Hörsaal HAM 4",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "20.09.2022 10:00",
                Name = "Personal Skills III VL",
                Lecturer = "Zips",
                Room = "Hörsaal HAM 4",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "20.09.2022 14:00",
                Name = "Embedded Systems I ÜB",
                Lecturer = "Pelzl",
                Room = "Labor H3.3-E01-160",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "20.09.2022 16:00",
                Name = "Digitaltechnik I ÜB",
                Lecturer = "Krenz-Baath",
                Room = "Labor H3.3-E01-160",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "21.09.2022 10:30",
                Name = "Betriebssysteme VL",
                Lecturer = "Nunkesser",
                Room = "Hörsaal HAM 5",
                Length = 90,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "21.09.2022 13:00",
                Name = "Netzwerke VL",
                Lecturer = "Nunkesser",
                Room = "Hörsaal HAM 5",
                Length = 90,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "22.09.2022 10:00",
                Name = "Technisches Englisch III ÜB",
                Lecturer = "Strack",
                Room = "Seminarraum H7.2-E00-002",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "22.09.2022 12:00",
                Name = "Mathematik III ÜB",
                Lecturer = "Ponick",
                Room = "Seminarraum H7.2-E00-002",
                Length = 60,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "23.09.2022 09:00",
                Name = "Praktische Informatik VL",
                Lecturer = "Stuckenholz",
                Room = "Seminarraum H1.1-E01-150",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "23.09.2022 11:00",
                Name = "Praktische Informatik ÜB",
                Lecturer = "Stuckenholz",
                Room = "PC-Pool H3.3-E00-010",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 3,
                StartDate = "23.09.2022 13:00",
                Name = "Personal Skills III ÜB",
                Lecturer = "Zips",
                Room = "Seminarraum H1.1-E01-150",
                Length = 60,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "19.09.2022 08:30",
                Name = "Advanced App Development VL",
                Lecturer = "Nunkesser",
                Room = "Seminarraum H4.3-E00-110",
                Length = 90,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "19.09.2022 10:00",
                Name = "Advanced App Development ÜB",
                Lecturer = "Nunkesser",
                Room = "Labor H3.3-E01-220",
                Length = 60,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "19.09.2022 11:00",
                Name = "System Verifikation und System Validierung ÜB",
                Lecturer = "Krenz-Baath",
                Room = "PC-Pool H3.3-E00-010",
                Length = 120,
                Biweekly = true
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "26.09.2022 11:00",
                Name = "Embedded Programming ÜB",
                Lecturer = "Krenz-Baath",
                Room = "Seminarraum H4.3- E00-100",
                Length = 120,
                Biweekly = true
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "19.09.2022 13:00",
                Name = "Safety und Security Projektkurs VL",
                Lecturer = "Pelzl",
                Room = "Seminarraum H1.1-E01-140",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "19.09.2022 17:00",
                Name = "Embedded Programming VL",
                Lecturer = "Krenz-Baath",
                Room = "Seminarraum H4.3-E00-110",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "20.09.2022 08:30",
                Name = "Cross-Platform Development VL",
                Lecturer = "Nunkesser",
                Room = "Seminarraum H1.1-E01-170",
                Length = 90,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "20.09.2022 10:00",
                Name = "Cross-Platform Development ÜB",
                Lecturer = "Nunkesser",
                Room = "PC-Pool H4.2-E00-140",
                Length = 90,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "20.09.2022 12:00",
                Name = "System Verifikation und System Validierung VL",
                Lecturer = "Krenz-Baath",
                Room = "Seminarraum H1.1-E01-150",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "22.09.2022 08:30",
                Name = "IT-Consulting VL",
                Lecturer = "Nunkesser",
                Room = "Seminarraum H4.2-E00-110",
                Length = 90,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "22.09.2022 10:00",
                Name = "Intelligent Systems in Theory and Practice VL",
                Lecturer = "Nunkesser",
                Room = "Seminarraum H4.2-E00-110",
                Length = 90,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "22.09.2022 13:00",
                Name = "Web-Backends VL",
                Lecturer = "Stuckenholz",
                Room = "Seminarraum H1.1-E01-130",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "23.09.2022 09:00",
                Name = "Safety und Security Analysis VL",
                Lecturer = "Pelzl",
                Room = "Seminarraum H1.2-E01-010",
                Length = 120,
                Biweekly = false
            },
            new CourseViewModel {
                Semester = 7,
                StartDate = "23.09.2022 11:00",
                Name = "Safety und Security Analysis ÜB",
                Lecturer = "Pelzl",
                Room = "Labor H3.3-E01-160",
                Length = 120,
                Biweekly = false
            }
            };

        public static List<CourseViewModel> GetSearchResults(string queryString)
        {

            var normalizedQuery = queryString?.ToLower() ?? "";
            if (string.IsNullOrEmpty(normalizedQuery)) return Courses;
            bool success = int.TryParse(normalizedQuery, out int semester);
            if (success)
            {
                return Courses.Where(item => item.Semester == semester).ToList();
            }
            return Courses.Where(
                item => item.Name.ToLower().Contains(normalizedQuery) ||
                item.Lecturer.ToLower().Contains(normalizedQuery)).ToList();
        }

        public static List<SectionViewModel<CourseViewModel>> GetGroupedCourses(List<CourseViewModel> courses)
        {
            List<SectionViewModel<CourseViewModel>> groups = new();
            foreach (var group in courses.GroupBy(c => c.Semester))
            {
                var section = new SectionViewModel<CourseViewModel>()
                {
                    Header = $"Semester {group.Key}"
                };
                foreach (var item in group)
                {
                    section.Add(item);
                }
                groups.Add(section);
            }
            return groups;
        }

        internal static async void AddCourseToCalendar(CourseViewModel courseViewModel, Calendar selectedCalendar)
        {
            var startDate = DateTime.ParseExact(courseViewModel.StartDate, longFormat, CultureInfo.InvariantCulture);
            var endDate = startDate.AddMinutes(courseViewModel.Length);

            while (startDate < SemesterEnd)
            {
                var isHoliday = false;
                foreach (var holiday in Holidays)
                {
                    if (startDate.Date == holiday.Date)
                    {
                        isHoliday = true;
                        break;
                    }
                }

                if (!isHoliday) await CrossCalendars.Current.AddOrUpdateEventAsync(selectedCalendar, new CalendarEvent
                {
                    Name = courseViewModel.Name,
                    Start = startDate,
                    End = endDate,
                    Location = courseViewModel.Room
                });

                startDate = startDate.AddDays(courseViewModel.Biweekly ? 14 : 7);
                endDate = endDate.AddDays(courseViewModel.Biweekly ? 14 : 7);
            }

        }
    }
}

