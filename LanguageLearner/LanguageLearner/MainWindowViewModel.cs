using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearner
{
    public class MainWindowViewModel : ViewModelBase
    {
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
    }
}
