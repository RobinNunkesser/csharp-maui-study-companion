using StudyCompanion.Resources.Strings;
using Plugin.Calendars;
using StudyCompanion.Ports;
using Italbytz.Ports.Meal;

namespace StudyCompanion
{
    public partial class CoursesPage : ContentPage
    {
        private readonly CoursesViewModel _viewModel;

        public CoursesPage(CoursesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
            courses.ItemsSource = _viewModel.GroupedCourses;
        }

        private async Task DisplayIOSPermissionRequest()
        {
            await DisplayAlert(AppResources.Error, AppResources.IOSPermissions, AppResources.OK);
        }

        private async Task DisplayPermissionRationale()
        {
            await DisplayAlert(AppResources.Error, AppResources.PermissionRationale, AppResources.OK);
        }

        private async Task<PermissionStatus> CheckAndRequestCalendarReadPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.CalendarRead>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                await DisplayIOSPermissionRequest();
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.CalendarRead>())
            {
                await DisplayPermissionRationale();
            }

            status = await Permissions.RequestAsync<Permissions.CalendarRead>();

            return status;
        }

        private async Task<PermissionStatus> CheckAndRequestCalendarWritePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.CalendarWrite>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                await DisplayIOSPermissionRequest();
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.CalendarWrite>())
            {
                await DisplayPermissionRationale();
            }

            status = await Permissions.RequestAsync<Permissions.CalendarWrite>();

            return status;
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var statusRead = await CheckAndRequestCalendarReadPermission();
            var statusWrite = await CheckAndRequestCalendarWritePermission();

            if (statusRead != PermissionStatus.Granted || statusWrite != PermissionStatus.Granted)
            {
                await DisplayPermissionRationale();
                return;
            }

            var calendars = await CrossCalendars.Current.GetCalendarsAsync();
            var editableCalendars = calendars.Where((c) => c.CanEditCalendar).ToList();

            var selectedCalendar = editableCalendars.FirstOrDefault();

            if (editableCalendars.Count == 0)
            {
                await DisplayAlert(AppResources.Error, AppResources.NoCalendars, AppResources.OK);
                return;
            }
            else
            {
                var names = editableCalendars.Select((c) => c.Name).ToArray();
                string chosenCalendar = await DisplayActionSheet(AppResources.CalendarExportQuery, AppResources.Cancel, null, names);
                if (chosenCalendar.Equals(AppResources.Cancel))
                {
                    return;
                }
                foreach (var calendar in editableCalendars)
                {
                    if (calendar.Name.Equals(chosenCalendar))
                    {
                        selectedCalendar = calendar;
                        break;
                    }
                }
            }

            _viewModel.AddCourseToCalendar(e.CurrentSelection.FirstOrDefault() as ICourse, selectedCalendar);

        }

        void OnSearchTextChanged(System.Object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            _viewModel.Filter(searchBar.Text);
            courses.ItemsSource = _viewModel.GroupedCourses;
            searchBar.Focus();
        }
    }
}

