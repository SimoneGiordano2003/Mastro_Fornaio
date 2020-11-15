using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Mastro_Fornaio
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Content = new Home();
        }

        private void Menu_Open(object sender , RoutedEventArgs e)
        {
            Menu.IsPaneOpen = !Menu.IsPaneOpen;
        }

        private void Menu_SelectionChanged(object sender , RoutedEventArgs e)
        {
            var scelta = (ListBoxItem)((ListBox)sender).SelectedItem;

            if (scelta == Item_Home)
                MainFrame.Content = new Home();

            else if (scelta == Item_Napoletana)
                MainFrame.Content = new Pizza_Napoletana();

            else if (scelta == Item_Romana)
                MainFrame.Content = new Pizza_Romana();

            else if (scelta == Item_Pane)
                MainFrame.Content = new Pane();

            else if (scelta == Item_About)
                MainFrame.Content = new Info();
        }
    }
}