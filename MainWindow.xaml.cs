using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private string? uri;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string uri = GetUriString(SearchStringTextBox.Text, SearchSystemTextBox.Text);
            UriString.Text = uri;
            myBrowser.Navigate(new Uri(uri));
        }

        private void SearchStringTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string uri = GetUriString(SearchStringTextBox.Text, SearchSystemTextBox.Text);
            UriString.Text = uri;
        }

        private string GetUriString(string searchString, string searchSystem)
        {
            switch (searchSystem.ToLower().Trim())
            {
                case "google.com":
                case "bing.com":
                    return $"https://www.{searchSystem.ToLower().Trim()}/search?q={searchString.Replace(" ", "+").ToLower()}";

                default:
                    // Обработка других случаев или предоставление URL по умолчанию, если необходимо
                    return $"https://www.{searchSystem.ToLower().Trim()}/search?q={searchString.Replace(" ", "+").ToLower()}";
            }
        }

        private void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (myBrowser.CanGoBack)
            {
                myBrowser.GoBack();
            }
            else
            {
                MessageBox.Show("Cannot Go back");
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (myBrowser.CanGoForward)
            {
                myBrowser.GoForward();
            }
            else
            {
                MessageBox.Show("Cannot Go Forward");
            }
        }
    }
}