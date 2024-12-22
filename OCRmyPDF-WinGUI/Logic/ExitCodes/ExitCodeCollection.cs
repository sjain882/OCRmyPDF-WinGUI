using OcrMyPdf.Logic.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

// Source: https://ocrmypdf.readthedocs.io/en/latest/advanced.html

namespace OcrMyPdf.Logic.ExitCodes
{
    public class ExitCodeCollection
    {
        public static readonly List<ExitCodeTemplate> ExitCodeList = new List<ExitCodeTemplate>
        {
            new ExitCodeTemplate(
                "OK",
                0,
                "OK",
                "Everything worked as expected."),


            new ExitCodeTemplate(
                "BadArgs",
                1,
                "Bad Arguments",
                "Invalid arguments, exited with an error."),


            new ExitCodeTemplate(
                "InputFile",
                2,
                "Bad Input File",
                "The input file does not seem to be a valid PDF."),


            new ExitCodeTemplate(
                "MissingDependency",
                3,
                "Missing Dependency",
                "An external program required by OCRmyPDF is missing."),


            new ExitCodeTemplate(
                "InvalidOutputPDF",
                4,
                "Invalid Output PDF",
                "An output file was created, but it does not seem to be a valid PDF. The file will be available."),


            new ExitCodeTemplate(
                "FileAccessError",
                5,
                "File Access Error",
                "The user running OCRmyPDF does not have sufficient permissions to read the input file and write the output file."),


            new ExitCodeTemplate(
                "AlreadyDoneOCR",
                6,
                "Already Done OCR",
                "The file already appears to contain text so it may not need OCR. Try changing \"Processing Policy\" to \"Redo\" or \"Force\""),


            new ExitCodeTemplate(
                "ChildProcessError",
                7,
                "Child Process Error",
                "An error occurred in an external program (child process) and OCRmyPDF cannot continue."),


            new ExitCodeTemplate(
                "EncryptedPDF",
                8,
                "Encrypted PDF",
                "The input PDF is encrypted. OCRmyPDF does not read encrypted PDFs. Use another program such as qpdf to remove encryption."),


            new ExitCodeTemplate(
                "InvalidConfig",
                9,
                "Invalid Config",
                "A custom configuration file was forwarded to Tesseract using --tesseract-config, and Tesseract rejected this file."),


            new ExitCodeTemplate(
                "PDFAConversionFailed",
                10,
                "PDF/A Conversion Failed",
                "A valid PDF was created, PDF/A conversion failed. The file will be available."),


            new ExitCodeTemplate(
                "OtherError",
                15,
                "Other Error",
                "Some other error occurred."),


            new ExitCodeTemplate(
                "CtrlC",
                130,
                "Ctrl C / Command Line Break",
                "The program was interrupted by pressing Ctrl+C.")
        };
    }
}
