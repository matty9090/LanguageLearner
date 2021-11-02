using System;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LanguageLearner
{
    public class WordChooserViewModel : ViewModelBase
    {
        public IReadOnlyList<Word> words;
        public IReadOnlyList<Word> Words {
            get => this.words;
            set => SetProperty(ref this.words, value);
        }

        public DelegateCommand SelectAllCommand { get; }
        public DelegateCommand SelectNoneCommand { get; }

        public WordChooserViewModel(IReadOnlyList<Word> words)
        {
            Words = new ObservableCollection<Word>(words);

            foreach (Word word in Words)
            {
                word.PropertyChanged += OnWordPropertyChanged;
            }

            SelectAllCommand = new DelegateCommand(param =>
            {
                foreach (Word word in Words)
                {
                    word.IsEnabled = true;
                }

                Words = Words.ToList();
                UpdateCommands();
            }, param => Words.Any(word => !word.IsEnabled));

            SelectNoneCommand = new DelegateCommand(param =>
            {
                foreach (Word word in Words)
                {
                    word.IsEnabled = false;
                }

                Words = Words.ToList();
                UpdateCommands();
            }, param => Words.Any(word => word.IsEnabled));
        }

        ~WordChooserViewModel()
        {
            foreach (Word word in Words)
            {
                word.PropertyChanged -= OnWordPropertyChanged;
            }
        }

        private void OnWordPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Word.IsEnabled))
            {
                UpdateCommands();
            }
        }

        private void UpdateCommands()
        {
            SelectAllCommand.RaiseCanExecuteChanged();
            SelectNoneCommand.RaiseCanExecuteChanged();
        }
    }
}
