using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Mastro_Fornaio
{
    /// <summary>
    /// Intestazioni comuni a tutte le pagine
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
        }

        private void Napoletana_Click(object sender , RoutedEventArgs e)
        {
            MainFrame.Content = new Pizza_Napoletana();
        }

        private void Romana_Click(object sender , RoutedEventArgs e)
        {
            MainFrame.Content = new Pizza_Romana();
        }

        private void Pane_Click(object sender , RoutedEventArgs e)
        {
            MainFrame.Content = new Pane();
        }
    }
}