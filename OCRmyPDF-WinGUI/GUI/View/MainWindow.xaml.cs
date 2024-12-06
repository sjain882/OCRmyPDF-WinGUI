using Microsoft.Win32;
using OcrMyPdf.GUI.ViewModel;
using OcrMyPdf.Logic;
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
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace OcrMyPdf.Gui.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool currentAppThemeIsDark;
        MainWindowViewModel ViewModel;
        private DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
            this.ChangeTheme();

            // InitializeComponent() must be called after the above!
            InitializeComponent();

            // Subscribe to OS theme change event
            SystemEvents.UserPreferenceChanged += (s, e) => { this.SystemEvents_UserPreferenceChanged(s, e); };

            // Create a timer with interval of 4 seconds
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 4);
        }


        private void SelectFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select PDF Files";
            fileDialog.DefaultExt = "pdf";
            fileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            fileDialog.Multiselect = true;
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;

            bool? fileDialogSuccess = fileDialog.ShowDialog();

            if (fileDialogSuccess == true)
            {

                foreach (string path in fileDialog.FileNames)
                {
                    ViewModel.filePathsList.Add(path);
                }
            }
        }


        private void ClearFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.filePathsList.Clear();
        }


        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (fileList.Items.Count > 0)
            {
                //OCRRunner.RunOCR(winHandler.filePathsList.ToArray(), winHandler.ocrOptions);
                // winHandler.RunOCR();
            }
        }


        // Drag & drop onto files box
        private void FileList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    // Prevent duplicates from being dropped
                    if (!ViewModel.filePathsList.Contains(file))
                    {
                        ViewModel.filePathsList.Add(file);
                    }
                }
            }
        }


        // As the dragged files enter the ListBox area, make sure they're PDF files
        // If not, prevent drag & drop
        private void FileList_DragOver(object sender, DragEventArgs e)
        {
            bool dropEnabled = true;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    if (System.IO.Path.GetExtension(file).ToUpperInvariant() != ".PDF")
                    {
                        dropEnabled = false;
                        PDFOnlyWarningLbl.Visibility = System.Windows.Visibility.Visible;
                        dispatcherTimer.Start();
                        break;
                    }
                }
            }
            else
            {
                dropEnabled = false;
            }

            if (!dropEnabled)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }


        // 5 second auto-dismiss for non-PDF file drag & drop warning label
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // After 1 timer interval...
            PDFOnlyWarningLbl.Visibility = System.Windows.Visibility.Collapsed;

            // Stop timer
            dispatcherTimer.IsEnabled = false;
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
                this.Resources.Clear();

                App.Current.Resources.MergedDictionaries.Add(DarkThemeColourDict);
                App.Current.Resources.MergedDictionaries.Add(DarkThemeControlColours);
                App.Current.Resources.MergedDictionaries.Add(DarkThemeControlStyles);

                // Unfortunately, we can't move Theme functionality to a separate file because of this single line:
                this.Style = (Style)FindResource("CustomWindowStyle");

                currentAppThemeIsDark = true;

            }
            // Light theme
            else
            {
                ResourceDictionary DefaultStyle = new ResourceDictionary()
                { Source = new Uri("GUI/Theme/WPFDefault/aero2.normalcolor.xaml", UriKind.Relative) };

                this.Style = null;
                App.Current.Resources.Clear();
                this.Resources.Clear();
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