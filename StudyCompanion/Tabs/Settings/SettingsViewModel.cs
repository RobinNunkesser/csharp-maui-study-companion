using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace StudyCompanion
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateCommand { get; set; }

        public int Status
        {
            get => Settings.Status;
            set => Settings.Status = value;
        }

        public SettingsViewModel(INavigation navigation)
        {
            OnPropertyChanged();
            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                var page = (Page?)Activator.CreateInstance(pageType);
                await navigation.PushAsync(page);
            });
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}
