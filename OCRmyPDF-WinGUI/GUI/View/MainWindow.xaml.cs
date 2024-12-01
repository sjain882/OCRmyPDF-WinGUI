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

namespace OcrMyPdf.Gui.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainWindowViewModel winHandler;

        // InitializeComponent() must be called last!
        public MainWindow()
        {
            winHandler = new MainWindowViewModel();
            DataContext = winHandler;
            InitializeComponent();
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
                    winHandler.filePathsList.Add(path);
                }
            }
        }

        private void ClearFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            winHandler.filePathsList.Clear();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            OCRRunner.RunOCR(winHandler.filePathsList.ToArray(), winHandler.ocrOptions);
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
                    if (!winHandler.filePathsList.Contains(file))
                    {
                        winHandler.filePathsList.Add(file);
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
    }
}