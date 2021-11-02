namespace LanguageLearner
{
    public class Word : ViewModelBase
    {
        public string NativeWord { get; }
        public string Translation { get; }

        public bool isEnabled = true;
        public bool IsEnabled {
            get => this.isEnabled;
            set => SetProperty(ref this.isEnabled, value);
        }

        public Word(string word, string translation)
        {
            NativeWord = word.FirstCharToUpper();
            Translation = translation;
        }
    }
}
