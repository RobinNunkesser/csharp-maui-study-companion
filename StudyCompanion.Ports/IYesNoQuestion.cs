using System;

namespace StudyCompanion.Ports
{
    public interface IYesNoQuestion : IQuestion
    {
        bool Answer { get; set; }
    }
}

