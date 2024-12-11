﻿using Microsoft.Win32;
using OcrMyPdf.Gui.View;
using OcrMyPdf.GUI.ViewModel;
using OcrMyPdf.Logic.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OcrMyPdf.GUI.Theme
{
    public class ThemeChanger
    {
        // Reference to main ViewModel
        private MainWindow MainWindow;
        bool currentAppThemeIsDark;
        public event EventHandler CanExecuteChanged;

        public ThemeChanger(MainWindow mainWindow)
        {
            // Grab reference to MainWindowViewModel
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));

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
                //{ Source = new Uri("GUI/Theme/WPFDarkTheme/ColourDictionaries/AllRed.xaml", UriKind.Relative) };

                // Contains most of the control-specific brushes which reference
                // the above theme. I aim for this to contain ALL brushes, not most
                ResourceDictionary DarkThemeControlColours = new ResourceDictionary()
                { Source = new Uri("GUI/Theme/WPFDarkTheme/ControlColours.xaml", UriKind.Relative) };

                // Contains all of the control styles(Button, ListBox, etc)
                ResourceDictionary DarkThemeControlStyles = new ResourceDictionary()
                { Source = new Uri("GUI/Theme/WPFDarkTheme/Controls.xaml", UriKind.Relative) };

                App.Current.Resources.Clear();
                MainWindow.Resources.Clear();

                App.Current.Resources.MergedDictionaries.Add(DarkThemeColourDict);
                App.Current.Resources.MergedDictionaries.Add(DarkThemeControlColours);
                App.Current.Resources.MergedDictionaries.Add(DarkThemeControlStyles);

                // Unfortunately, we can't move Theme functionality to a separate file because of this single line:
                MainWindow.Style = (Style)MainWindow.FindResource("CustomWindowStyle");

                currentAppThemeIsDark = true;

            }
            // Light theme
            else
            {
                ResourceDictionary DefaultStyle = new ResourceDictionary()
                { Source = new Uri("GUI/Theme/WPFDefault/aero2.normalcolor.xaml", UriKind.Relative) };

                MainWindow.Style = null;
                App.Current.Resources.Clear();
                MainWindow.Resources.Clear();
                App.Current.Resources.MergedDictionaries.Add(DefaultStyle);
                RefreshControls();

                currentAppThemeIsDark = false;
            }
        }


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
