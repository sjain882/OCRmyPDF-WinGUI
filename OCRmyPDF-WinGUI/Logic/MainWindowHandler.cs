using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OcrMyPdf.Logic
{
    internal class MainWindowHandler : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public OCRConfig ocrConfig;

        public List<string> inputFilePaths;

        public MainWindowHandler()
        {
            ocrConfig = new OCRConfig();
            inputFilePaths = new List<string>();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // ---------- DATA BINDINGS (OCRConfig) ----------

        public ComboBoxItem OptimisationLevel
        {
            get { return 
        }

        public string Suffix
        {
            get { return ocrConfig.outputSuffix; }
            set
            {
                ocrConfig.outputSuffix = value;
                OnPropertyChanged();
            }
        }

        public bool Deskew
        {
            get { return ocrConfig.deskew; }
            set
            {
                ocrConfig.deskew = value;
                OnPropertyChanged();
            }
        }

        public bool Rotate
        {
            get { return ocrConfig.rotate; }
            set
            {
                ocrConfig.rotate = value;
                OnPropertyChanged();
            }
        }






    }


}
