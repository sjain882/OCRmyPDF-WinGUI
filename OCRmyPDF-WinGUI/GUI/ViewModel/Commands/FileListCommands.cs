using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OcrMyPdf.Gui.ViewModel.Commands
{
    public class RemoveFileCommand : ICommand
    {

        // Reference to main ViewModel
        private MainWindowViewModel ViewModel;

        public event EventHandler CanExecuteChanged;

        public RemoveFileCommand(MainWindowViewModel viewModel)
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
            ViewModel.filePathsList.Remove(ViewModel.FilePathsList_Selected);
            // MessageBox.Show("hi");
        }
    }
}
