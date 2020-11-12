using System;
using System.Collections.Generic;
using System.Text;

namespace LernMomentCrawlerUI
{
    public enum DialogType
    {
        StaticText,
        Progress,
        Error
    }

    public class DialogConfiguration
    {
        public DialogType Type { get; private set; }
        public string Message { get; private set; }

        public DialogConfiguration(DialogType type, string message="")
        {
            this.Type = type;
            this.Message = message;
        }
    }
}
