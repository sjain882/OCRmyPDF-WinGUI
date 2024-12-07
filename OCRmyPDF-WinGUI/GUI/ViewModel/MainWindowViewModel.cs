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
using OcrMyPdf.Logic.Options;
using System.Diagnostics;
using System.Windows;
using System.Configuration;
using System.Windows.Media;

namespace OcrMyPdf.GUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        // Init
        public ObservableCollection<string> filePathsList;
        public OCROptionSet ocrOptions;
        private const string PROGRESS = "Progress";
        private const int PROGRESS_DELAY = 200;
        private string progressText;
        private bool isRunning;


        // Constructor
        public MainWindowViewModel()
        {
            isRunning = false;
            progressText = String.Empty;
            ocrOptions = new OCROptionSet();
            filePathsList = new ObservableCollection<string>();

        }

        // -------------------- DATA BINDINGS START --------------------

        // ---------------------- FILE PATHS LIST ----------------------

        public ObservableCollection<string> FilePathsList
        {
            get { return filePathsList; }
            set { filePathsList = value; }
        }


        // -------------------------- OPTIONS --------------------------

        public ObservableCollection<MultiOptionTemplate> ProcessingPolicy
        {
            get { return Logic.Options.ProcessingPolicy.OptionList; }
        }

        public MultiOptionTemplate ProcessingPolicy_Selected
        {
            get { return ocrOptions.processingPolicy; }
            set
            { 
                ocrOptions.processingPolicy = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MultiOptionTemplate> PDFType
        {
            get { return Logic.Options.PDFType.OptionList; }
        }

        public MultiOptionTemplate PDFType_Selected
        {
            get { return ocrOptions.pdfType; }
            set
            {
                ocrOptions.pdfType = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MultiOptionTemplate> OptimisationLevel
        {
            get { return Logic.Options.OptimisationLevel.OptionList; }
        }

        public MultiOptionTemplate OptimisationLevel_Selected
        {
            get { return ocrOptions.optimisationLevel; }
            set
            {
                ocrOptions.optimisationLevel = value;
                OnPropertyChanged();
            }
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


        // ------------------- PROGRESS/STATUS LABEL -------------------

        // Progress label text
        public string ProgressText
        {
            get { return this.progressText; }
            set
            {
                this.progressText = value;
                OnPropertyChanged();
            }
        }

        // Is the task currently running?
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; OnPropertyChanged(); }
        }


    }
}
