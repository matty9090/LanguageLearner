using System.Windows;

namespace LanguageLearner
{
    /// <summary>
    /// Interaction logic for WordChooser.xaml
    /// </summary>
    public partial class WordChooser : Window
    {
        public WordChooserViewModel ViewModel => DataContext as WordChooserViewModel;

        public WordChooser()
        {
            InitializeComponent();
        }
    }
}
