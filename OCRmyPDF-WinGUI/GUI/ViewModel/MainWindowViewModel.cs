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
using System.Diagnostics;
using System.Windows;

namespace OcrMyPdf.GUI.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        // Init
        public OCROptionSet ocrOptions;

        public ObservableCollection<string> filePathsList;

        public string consoleOutput;


        // Constructor
        public MainWindowViewModel()
        {
            consoleOutput = "";
            ocrOptions = new OCROptionSet();
            filePathsList = new ObservableCollection<string>();

        }

        // ---------- DATA BINDINGS ----------

        public ObservableCollection<string> FilePathsList
        {
            get { return filePathsList; }
            set { filePathsList = value; }
        }

        public ObservableCollection<MultiOptionTemplate> ProcessingPolicy
        {
            get { return Options.ProcessingPolicy.OptionList; }
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
            get { return Options.PDFType.OptionList; }
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
            get { return Options.OptimisationLevel.OptionList; }
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

        public string ConsoleOutput
        {
            get { return this.consoleOutput; }
            set
            {
                this.consoleOutput = value;
                OnPropertyChanged();
            }
        }

    }
}
