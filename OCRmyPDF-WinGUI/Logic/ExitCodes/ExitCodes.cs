using OcrMyPdf.Logic.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

// Source: https://ocrmypdf.readthedocs.io/en/latest/advanced.html

namespace OcrMyPdf.Logic.ExitCodes
{
    public class ExitCodes
    {
        public static readonly ExitCodeTemplate OK = new ExitCodeTemplate(
            0,
            "OK",
            "Everything worked as expected.");


        public static readonly ExitCodeTemplate BadArgs = new ExitCodeTemplate(
            1,
            "Bad Arguments",
            "Invalid arguments, exited with an error.");


        public static readonly ExitCodeTemplate InputFile = new ExitCodeTemplate(
            2,
            "Bad Input File",
            "The input file does not seem to be a valid PDF.");


        public static readonly ExitCodeTemplate MissingDependency = new ExitCodeTemplate(
            3,
            "Missing Dependency",
            "An external program required by OCRmyPDF is missing.");


        public static readonly ExitCodeTemplate InvalidOutputPDF = new ExitCodeTemplate(
            4,
            "Invalid Output PDF",
            "An output file was created, but it does not seem to be a valid PDF. The file will be available.");


        public static readonly ExitCodeTemplate FileAccessError = new ExitCodeTemplate(
            5,
            "File Access Error",
            "The user running OCRmyPDF does not have sufficient permissions to read the input file and write the output file.");


        public static readonly ExitCodeTemplate AlreadyDoneOCR = new ExitCodeTemplate(
            6,
            "Already Done OCR",
            "The file already appears to contain text so it may not need OCR. Try changing \"Processing Policy\" to \"Redo\" or \"Force\"");


        public static readonly ExitCodeTemplate ChildProcessError = new ExitCodeTemplate(
            7,
            "Child Process Error",
            "An error occurred in an external program (child process) and OCRmyPDF cannot continue.");


        public static readonly ExitCodeTemplate EncryptedPDF = new ExitCodeTemplate(
            8,
            "Encrypted PDF",
            "The input PDF is encrypted. OCRmyPDF does not read encrypted PDFs. Use another program such as qpdf to remove encryption.");


        public static readonly ExitCodeTemplate InvalidConfig = new ExitCodeTemplate(
            9,
            "Invalid Config",
            "A custom configuration file was forwarded to Tesseract using --tesseract-config, and Tesseract rejected this file.");


        public static readonly ExitCodeTemplate PDFAConversionFailed = new ExitCodeTemplate(
            10,
            "PDF/A Conversion Failed",
            "A valid PDF was created, PDF/A conversion failed. The file will be available.");


        public static readonly ExitCodeTemplate OtherError = new ExitCodeTemplate(
            15,
            "Other Error",
            "Some other error occurred.");


        public static readonly ExitCodeTemplate CtrlC = new ExitCodeTemplate(
            130,
            "Ctrl C / Command Line Break",
            "The program was interrupted by pressing Ctrl+C.");

    }
}
