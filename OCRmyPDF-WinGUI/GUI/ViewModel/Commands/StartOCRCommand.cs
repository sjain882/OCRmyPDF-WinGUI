using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OcrMyPdf.Gui.ViewModel.Commands
{
    public class StartOCRCommand : ICommand
    {

        // Reference to main ViewModel
        private MainWindowViewModel ViewModel;

        public event EventHandler CanExecuteChanged;

        public StartOCRCommand(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Called when Start button pressed
        public void Execute(object parameter)
        {
            //ObservableCollection<OcrMyPdf.Logic.OCRError> ocrErrors = new ObservableCollection<OcrMyPdf.Logic.OCRError>();
            //ocrErrors.Add(new Logic.OCRError("D:\\PDFTest\\AlreadyHasText.pdf", new OcrMyPdf.Logic.ExitCodes.ExitCodeTemplate(5)));
            //ocrErrors.Add(new Logic.OCRError("D:\\PDFTest\\AlreadyHasText - Copy.pdf", new OcrMyPdf.Logic.ExitCodes.ExitCodeTemplate(1)));
            //Gui.View.ErrorListWindow errorListWindow = new Gui.View.ErrorListWindow(ocrErrors);
            //errorListWindow.Show();

            if (ViewModel.errorListWindow != null)
            {
                ViewModel.errorListWindow.Close();
            }

            ViewModel.ocrErrors.Clear();

            ViewModel.RunOCRWithProgressUpdates();


            // MessageBox.Show("hi");
        }
    }
}
