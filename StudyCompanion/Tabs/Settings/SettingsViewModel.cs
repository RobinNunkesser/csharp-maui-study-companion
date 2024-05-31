using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace StudyCompanion;

public class SettingsViewModel : INotifyPropertyChanged
{
    public SettingsViewModel(INavigation navigation)
    {
        OnPropertyChanged();
        NavigateCommand = new Command<Type>(async pageType =>
        {
            var page = (Page?)Activator.CreateInstance(pageType);
            await navigation.PushAsync(page);
        });
    }

    public ICommand NavigateCommand { get; set; }

    public bool StatusStudent
    {
        get => Settings.Status == 0;
        set
        {
            if (value) Settings.Status = 0;
        }
    }

    public bool StatusStaff
    {
        get => Settings.Status == 1;
        set
        {
            if (value) Settings.Status = 1;
        }
    }

    public bool StatusOther
    {
        get => Settings.Status == 2;
        set
        {
            if (value) Settings.Status = 2;
        }
    }

    #region INotifyPropertyChanged implementation

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    #endregion
}