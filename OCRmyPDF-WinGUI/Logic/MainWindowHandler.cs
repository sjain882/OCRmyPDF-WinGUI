using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        // Init
        public event PropertyChangedEventHandler? PropertyChanged;

        public OCRConfig ocrConfig;

        public List<string> filePaths { get; set; }

        public ObservableCollection<string> filePathsList;


        // Constructor
        public MainWindowHandler()
        {
            ocrConfig = new OCRConfig();
            filePaths = new List<string>();
            filePathsList = new ObservableCollection<string>();
            
        }

        // Call at end of each property's setter
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // ---------- DATA BINDINGS (OCRConfig) ----------

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
