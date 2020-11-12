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

            if ((bool)item)
            {
                return InfoTemplate;
            }
            else
            {
                return ProgressTemplate;
            }
        }
    }
}
