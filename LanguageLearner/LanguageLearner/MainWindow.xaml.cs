using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace LanguageLearner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel => DataContext as MainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();

            ViewModel.NativeWord = "Hello";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                ViewModel.IsAnswerVisible = true;
                ViewModel.IsNativeWordVisible = false;
                e.Handled = true;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                ViewModel.IsAnswerVisible = false;
                ViewModel.IsNativeWordVisible = true;
                e.Handled = true;
            }
        }
    }
}
