using Richasy.LocaleString.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSample.Models.Enum;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Markup;

namespace TestSample.Models.UI
{
    [MarkupExtensionReturnType(ReturnType = typeof(string))]
    public sealed class LocaleStringMarkupExtension : MarkupExtension
    {
        public LocaleStringType Name { get; set; }
        public string Property { get; set; }

        protected override object ProvideValue()
        {
            if (string.IsNullOrEmpty(Property))
                return App.localeHelper.GetString(Name);
            else
                return App.localeHelper.GetString(Name, Property);
        }
    }
}
