using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace StudyCompanion
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private readonly List<YesNoQuestion> questions = new List<YesNoQuestion>
        {
            new YesNoQuestion() {
                Text = "Das Videospiel Donkey Kong sollte ursprünglich Popeye als Hauptfigur haben.",
                Answer = true
            },
            new YesNoQuestion() {
                Text = "Die Farbe Orange wurde nach der Frucht benannt.",
                Answer = true
            },
            new YesNoQuestion() {
                Text = "In der griechischen Mythologie ist Hera die Göttin der Ernte.",
                Answer = false
            },
            new YesNoQuestion() {
                Text = "Liechtenstein hat keinen eigenen Flughafen.",
                Answer = true
            },
            new YesNoQuestion() {
                Text = "Die meisten Subarus werden in China hergestellt.",
                Answer = false
            },
        };

        public int AnsweredQuestions => CorrectAnswers + WrongAnswers
                                                       + SkippedQuestions;
        public int CorrectAnswers { get; private set; } = 0;
        public int WrongAnswers { get; private set; } = 0;
        public int SkippedQuestions { get; private set; } = 0;

        public string Question => questions[index].Text;
        public ICommand AnswerCommand { get; private set; }
        public ICommand SkipCommand { get; private set; }

        private string answer = string.Empty;
        public string Answer
        {
            get => answer;
            private set
            {
                if (value != answer)
                {
                    answer = value;
                    OnPropertyChanged();
                }
            }
        }

        private int index;
        public int Index
        {
            get => index;
            set
            {
                if (value != index)
                {
                    index = value;
                    OnPropertyChanged(nameof(Question));
                }
            }
        }


        public QuizViewModel()
        {
            Index = 0;
            AnswerCommand = new Command<bool>(EvaluateAnswer);
            SkipCommand = new Command(Skip);
        }

        void EvaluateAnswer(bool value)
        {
            if (questions[index].Answer == value)
            {
                CorrectAnswers++;
                Answer = "Richtig!";
            }
            else
            {
                WrongAnswers++;
                Answer = "Falsch!";
            }
            IncreaseIndex();
        }

        void Skip()
        {
            SkippedQuestions++;
            IncreaseIndex();
        }

        void IncreaseIndex()
        {
            Index = (Index + 1) % questions.Count;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}

