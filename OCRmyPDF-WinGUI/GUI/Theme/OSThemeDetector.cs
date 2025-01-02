using Microsoft.Win32;

namespace OcrMyPdf.Gui.Theme
{
    public static class OSThemeDetector
    {
        public static bool DetectOSTheme()
        {
            // Default: Light theme
            int appsUseLightTheme = 1;
            bool isDarkThemeEnabled = false;

            // Get the registry value. It won't exist on Windows < 10, so automatically return false.
            try
            {
                appsUseLightTheme = (int)Registry.GetValue(
                                         "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize",
                                         "AppsUseLightTheme",
                                         -1);
            }
            catch
            {
                return false;
            }

            // If dark theme enabled...
            if (appsUseLightTheme == 0) isDarkThemeEnabled = true;

            return isDarkThemeEnabled;
        }
    }
}
