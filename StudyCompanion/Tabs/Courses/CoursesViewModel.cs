using System;
using System.ComponentModel;
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
        private readonly List<ICourse> courses;
        public SectionViewModel<ICourse>[] GroupedCourses { get; set; }

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
            SectionViewModel<ICourse>[] groups = new SectionViewModel<ICourse>[6];
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


        internal async void AddCourseToCalendar(ICourse MockCourse, Calendar selectedCalendar)
        {
            var startDate = DateTime.ParseExact(MockCourse.StartDate, MockCourse.DateFormat, System.Globalization.CultureInfo.InvariantCulture);
            var endDate = startDate.AddMinutes(MockCourse.Length);

            await CrossCalendars.Current.AddOrUpdateEventAsync(selectedCalendar, new CalendarEvent
            {
                Name = MockCourse.Name,
                Start = startDate,
                End = endDate,
                Location = MockCourse.Room
            });

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

