using System;

namespace Italbytz.Ports.Trivia
{
    public interface IYesNoQuestion : IQuestion
    {
        bool Answer { get; set; }
    }
}

