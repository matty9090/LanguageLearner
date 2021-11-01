using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearner
{
    public class WordChooserViewModel
    {
        public IEnumerable<Word> Words { get; }

        public WordChooserViewModel(IReadOnlyList<Word> words)
        {
            Words = words;
        }
    }
}
