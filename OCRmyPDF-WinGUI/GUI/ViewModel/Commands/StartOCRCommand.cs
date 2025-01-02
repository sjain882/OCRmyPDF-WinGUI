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
            // Debug code to test error list window
            // 
            // ObservableCollection<OcrMyPdf.Logic.OCRError> ocrErrors = new ObservableCollection<OcrMyPdf.Logic.OCRError>();
            // ocrErrors.Add(new Logic.OCRError("D:\\PDFTest\\AlreadyHasText.pdf", new OcrMyPdf.Logic.ExitCodes.ExitCodeTemplate(5)));
            // ocrErrors.Add(new Logic.OCRError("D:\\PDFTest\\AlreadyHasText - Copy.pdf", new OcrMyPdf.Logic.ExitCodes.ExitCodeTemplate(1)));
            // Gui.View.ErrorListWindow errorListWindow = new Gui.View.ErrorListWindow(ocrErrors);
            // errorListWindow.Show();

            // Pressing button while conversion running = Cancel
            if (ViewModel.IsRunning)
            {
                ViewModel.CancelOCR();
                ViewModel.StartStopBtnText = "Start!";
                return;
            }

            // Before re-starting conversion, clear list of errors
            ViewModel.ocrErrors.Clear();

            // Before re-starting conversion, close error list window if open
            if (ViewModel.errorListWindow != null)
            {
                ViewModel.errorListWindow.Close();
            }

            // Now that we're starting, this button becomes a cancel button
            ViewModel.StartStopBtnText = "Cancel";

            ViewModel.RunOCRWithProgressUpdates();
        }
    }
}
