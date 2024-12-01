using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using OcrMyPdf.GUI.MVVM;
using OcrMyPdf.Logic;
using OcrMyPdf.Options;

namespace OcrMyPdf.GUI.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        // Init
        public OCROptionSet ocrOptions;

        public ObservableCollection<string> filePathsList;


        // Constructor
        public MainWindowViewModel()
        {
            ocrOptions = new OCROptionSet();
            filePathsList = new ObservableCollection<string>();

        }

        // ---------- DATA BINDINGS ----------

        public ObservableCollection<string> FilePathsList
        {
            get { return filePathsList; }
            set { filePathsList = value; }
        }

        public string Suffix
        {
            get { return ocrOptions.outputSuffix; }
            set
            {
                ocrOptions.outputSuffix = value;
                OnPropertyChanged();
            }
        }

        public bool Deskew
        {
            get { return ocrOptions.deskew; }
            set
            {
                ocrOptions.deskew = value;
                OnPropertyChanged();
            }
        }

        public bool Rotate
        {
            get { return ocrOptions.rotate; }
            set
            {
                ocrOptions.rotate = value;
                OnPropertyChanged();
            }
        }






    }


}
