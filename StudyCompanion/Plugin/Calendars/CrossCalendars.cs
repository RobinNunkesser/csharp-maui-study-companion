using System;
using Plugin.Calendars.Abstractions;

namespace Plugin.Calendars
{
    public static class CrossCalendars
    {
        public static ICalendars Current { get; } = new CalendarsImplementation();
    }
}

