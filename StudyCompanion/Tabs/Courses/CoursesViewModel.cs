using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Italbytz.Ports.Meal;
using StudyCompanion.Ports;

namespace StudyCompanion
{
    public class CoursesViewModel
    {
        public List<SectionViewModel<ICourse>> Courses { get; set; }

        private readonly IGetCoursesService _service;

        public CoursesViewModel(IGetCoursesService service)
        {
            _service = service;
            Courses = CourseDataService.GetGroupedCourses(CourseDataService.Courses);
        }

        public List<SectionViewModel<ICourse>> FilteredCourses
        {
            get
            {
                if (string.IsNullOrEmpty(searchTerm))
                    return Courses;
                return CourseDataService.GetGroupedCourses(CourseDataService.GetSearchResults(searchTerm.ToLower()));
            }
        }

        private string searchTerm = "";
        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                if (searchTerm != value)
                {
                    searchTerm = value;
                    OnPropertyChanged("FilteredCourses");
                }
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

