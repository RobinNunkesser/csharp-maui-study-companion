using System;
using Plugin.Calendars.Abstractions;

namespace Plugin.Calendars
{
    public partial class CalendarsImplementation : ICalendars
    {
        public partial Task AddEventReminderAsync(CalendarEvent calendarEvent, CalendarEventReminder reminder);
        public partial Task AddOrUpdateCalendarAsync(Calendar calendar);
        public partial Task AddOrUpdateEventAsync(Calendar calendar, CalendarEvent calendarEvent);
        public partial Task<bool> DeleteCalendarAsync(Calendar calendar);
        public partial Task<bool> DeleteEventAsync(Calendar calendar, CalendarEvent calendarEvent);
        public partial Task<Calendar> GetCalendarByIdAsync(string externalId);
        public partial Task<IList<Calendar>> GetCalendarsAsync();
        public partial Task<CalendarEvent> GetEventByIdAsync(string externalId);
        public partial Task<IList<CalendarEvent>> GetEventsAsync(Calendar calendar, DateTime start, DateTime end);
    }
}

