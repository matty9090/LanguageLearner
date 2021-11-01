using System;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LanguageLearner
{
    public class Word
    {
        public string NativeWord { get; }
        public string Translation { get; }
        public bool IsEnabled { get; set; } = true;

        public Word(string word, string translation)
        {
            NativeWord = word.FirstCharToUpper();
            Translation = translation;
        }
    }

    public class MainWindowViewModel : ViewModelBase
    {
        private static readonly string DictionaryPath = "Words.json";

        public string NativeLanguage => "English";
        public string LearnLanguage => "Korean";

        private string nativeWord = "Hello";
        public string NativeWord {
            get => this.nativeWord;
            set => SetProperty(ref this.nativeWord, value);
        }

        private string answer = "안녕하세요";
        public string Answer {
            get => this.answer;
            set => SetProperty(ref this.answer, value);
        }

        private bool isNativeWordVisible = true;
        public bool IsNativeWordVisible {
            get => this.isNativeWordVisible;
            set => SetProperty(ref this.isNativeWordVisible, value);
        }

        private bool isAnswerVisible = false;
        public bool IsAnswerVisible {
            get => this.isAnswerVisible;
            set => SetProperty(ref this.isAnswerVisible, value);
        }

        public ICommand OpenWordChooserCommand { get; }

        private readonly IReadOnlyList<Word> words;
        private IReadOnlyList<Word> enabledWords => this.words.Where(word => word.IsEnabled).ToList();

        private readonly Random random = new Random();
        private int currentIndex = 0;

        public MainWindowViewModel()
        {
            string json = File.ReadAllText(DictionaryPath);
            var words = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

            this.words = words.Select(word => new Word(word[NativeLanguage] as string, word[LearnLanguage] as string)).ToList();

            OpenWordChooserCommand = new DelegateCommand(param => OpenWordChooser());

            NewWord();
        }

        public bool CheckAnswer(string input) => input.Trim() == Answer;

        public void NewWord()
        {
            if (this.enabledWords.Count > 0)
            {
                int newIndex = this.random.Next(0, this.enabledWords.Count);
                this.currentIndex = newIndex == this.currentIndex ? ((newIndex + 1) % this.enabledWords.Count) : newIndex;

                NativeWord = this.enabledWords[this.currentIndex].NativeWord;
                Answer = this.enabledWords[this.currentIndex].Translation;
            }
        }

        private void OpenWordChooser()
        {
            WordChooser chooser = new WordChooser
            {
                DataContext = new WordChooserViewModel(this.words)
            };

            chooser.ShowDialog();
            NewWord();
        }
    }
}
