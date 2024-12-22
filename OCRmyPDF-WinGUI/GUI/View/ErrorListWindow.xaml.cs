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

        private void CopyPathToClipboard(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(FilePathTxtBox.Text);
        }



    }
}
