using OcrMyPdf.Gui.MVVM;
using OcrMyPdf.Logic;
using OcrMyPdf.Logic.ExitCodes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Gui.ViewModel
{
    public class ErrorListWindowViewModel : ViewModelBase
    {

        public ObservableCollection<OCRError> ocrErrors;

        public OCRError selectedError;

        public ErrorListWindowViewModel(ObservableCollection<OCRError> ocrErrors)
        {
            this.ocrErrors = ocrErrors;
            //this.selectedError = new OCRError("", new ExitCodeTemplate(3));
        }


        // -------------------- DATA BINDINGS START --------------------

        // ------------------------- ERROR LIST ------------------------

        public ObservableCollection<OCRError> ErrorList
        {
            get { return ocrErrors; }
            set { ocrErrors = value; }
        }

        public OCRError ErrorList_Selected
        {
            get { return selectedError; }
            set { selectedError = value; OnPropertyChanged(); }
        }

        // --------------------- DATA BINDINGS END ---------------------
    }
}
