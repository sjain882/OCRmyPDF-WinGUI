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
using System.Configuration;
using System.Windows.Media;

namespace OcrMyPdf.GUI.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        // Init
        public OCROptionSet ocrOptions;

        public ObservableCollection<string> filePathsList;

        public string currentPDFstatus;


        // Constructor
        public MainWindowViewModel()
        {
            currentPDFstatus = "";
            ocrOptions = new OCROptionSet();
            filePathsList = new ObservableCollection<string>();

        }

        // -------------------- DATA BINDINGS START --------------------

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

        public string CurrentPDFLbl
        {
            get { return this.currentPDFstatus; }
            set
            {
                this.currentPDFstatus = value;
                OnPropertyChanged();
            }
        }

        // -------------------- DATA BINDINGS END --------------------


        public void RunOCR()
        {
            // Init
            int currentPDF = 1;
            int totalPDFs = filePathsList.Count;
            char argsSprtr = ' ';
            StringBuilder argsBuilder = new StringBuilder();

            // Compile arguments
            argsBuilder.AppendWithSeparator(argsSprtr, ocrOptions.processingPolicy.argument);

            argsBuilder.AppendWithSeparator(argsSprtr, ocrOptions.pdfType.argument);

            argsBuilder.AppendWithSeparator(argsSprtr, ocrOptions.optimisationLevel.argument);

            if (ocrOptions.rotate) argsBuilder.AppendWithSeparator(argsSprtr, SimpleOptionParams.rotate);

            if (ocrOptions.deskew) argsBuilder.AppendWithSeparator(argsSprtr, SimpleOptionParams.deskew);

            string args = argsBuilder.ToString();

            // Process each file
            foreach (string path in filePathsList)
            {
                CurrentPDFLbl = $"Processing PDF {currentPDF} of {totalPDFs}";

                StringBuilder cmdBuilder = new StringBuilder();

                cmdBuilder.AppendWithSeparator(argsSprtr, "/C ocrmypdf");

                cmdBuilder.AppendWithSeparator(argsSprtr, args);

                cmdBuilder.AppendWithSeparator(argsSprtr, "\"" + path + "\"");

                cmdBuilder.AppendWithSeparator(argsSprtr, "\"" + Utilities.AddSuffix(path, ocrOptions.outputSuffix) + "\"");

                // MessageBox.Show(cmdBuilder.ToString());

                //System.Diagnostics.Process process = System.Diagnostics.Process.Start(@"cmd.exe", cmdBuilder.ToString());

                //process.Start();

                //process.WaitForExit();
                //int result = process.ExitCode;

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    /* run your code here */
                    Process process = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = @"cmd.exe",
                            Arguments = cmdBuilder.ToString(),
                            UseShellExecute = false,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };

                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit();
                }).Start();

                currentPDF++;

                //while (!process.StandardError.EndOfStream)
                //{
                //    this.consoleOutput += process.StandardError.ReadLine();
                //}
                //consoleOutput = "";

            }

            CurrentPDFLbl = $"Finished processing {totalPDFs} PDFs";

        }
    }
}
