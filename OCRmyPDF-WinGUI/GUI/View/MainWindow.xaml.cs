using Microsoft.Win32;
using OcrMyPdf.GUI.ViewModel;
using OcrMyPdf.Logic.Utilities;
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
using OcrMyPdf.GUI.Theme;

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
            MainWindowThemeChanger themeChanger = new MainWindowThemeChanger(this);
            themeChanger.ChangeTheme();

            // InitializeComponent() must be called after the above!
            InitializeComponent();

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
    }
}