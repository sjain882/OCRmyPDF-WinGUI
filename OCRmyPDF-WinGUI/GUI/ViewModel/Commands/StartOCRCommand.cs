using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OcrMyPdf.GUI.ViewModel.Commands
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
            ViewModel.pdfErrors.Clear();
            ViewModel.RunOCRWithProgressUpdates();
            // MessageBox.Show("hi");
        }
    }
}
