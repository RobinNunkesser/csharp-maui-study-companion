using System;
using Italbytz.Ports.Trivia;

namespace StudyCompanion
{
    public static class QuestionRepository
    {
        public static IQuestion[] Questions = new IQuestion[]
        {
            new YesNoQuestion() {
                Text = Resources.Strings.AppResources.question_1,
                Answer = true
            },
            new YesNoQuestion() {
                Text = Resources.Strings.AppResources.question_2,
                Answer = true
            },
            new YesNoQuestion() {
                Text = Resources.Strings.AppResources.question_3,
                Answer = false
            },
            new YesNoQuestion() {
                Text = Resources.Strings.AppResources.question_4,
                Answer = true
            },
            new YesNoQuestion() {
                Text = Resources.Strings.AppResources.question_5,
                Answer = false
            },
        };
    }
}

