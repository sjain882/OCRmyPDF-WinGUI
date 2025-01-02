using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;

namespace OcrMyPdf.Gui.Theme
{
    public class ThemeChanger
    {
        // Reference to Window
        private Window Window;
        bool currentAppThemeIsDark;
        public event EventHandler CanExecuteChanged;


        // Constructor
        public ThemeChanger(Window window)
        {
            // Grab reference to Window
            Window = window ?? throw new ArgumentNullException(nameof(window));

            // Subscribe to OS theme change event
            SystemEvents.UserPreferenceChanged += (s, e) => { this.SystemEvents_UserPreferenceChanged(s, e); };
        }


        // Check Windows 10+ app mode (Light/Dark) and change theme accordingly
        public void ChangeTheme()
        {
            // Dark theme
            if (OSThemeDetector.DetectOSTheme())
            {
                // Contains all of the colours and brushes for a theme
                ResourceDictionary DarkThemeColourDict = new ResourceDictionary()
                { Source = new Uri("GUI/Theme/WPFDarkTheme/ColourDictionaries/DarkGreyTheme-Modified.xaml", UriKind.Relative) };

                // Contains most of the control-specific brushes which reference
                // the above theme. I aim for this to contain ALL brushes, not most
                ResourceDictionary DarkThemeControlColours = new ResourceDictionary()
                { Source = new Uri("GUI/Theme/WPFDarkTheme/ControlColours.xaml", UriKind.Relative) };

                // Contains all of the control styles(Button, ListBox, etc)
                ResourceDictionary DarkThemeControlStyles = new ResourceDictionary()
                { Source = new Uri("GUI/Theme/WPFDarkTheme/Controls.xaml", UriKind.Relative) };

                App.Current.Resources.Clear();
                Window.Resources.Clear();

                App.Current.Resources.MergedDictionaries.Add(DarkThemeColourDict);
                App.Current.Resources.MergedDictionaries.Add(DarkThemeControlColours);
                App.Current.Resources.MergedDictionaries.Add(DarkThemeControlStyles);

                Window.Style = (Style)Window.FindResource("CustomWindowStyle");

                currentAppThemeIsDark = true;

            }
            // Light theme
            else
            {
                ResourceDictionary DefaultStyle = new ResourceDictionary()
                { Source = new Uri("GUI/Theme/WPFDefault/aero2.normalcolor.xaml", UriKind.Relative) };

                Window.Style = null;
                App.Current.Resources.Clear();
                Window.Resources.Clear();

                App.Current.Resources.MergedDictionaries.Add(DefaultStyle);
                RefreshControls();

                currentAppThemeIsDark = false;
            }
        }


        // Seemingly not necessary on high performance systems
        private void RefreshControls()
        {
            if (currentAppThemeIsDark)
            {
                // This seems to be faster than reloading the whole file, and it also seems to work
                Collection<ResourceDictionary> merged = Application.Current.Resources.MergedDictionaries;
                ResourceDictionary dictionary = merged[2];
                merged.RemoveAt(2);
                merged.Insert(2, dictionary);
            }
        }


        // Fired when the user changes app mode between Light/Dark in Windows 10+ settings
        public void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            ChangeTheme();
        }
    }
}
