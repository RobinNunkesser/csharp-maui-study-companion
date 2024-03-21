using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Italbytz.Extensions;
using Italbytz.Ports.Trivia;

namespace StudyCompanion
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private readonly IQuestion[] _questions;
        private readonly Random _random = new();

        public int AnsweredQuestions => CorrectAnswers + WrongAnswers
                                                       + SkippedQuestions;
        public int CorrectAnswers { get; private set; } = 0;
        public int WrongAnswers { get; private set; } = 0;
        public int SkippedQuestions { get; private set; } = 0;

        public string Question => _questions[index].Text;
        public ICommand AnswerCommand { get; private set; }
        public ICommand SkipCommand { get; private set; }

        private bool buttonsEnabled = true;
        public bool ButtonsEnabled
        {
            get => buttonsEnabled;
            set
            {
                if (value != buttonsEnabled)
                {
                    buttonsEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

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


        public QuizViewModel(IQuestion[] questions)
        {
            _questions = questions;
            _random.Shuffle(_questions);
            OnPropertyChanged(nameof(Question));
            AnswerCommand = new Command<bool>(EvaluateAnswer);
            SkipCommand = new Command(Skip);
        }

        void EvaluateAnswer(bool value)
        {
            if (_questions[index] is IYesNoQuestion)
            {
                if (((IYesNoQuestion)_questions[index]).Answer == value)
                {
                    CorrectAnswers++;
                    Answer = AppResources.Right;
                }
                else
                {
                    WrongAnswers++;
                    Answer = AppResources.Wrong;
                }
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
            Index = (Index + 1) % _questions.Length;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}

