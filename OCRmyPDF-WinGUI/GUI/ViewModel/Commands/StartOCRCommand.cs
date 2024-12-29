using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OcrMyPdf.Gui.ViewModel.Commands
{
    public class StartOCRCommand : ICommand
    {

        // Reference to main ViewModel
        private MainWindowViewModel ViewModel;


        public StartOCRCommand(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public bool CanExecute(object parameter)
        {
            return (ViewModel.filePathsList.Count > 0);
        }

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Called when Start button pressed
        public void Execute(object parameter)
        {
            //ObservableCollection<OcrMyPdf.Logic.OCRError> ocrErrors = new ObservableCollection<OcrMyPdf.Logic.OCRError>();
            //ocrErrors.Add(new Logic.OCRError("D:\\PDFTest\\AlreadyHasText.pdf", new OcrMyPdf.Logic.ExitCodes.ExitCodeTemplate(5)));
            //ocrErrors.Add(new Logic.OCRError("D:\\PDFTest\\AlreadyHasText - Copy.pdf", new OcrMyPdf.Logic.ExitCodes.ExitCodeTemplate(1)));
            //Gui.View.ErrorListWindow errorListWindow = new Gui.View.ErrorListWindow(ocrErrors);
            //errorListWindow.Show();

            if (ViewModel.IsRunning)
            {
                ViewModel.CancelOCR();
                ViewModel.StartStopBtnText = "Start!";
                return;
            }

            ViewModel.ocrErrors.Clear();

            if (ViewModel.errorListWindow != null)
            {
                ViewModel.errorListWindow.Close();
            }

            ViewModel.StartStopBtnText = "Cancel";

            ViewModel.RunOCRWithProgressUpdates();
        }
    }
}
