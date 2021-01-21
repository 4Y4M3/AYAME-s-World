using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CoreTweet;

namespace AYAME_s_World
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Tokens tokens = Tokens.Create(
            Properties.Settings.Default.API_KEY,
            Properties.Settings.Default.API_KEY_SECRET,
            Properties.Settings.Default.TOKEN_KEY,
            Properties.Settings.Default.TOKEN_SECRET);

        private string post = "";

        public MainWindow()
        {
            InitializeComponent();
            CountUpdate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TweetUpdate();
        }

        private void Post_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountUpdate();
        }

        private void CountUpdate()
        {
            post = Header.Text + Tweeet.Text + Footer.Text;
            Count.Text = post.Length.ToString("D3");
        }

        private void TweetUpdate()
        {
            var res = tokens.Statuses.Update(status => post);
            Tweeet.Clear();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    TweetUpdate();
                }
            }
        }
    }
}
