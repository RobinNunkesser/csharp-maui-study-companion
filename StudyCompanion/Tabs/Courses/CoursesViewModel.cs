using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Plugin.Calendars;
using Plugin.Calendars.Abstractions;
using Calendar = Plugin.Calendars.Abstractions.Calendar;
using StudyCompanion.Ports;

namespace StudyCompanion;

public class CoursesViewModel
{
    private const string ShortFormat = "dd.MM.yyyy";

    private readonly List<ICourse> _courses;

    private readonly IGetCoursesService _service;

    public CoursesViewModel(IGetCoursesService service)
    {
        _service = service;
        _courses = service.Execute();
        SetGroupedCourses(_courses);
    }

    public static DateTime SemesterEnd { get; } =
        DateTime.ParseExact("18.01.2026", ShortFormat,
            CultureInfo.InvariantCulture);

    public static List<DateTime> Holidays { get; } = new()
    {

        DateTime.ParseExact("03.10.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("01.11.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("24.12.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("25.12.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("26.12.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("27.12.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("28.12.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("29.12.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("30.12.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("31.12.2025",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("01.01.2026",ShortFormat, CultureInfo.InvariantCulture),
        DateTime.ParseExact("02.01.2026",ShortFormat, CultureInfo.InvariantCulture),
        /*
        // Easter
        DateTime.ParseExact("18.04.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        DateTime.ParseExact("21.04.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        DateTime.ParseExact("22.04.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        DateTime.ParseExact("23.04.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        DateTime.ParseExact("24.04.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        DateTime.ParseExact("25.04.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        // Labour Day
        DateTime.ParseExact("01.05.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        // Ascension Day
        DateTime.ParseExact("29.05.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        // Pentecost
        DateTime.ParseExact("09.06.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        DateTime.ParseExact("10.06.2025", ShortFormat,
            CultureInfo.InvariantCulture),
        // Corpus Christi
        DateTime.ParseExact("19.06.2025", ShortFormat,
            CultureInfo.InvariantCulture)*/
    };

    public SectionViewModel<ICourse>[]? GroupedCourses { get; set; }

    public void Filter(string queryString)
    {
        SetGroupedCourses(FilterCourses(queryString));
    }

    private void SetGroupedCourses(List<ICourse> courses)
    {
        var groups = new SectionViewModel<ICourse>[7];
        foreach (var group in courses.GroupBy(c => c.Semester))
        {
            var section = new SectionViewModel<ICourse>
            {
                Header = $"Semester {group.Key}"
            };
            foreach (var item in group) section.Add(item);
            groups[group.Key - 1] = section;
        }

        GroupedCourses = groups;
    }

    private List<ICourse> FilterCourses(string queryString)
    {
        var normalizedQuery = queryString?.ToLower() ?? "";
        if (string.IsNullOrEmpty(normalizedQuery)) return _courses;
        var success = int.TryParse(normalizedQuery, out var semester);
        if (success)
            return _courses.Where(item => item.Semester == semester).ToList();
        return _courses.Where(
            item => item.Name.ToLower().Contains(normalizedQuery) ||
                    item.Lecturer.ToLower().Contains(normalizedQuery)).ToList();
    }


    internal async void AddCourseToCalendar(ICourse course,
        Calendar selectedCalendar)
    {
        var startDate = DateTime.ParseExact(course.StartDate, course.DateFormat,
            CultureInfo.InvariantCulture);
        var endDate = startDate.AddMinutes(course.Length);

        while (startDate < SemesterEnd)
        {
            var isHoliday =
                Holidays.Any(holiday => startDate.Date == holiday.Date);

            if (!isHoliday)
                await CrossCalendars.Current.AddOrUpdateEventAsync(
                    selectedCalendar, new CalendarEvent
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
    )
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(name)
        );
    }

    #endregion
}