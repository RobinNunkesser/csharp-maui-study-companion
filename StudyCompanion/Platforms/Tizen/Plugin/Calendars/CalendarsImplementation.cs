using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Plugin.Calendars
{
    public partial class CalendarsImplementation : ICalendars
    {
        public partial Task AddEventReminderAsync(CalendarEvent calendarEvent, CalendarEventReminder reminder) { throw new NotImplementedException(); }
        public partial Task AddOrUpdateCalendarAsync(Calendar calendar) { throw new NotImplementedException(); }
        public partial Task AddOrUpdateEventAsync(Calendar calendar, CalendarEvent calendarEvent) { throw new NotImplementedException(); }
        public partial Task<bool> DeleteCalendarAsync(Calendar calendar) { throw new NotImplementedException(); }
        public partial Task<bool> DeleteEventAsync(Calendar calendar, CalendarEvent calendarEvent) { throw new NotImplementedException(); }
        public partial Task<Calendar> GetCalendarByIdAsync(string externalId) { throw new NotImplementedException(); }
        public partial Task<IList<Calendar>> GetCalendarsAsync() { throw new NotImplementedException(); }
        public partial Task<CalendarEvent> GetEventByIdAsync(string externalId) { throw new NotImplementedException(); }
        public partial Task<IList<CalendarEvent>> GetEventsAsync(Calendar calendar, DateTime start, DateTime end) { throw new NotImplementedException(); }
    }
}

