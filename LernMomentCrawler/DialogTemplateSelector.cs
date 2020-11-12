using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace LernMomentCrawlerUI
{
    public class DialogTemplateSelector : DataTemplateSelector
    {
        public DataTemplate InfoTemplate { get; set; }
        public DataTemplate ProgressTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            // Null value can be passed by IDE designer
            if (item == null) return null;

            var configuration = item as DialogConfiguration;
            DataTemplate result = (configuration?.Type) switch
            {
                DialogType.StaticText => InfoTemplate,
                DialogType.Progress => ProgressTemplate,
                DialogType.Error => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(),
            };
            return result;
        }
    }
}
