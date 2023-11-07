using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Italbytz.Ports.Meal;
using Plugin.Calendars;
using Plugin.Calendars.Abstractions;
using StudyCompanion.Ports;

namespace StudyCompanion
{
    public class CoursesViewModel
    {
        private static readonly string shortFormat = "dd.MM.yyyy";

        public static DateTime SemesterEnd { get; } = DateTime.ParseExact("21.01.2024", shortFormat, CultureInfo.InvariantCulture);

        public static List<DateTime> Holidays { get; } = new List<DateTime>
        {
            DateTime.ParseExact("03.10.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("01.11.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("24.12.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("25.12.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("26.12.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("27.12.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("28.12.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("29.12.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("30.12.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("31.12.2023",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("01.01.2024",shortFormat, CultureInfo.InvariantCulture),
            /*DateTime.ParseExact("07.04.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("10.04.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("11.04.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("12.04.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("13.04.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("14.04.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("01.05.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("18.05.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("29.05.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("30.05.2024",shortFormat, CultureInfo.InvariantCulture),
            DateTime.ParseExact("08.06.2024",shortFormat, CultureInfo.InvariantCulture)*/
        };

        private readonly List<ICourse> courses;
        public SectionViewModel<ICourse>[]? GroupedCourses { get; set; }

        private readonly IGetCoursesService _service;

        public CoursesViewModel(IGetCoursesService service)
        {
            _service = service;
            courses = service.Execute();
            SetGroupedCourses(_service.Execute());
        }

        public void Filter(string queryString)
        {
            SetGroupedCourses(FilterCourses(queryString));
        }

        private void SetGroupedCourses(List<ICourse> courses)
        {
            SectionViewModel<ICourse>[] groups = new SectionViewModel<ICourse>[7];
            foreach (var group in courses.GroupBy(c => c.Semester))
            {
                var section = new SectionViewModel<ICourse>()
                {
                    Header = $"Semester {group.Key}"
                };
                foreach (var item in group)
                {
                    section.Add(item);
                }
                groups[group.Key - 1] = section;
            }
            GroupedCourses = groups;
        }

        private List<ICourse> FilterCourses(string queryString)
        {

            var normalizedQuery = queryString?.ToLower() ?? "";
            if (string.IsNullOrEmpty(normalizedQuery)) return courses;
            bool success = int.TryParse(normalizedQuery, out int semester);
            if (success)
            {
                return courses.Where(item => item.Semester == semester).ToList();
            }
            return courses.Where(
                item => item.Name.ToLower().Contains(normalizedQuery) ||
                item.Lecturer.ToLower().Contains(normalizedQuery)).ToList();
        }


        internal async void AddCourseToCalendar(ICourse course, Plugin.Calendars.Abstractions.Calendar selectedCalendar)
        {
            var startDate = DateTime.ParseExact(course.StartDate, course.DateFormat, System.Globalization.CultureInfo.InvariantCulture);
            var endDate = startDate.AddMinutes(course.Length);

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
                    Name = course.Name,
                    Start = startDate,
                    End = endDate,
                    Location = course.Room
                });

                startDate = startDate.AddDays(course.Biweekly ? 14 : 7);
                endDate = endDate.AddDays(course.Biweekly ? 14 : 7);
            }

        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(
            [CallerMemberName] string name = ""
        ) =>
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(name)
            );
        #endregion
    }
}

