using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OcrMyPdf.GUI.ViewModel.Commands
{
    public class UpdateProgressCommand : ICommand
    {

        // Reference to main ViewModel
        private MainWindowViewModel ViewModel;

        public event EventHandler CanExecuteChanged;

        public UpdateProgressCommand(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // ViewModel.RunProgressTextUpdate();
        }
    }
}
