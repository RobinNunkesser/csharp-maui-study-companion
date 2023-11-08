﻿using System;
using Italbytz.Ports.Trivia;
using StudyCompanion.Ports;

namespace StudyCompanion
{
    public class YesNoQuestion : IYesNoQuestion
    {
        public bool Answer { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}

