using OcrMyPdf.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.GUI.ViewModel
{
    public class ErrorListWindowViewModel
    {

        public ObservableCollection<OCRError> pdfErrors;

        public ErrorListWindowViewModel(ObservableCollection<OCRError> pdfErrors)
        {
            this.pdfErrors = pdfErrors;
        }

    }
}
