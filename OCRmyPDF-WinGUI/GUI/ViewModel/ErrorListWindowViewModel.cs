using OcrMyPdf.GUI.MVVM;
using OcrMyPdf.Logic;
using OcrMyPdf.Logic.ExitCodes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.GUI.ViewModel
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

        //public OCRError ErrorList_SelectedValue
        //{
        //    get { return selectedError; }
        //    set { selectedError = value; OnPropertyChanged(); }
        //}


        // ------------------------ ERROR DETAILS ----------------------

        public string ErrorFilePath
        {
            get
            {
                if (selectedError == null)
                    return "";

                return selectedError.filePath;
            }
        }

        public string ErrorName
        {
            get
            {
                if (selectedError == null)
                    return "";

                return ExitCodes.ExitCodeList.Single(o => o.code == selectedError.exitCodeObject.code).displayName;
            }
        }

        public string ErrorDescription
        {
            get
            {
                if (selectedError == null)
                    return "";

                return ExitCodes.ExitCodeList.Single(o => o.code == selectedError.exitCodeObject.code).description;
            
            }
        }

        // --------------------- DATA BINDINGS END ---------------------
    }
}
