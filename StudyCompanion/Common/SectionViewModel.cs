using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StudyCompanion
{
    /// <summary>
    ///     Convenience `ViewModel` for Group bindings.
    /// </summary>
    public class SectionViewModel<T> : ObservableCollection<T>
    {
        private string header = string.Empty;

        public string Header
        {
            get => header;
            set
            {
                if (header == value)
                    return;
                header = value;
                OnPropertyChanged(
                    new PropertyChangedEventArgs("Header")
                );
            }
        }

    }
}
