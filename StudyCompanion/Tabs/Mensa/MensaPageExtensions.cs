using System;
using StudyCompanion.Resources.Strings;

namespace StudyCompanion
{
    public static class MensaPageExtensions
    {
        public static async Task ToolbarItemClicked(this MensaPage mensaPage)
        {
            var result = await mensaPage.DisplayAlert(AppResources.Info, AppResources.MensaInfo, AppResources.Show, AppResources.Cancel);
            if (result) await Launcher.OpenAsync(new Uri("https://www.studierendenwerk-pb.de/gastronomie/speiseplaene/mensa-basilica-hamm"));
        }
    }
}

