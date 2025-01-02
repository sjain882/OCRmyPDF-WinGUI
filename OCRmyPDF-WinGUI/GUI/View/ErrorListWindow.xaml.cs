using OcrMyPdf.Gui.Theme;
using OcrMyPdf.Gui.ViewModel;
using OcrMyPdf.Logic;
using OcrMyPdf.Logic.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace OcrMyPdf.Gui.View
{
    /// <summary>
    /// Interaction logic for ErrorListWindow.xaml
    /// </summary>
    public partial class ErrorListWindow : Window
    {

        public ErrorListWindowViewModel ViewModel;

        public ErrorListWindow(ObservableCollection<OCRError> ocrErrors)
        {
            ViewModel = new ErrorListWindowViewModel(ocrErrors);
            DataContext = ViewModel;

            ThemeChanger errorWinThemeChanger = new ThemeChanger(this);
            errorWinThemeChanger.ChangeTheme();

            InitializeComponent();
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CopyPathToClipboard(object sender, RoutedEventArgs e)
        {
            TextInteractions.CopyTextToClipboard(FilePathTxtBox.Text);
        }

        private void ExploreFile(object sender, RoutedEventArgs e)
        {
            FileInteractions.ExploreFile(FilePathTxtBox.Text);
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            FileInteractions.OpenFileInDefaultViewer(FilePathTxtBox.Text);
        }

        private void CopyErrorToClipboard(object sender, RoutedEventArgs e)
        {
            TextInteractions.CopyTextToClipboard(ErrorName.Content.ToString());
        }

        private void SearchError(object sender, RoutedEventArgs e)
        {
            TextInteractions.SearchOCRError(ErrorName.Content.ToString());
        }
    }
}
