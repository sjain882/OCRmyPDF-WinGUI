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
using OcrMyPdf.GUI.ViewModel.Commands;
using OcrMyPdf.Logic.ExitCodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OcrMyPdf.GUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private const string PROGRESS = "Processing";
        private const int PROGRESS_DOT_DELAY = 200;
        
        public ObservableCollection<string> filePathsList;
        public OCROptionSet ocrOptions;
        public Dictionary<string, int> pdfErrors;

        private int currentPDF;
        private string progressText;
        private bool isRunning;


        // Constructor
        public MainWindowViewModel()
        {
            filePathsList = new ObservableCollection<string>();
            ocrOptions = new OCROptionSet();
            pdfErrors = new Dictionary<string, int>();

            currentPDF = 0;
            progressText = "";
            isRunning = false;

            // Create Label Update progress command object, passing a reference to this ViewModel to it 
            StartOCRCommand = new StartOCRCommand(this);

        }

        // -------------------- DATA BINDINGS START --------------------

        // ---------------------- FILE PATHS LIST ----------------------

        public ObservableCollection<string> FilePathsList
        {
            get { return filePathsList; }
            set { filePathsList = value; }
        }


        // -------------------------- OPTIONS --------------------------

        // ----- Processing Policy

        public ObservableCollection<MultiOptionTemplate> ProcessingPolicy
        {
            get { return Logic.Options.ProcessingPolicy.OptionList; }
        }

        public MultiOptionTemplate ProcessingPolicy_Selected
        {
            get { return ocrOptions.processingPolicy; }
            set { ocrOptions.processingPolicy = value; OnPropertyChanged(); }
        }

        // ----- PDF Type

        public ObservableCollection<MultiOptionTemplate> PDFType
        {
            get { return Logic.Options.PDFType.OptionList; }
        }

        public MultiOptionTemplate PDFType_Selected
        {
            get { return ocrOptions.pdfType; }
            set { ocrOptions.pdfType = value; OnPropertyChanged(); }
        }

        // ----- Optimisation Level

        public ObservableCollection<MultiOptionTemplate> OptimisationLevel
        {
            get { return Logic.Options.OptimisationLevel.OptionList; }
        }

        public MultiOptionTemplate OptimisationLevel_Selected
        {
            get { return ocrOptions.optimisationLevel; }
            set { ocrOptions.optimisationLevel = value; OnPropertyChanged(); }
        }

        // ----- Output File Suffix

        public string Suffix
        {
            get { return ocrOptions.outputSuffix; }
            set { ocrOptions.outputSuffix = value; OnPropertyChanged(); }
        }

        // ----- Deskew pages

        public bool Deskew
        {
            get { return ocrOptions.deskew; }
            set { ocrOptions.deskew = value; OnPropertyChanged(); }
        }

        // ----- Rotate pages

        public bool Rotate
        {
            get { return ocrOptions.rotate; }
            set { ocrOptions.rotate = value; OnPropertyChanged(); }
        }


        // ------------------- PROGRESS/STATUS LABEL -------------------

        // ----- Progress label text

        public string ProgressText
        {
            get { return this.progressText; }
            set { this.progressText = value; OnPropertyChanged(); }
        }

        // ----- Is a PDF currently being processed?

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; OnPropertyChanged(); }
        }

        // ----- Start! button command binding
        public StartOCRCommand StartOCRCommand { get; set; }


        // --------------------- DATA BINDINGS END ---------------------


        public async Task RunOCRWithProgressUpdates()
        {
            // Create a new cancellation token source here, originating from this method
            var cts = new CancellationTokenSource();

            // If a task isn't already running
            if (!IsRunning)
            {
                // A task is now running
                IsRunning = true;

                // Start the progress update
                UpdateProgressTextTask(cts.Token);

                // Run the long task (convert PDF)
                string longTaskText = await Task.Run(() => LongTask(cts));

                await Task.Delay(PROGRESS_DOT_DELAY); // Additional delay to prevent alternating finished text by looping task

                // Update the progress text label
                ProgressText = longTaskText;

                // The task has ended
                IsRunning = false;

                // If there were errors, display them
                if (this.pdfErrors.Count > 0)
                {
                    foreach (KeyValuePair<string, int> error in this.pdfErrors)
                    {
                        // Show an error message box
                        MessageBox.Show
                        (
                            // Main body
                            "Error in PDF:\r\n"
                            + error.Key
                            + "\r\n\r\n"
                            + ExitCodes.ExitCodeList.Single(o => o.code == error.Value).nameAndDesc,

                            // Title
                            "Error",

                            // Button
                            MessageBoxButton.OK,

                            // Icon
                            MessageBoxImage.Error
                        );
                    }
                }
            }
        }


        // Update progress text label
        private void UpdateProgressTextTask(CancellationToken token)
        {
            Task.Run(async () =>
            {
                // Set the prefix
                ProgressText = PROGRESS;

                while (!token.IsCancellationRequested)
                {
                    // Delay between each progress dot appearing on the GUI
                    await Task.Delay(PROGRESS_DOT_DELAY);

                    // Create the new progress dot
                    var dotsCount = ProgressText.Count<char>(ch => ch == '.');

                    // Set the progress dot
                    ProgressText = dotsCount < 5 ? ProgressText + "." : ProgressText.Replace(".", "");
                }
            });
        }


        // The long task to execute (OCR PDF)
        private string LongTask(CancellationTokenSource cts)
        {
            // Start the task asynchronously
            var result = Task.Run(async () =>
            {

                if (filePathsList.Count > 0)
                {
                    // Replace this with OCR.Run
                    // await Task.Delay(5000);
                    foreach (string path in filePathsList)
                    {
                        int exitCode = OCRRunner.OCRSinglePDF(path, this.ocrOptions);

                        // If there was an error, record it
                        if (exitCode != ExitCodes.ExitCodeList.Single(o => o.identifier == "OK").code)
                        {
                            this.pdfErrors.Add(path, exitCode);
                        }
                    }
                }
                else
                {
                    cts.Cancel();
                    return "No PDFs selected!";
                }

                // Cancel the cancellation token once the task finished.
                cts.Cancel();

                // Return the relevant status string
                return "All PDFs processed.";
            });

            // Return result of task being run
            return result.Result;
        }

    }
}
