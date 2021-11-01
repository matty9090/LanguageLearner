using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LanguageLearner
{
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

        private readonly IReadOnlyList<Dictionary<string, string>> words;
        private readonly Random random = new Random();
        private int currentIndex = 0;

        public MainWindowViewModel()
        {
            string json = File.ReadAllText(DictionaryPath);
            var words = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            
            this.words = words.Select(word => word.Select(translation => new KeyValuePair<string, string>(translation.Key, translation.Value as string))
                .ToDictionary(k => k.Key, v => v.Value))
                .ToList();

            NewWord();
        }

        public bool CheckAnswer(string input) => input.Trim() == Answer;

        public void NewWord()
        {
            int newIndex = this.random.Next(0, this.words.Count);
            this.currentIndex = newIndex == this.currentIndex ? ((newIndex + 1) % this.words.Count) : newIndex;

            NativeWord = FirstCharToUpper(this.words[this.currentIndex][NativeLanguage]);
            Answer = this.words[this.currentIndex][LearnLanguage];
        }

        private static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input[0].ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
