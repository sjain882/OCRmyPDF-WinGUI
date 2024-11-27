using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    internal class MainWindowHandler : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public OCRConfig ocrConfig;

        public List<string> inputFilePaths;

        // OCRConfig
        public bool Rotate
        {
            get { return ocrConfig.rotate; }
            set
            {
                ocrConfig.rotate = value;
                OnPropertyChanged();
            }
        }

        public MainWindowHandler()
        {
            ocrConfig = new OCRConfig();
            inputFilePaths = new List<string>();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }


}
