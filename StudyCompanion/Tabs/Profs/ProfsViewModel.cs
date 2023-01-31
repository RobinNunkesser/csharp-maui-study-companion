using System.Windows.Input;

namespace StudyCompanion
{
    internal class ProfsViewModel
    {
        private INavigation navigation;
        public ICommand ProfCommand { get; set; }

        public ProfsViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            ProfCommand = new Command<string>(async (string source) =>
            {
                await navigation.PushAsync(new InternalBrowserPage(source));
            });
        }
    }
}