﻿using OcrMyPdf.Gui.MVVM;
using OcrMyPdf.Gui.View;
using OcrMyPdf.Gui.ViewModel.Commands;
using OcrMyPdf.Logic;
using OcrMyPdf.Logic.ExitCodes;
using OcrMyPdf.Logic.Options;
using System.Collections.ObjectModel;
using System.Windows;

namespace OcrMyPdf.Gui.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private const string PROGRESS_PREFIX = "Processing PDF ";
        private const int PROGRESS_DOT_DELAY = 200;
        private int progressBarPercentage;
        private Visibility progressBarVisibility;
        private string progressLabelText;

        public ObservableCollection<string> filePathsList;
        public OCROptionSet ocrOptions;
        public ObservableCollection<OCRError> ocrErrors;
        public ObservableCollection<string> ocrSuccesses;

        private int advancedOptionsHeight;
        private bool advancedOptionsExpanded;

        CancellationTokenSource cts;
        private string currentPDF;
        private bool isRunning;
        private string startStopBtnText;

        public ErrorListWindow errorListWindow;

        private int win_xHeight;
        private int win_yHeight;
        private int win_left;
        private int win_top;


        public MainWindowViewModel()
        {
            // Set the default window dimensions
            this.XWidth = 500;
            this.YHeight = 660;

            // Advanced options are non-expanded by default
            this.AdvancedOptionsExpanded = false;
            this.AdvancedOptionsHeight = 30;

            // ProgressBar is hidden by default
            this.ProgressBarPercentage = 0;
            this.ProgressBarVisibility = Visibility.Collapsed;

            // Init
            filePathsList = new ObservableCollection<string>();
            ocrOptions = new OCROptionSet();
            ocrErrors = new ObservableCollection<OCRError>();
            ocrSuccesses = new ObservableCollection<string>();
            progressLabelText = "";
            startStopBtnText = "Start!";
            isRunning = false;

            // Create "remove file from file list" command object, passing a reference to this ViewModel to it 
            RemoveFileCommand = new RemoveFileCommand(this);

            // Create "Update progress label command" object, passing a reference to this ViewModel to it 
            StartOCRCommand = new StartOCRCommand(this);

        }


        // -------------------- DATA BINDINGS START --------------------




        // ---------------------- FILE PATHS LIST ----------------------

        // ----- List of queued files

        public ObservableCollection<string> FilePathsList
        {
            get { return filePathsList; }
            set { filePathsList = value; }
        }

        public string FilePathsList_Selected
        {
            get { return currentPDF; }
            set { currentPDF = value; OnPropertyChanged(); }
        }

        // ----- Remove file from file list command binding
        public RemoveFileCommand RemoveFileCommand { get; set; }




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




        // ---------------------- ADVANCED OPTIONS ----------------------

        // ----- Auto clear successful conversions

        public bool ClearSuccesses
        {
            get { return ocrOptions.clearSuccesses; }
            set { ocrOptions.clearSuccesses = value; OnPropertyChanged(); }
        }

        // ----- Output converted PDFs to separate directory

        public bool SeparateDir
        {
            get { return ocrOptions.separateDir; }
            set { ocrOptions.separateDir = value; OnPropertyChanged(); }
        }




        // -------------------------- BUTTONS --------------------------

        // ----- Start/Stop button text
        public string StartStopBtnText
        {
            get { return this.startStopBtnText; }
            set { this.startStopBtnText = value; OnPropertyChanged(); }
        }

        // ----- Start/Stop button command binding
        public StartOCRCommand StartOCRCommand { get; set; }




        // ----------------- PROGRESS BAR & STATUS TEXT ----------------

        // ----- Progress label text

        public string ProgressLabelText
        {
            get { return this.progressLabelText; }
            set { this.progressLabelText = value; OnPropertyChanged(); }
        }

        // ----- Progress bar percentage

        public int ProgressBarPercentage
        {
            get { return this.progressBarPercentage; }
            set { this.progressBarPercentage = value;  OnPropertyChanged(); }
        }

        // ----- Progress bar visibility

        public Visibility ProgressBarVisibility
        {
            get { return this.progressBarVisibility; }
            set { this.progressBarVisibility = value; OnPropertyChanged(); }
        }

        // ----- Is a PDF currently being processed?

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; OnPropertyChanged(); }
        }




        // --------------------- ADVANCED OPTIONS ----------------------

        // ----- Advanced Options Expander Height

        public int AdvancedOptionsHeight
        {
            get { return advancedOptionsHeight; }
            set
            {
                advancedOptionsHeight = value;
                OnPropertyChanged();
            }
        }

        // ----- Is Advanced Options Expanded?

        public bool AdvancedOptionsExpanded
        {
            get { return advancedOptionsExpanded; }
            set
            {
                advancedOptionsExpanded = value;


                if (advancedOptionsExpanded)
                {
                    AdvancedOptionsHeight = 90;
                    YHeight = YHeight + 60;
                }
                else
                {
                    AdvancedOptionsHeight = 30;
                    YHeight = YHeight - 60;
                }

                OnPropertyChanged();
            }
        }




        // --------------------- WINDOW DIMENSIONS ---------------------

        // ----- X / Width

        public int XWidth
        {
            get { return this.win_xHeight; }
            set { this.win_xHeight = value; OnPropertyChanged(); }
        }

        // ----- Y / Height

        public int YHeight
        {
            get { return this.win_yHeight; }
            set { this.win_yHeight = value; OnPropertyChanged(); }
        }
        

        // ----- Left

        public int Left
        {
            get { return this.win_left; }
            set { this.win_left = value; OnPropertyChanged(); }
        }
        

        // ----- Top

        public int Top
        {
            get { return this.win_top; }
            set { this.win_top = value; OnPropertyChanged(); }
        }



        // --------------------- DATA BINDINGS END ---------------------


        public async Task RunOCRWithProgressUpdates()
        {
            // Create a new cancellation token source here, originating from this method
            cts = new CancellationTokenSource();

            // If a task isn't already running
            if (!IsRunning)
            {
                // A task is now running
                IsRunning = true;

                // Start the progress update
                UpdateProgressDotsTask(cts.Token);

                // Run the long task (convert PDF)
                string longTaskText = await Task.Run(() => LongTask(cts));

                await Task.Delay(PROGRESS_DOT_DELAY);

                // Update the progress text label
                ProgressLabelText = longTaskText;

                // The task has ended
                IsRunning = false;
                this.StartStopBtnText = "Start!";

                // If there were errors...
                if (this.ocrErrors.Count > 0)
                {
                    // ... list them in a new window
                    errorListWindow = new ErrorListWindow(ocrErrors) { Left = this.Left - this.XWidth - 10, Top = this.Top };

                    // If the user opted to automatically clear successful conversions, do so
                    if (ocrOptions.clearSuccesses)
                    {
                        foreach (string success in ocrSuccesses)
                        {
                            filePathsList.Remove(success);
                        }
                    }

                    // Show the error list window
                    errorListWindow.Show();

                    // Guide the user on what to do next
                    MessageBox.Show("Unfortunately, some errors occurred during the conversion process.\r\n\r\n"
                                    + "First, select a file from the list to view its error.\r\n\r\n"
                                    + "Then, make the appropriate changes to your configuration.\r\n\r\n"
                                    + "Finally, click Start to re-attempt conversion.",
                                    "OCRmyPDF",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }


        // Update progress text label
        private void UpdateProgressDotsTask(CancellationToken token)
        {
            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested || IsRunning)
                {
                    // Delay between each progress dot appearing on the GUI
                    await Task.Delay(PROGRESS_DOT_DELAY);

                    // Create the new progress dot
                    var dotsCount = ProgressLabelText.Count<char>(ch => ch == '.');

                    // Set the progress dot
                    ProgressLabelText = dotsCount < 5 ? ProgressLabelText + "." : ProgressLabelText.Replace(".", "");
                }
            });
        }


        public void CancelOCR()
        {
            cts.Cancel();
        }


        // The long task to execute (OCR PDF)
        private string LongTask(CancellationTokenSource cts)
        {
            // Start the task asynchronously
            var result = Task.Run(async () =>
            {
                OCRRunner ocrRunner = new OCRRunner(this.ocrOptions);

                if (filePathsList.Count > 0)
                {
                    int currentPDF = 0;
                    int totalPDFs = filePathsList.Count;

                    // Show the progress bar
                    ProgressBarVisibility = Visibility.Visible;

                    foreach (string path in filePathsList)
                    {
                        currentPDF += 1;

                        // Update the progress text
                        ProgressLabelText = PROGRESS_PREFIX + currentPDF + " of " + totalPDFs;

                        // Update the progress bar
                        ProgressBarPercentage = (int)Math.Round((currentPDF / (double)totalPDFs) * 100);

                        IsRunning = true;

                        int exitCode = ocrRunner.OCRSinglePDF(path);

                        IsRunning = false;

                        // If there was an error, record it
                        if (exitCode != ExitCodeCollection.ExitCodeList.Single(o => o.identifier == "OK").code)
                        {
                            App.Current.Dispatcher.Invoke(delegate
                            {
                                this.ocrErrors.Add(new OCRError(path, new ExitCodeTemplate(exitCode)));
                            });
                        }
                        // Otherwise, store it in the list of successfully converted files
                        else if (exitCode == ExitCodeCollection.ExitCodeList.Single(o => o.identifier == "OK").code)
                        {
                            App.Current.Dispatcher.Invoke(delegate
                            {
                                this.ocrSuccesses.Add(path);
                            });
                        }

                        if (cts.Token.IsCancellationRequested)
                        {
                            // Hide the progress bar when cancelled.
                            ProgressBarVisibility = Visibility.Collapsed;

                            int nextPDF = currentPDF + 1;
                            return "Queue stopped at PDF " + nextPDF + " of " + totalPDFs + ".";
                        }
                    }
                }
                else
                {
                    cts.Cancel();
                    ProgressBarVisibility = Visibility.Collapsed;
                    return "No PDFs selected!";
                }

                // Cancel the cancellation token when finished.
                cts.Cancel();

                // Hide the progress bar when finished.
                ProgressBarVisibility = Visibility.Collapsed;

                // Return the relevant status string
                return "All PDFs processed.";
            });

            // Return result of task being run
            return result.Result;
        }

    }
}