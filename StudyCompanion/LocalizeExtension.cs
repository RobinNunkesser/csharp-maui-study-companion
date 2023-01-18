using System;
using Microsoft.Extensions.Localization;
using StudyCompanion.Resources.Strings;

namespace StudyCompanion
{
    [ContentProperty(nameof(Key))]
    public class LocalizeExtension : IMarkupExtension
    {
        readonly IStringLocalizer<AppResources> _localizer;

        public string Key { get; set; } = string.Empty;

        public LocalizeExtension()
        {
            _localizer = ServiceHelper.GetService<
                IStringLocalizer<AppResources>
            >();
        }

        public object ProvideValue(
            IServiceProvider serviceProvider
        ) => _localizer[Key];

        object IMarkupExtension.ProvideValue(
            IServiceProvider serviceProvider
        ) => ProvideValue(serviceProvider);
    }
}

