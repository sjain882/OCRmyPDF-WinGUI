using OcrMyPdf.Gui.Theme;
using OcrMyPdf.Gui.ViewModel;
using OcrMyPdf.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OcrMyPdf.Logic.Utilities;

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
