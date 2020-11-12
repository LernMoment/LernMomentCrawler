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
            DataTemplate result = null;

            // Null value can be passed by IDE designer
            if (item == null) return null;

            var configuration = item as DialogConfiguration;
            switch (configuration?.Type)
            {
                case DialogType.StaticText:
                    result = InfoTemplate;
                    break;
                case DialogType.Progress:
                    result = ProgressTemplate;
                    break;
                case DialogType.Error:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }
    }
}
