﻿using Microsoft.Win32;
using OcrMyPdf.Gui.Theme;
using OcrMyPdf.Gui.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace OcrMyPdf.Gui.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainWindowViewModel ViewModel;
        private DispatcherTimer dispatcherTimer;


        public MainWindow()
        {
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;

            // Setup theme detection
            ThemeChanger themeChanger = new ThemeChanger(this);
            themeChanger.ChangeTheme();

            // InitializeComponent() must be called after the above!
            InitializeComponent();

            // Create a timer with interval of 4 seconds
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 4);
        }


        private void SelectFilesBtn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select PDF Files";
            fileDialog.DefaultExt = "pdf";
            fileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            fileDialog.Multiselect = true;
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;

            bool? fileDialogSuccess = fileDialog.ShowDialog();

            if (fileDialogSuccess == true)
            {
                foreach (string path in fileDialog.FileNames)
                {
                    ViewModel.filePathsList.Add(path);
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }


        private void ClearFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.filePathsList.Clear();
            ViewModel.ocrErrors.Clear();
            CommandManager.InvalidateRequerySuggested();
        }


        // Drag & drop onto files box
        private void FileList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    // If its a folder
                    if (Directory.Exists(file))
                    {
                        // Iterate its files
                        foreach (string fileInFolder in Directory.GetFiles(file))
                        {
                            // Don't add the folder itself
                            if (System.IO.Path.GetExtension(fileInFolder).ToUpperInvariant() == ".PDF")
                            {
                                // Prevent duplicates from being dropped
                                if (!ViewModel.filePathsList.Contains(fileInFolder))
                                {
                                    ViewModel.filePathsList.Add(fileInFolder);
                                    CommandManager.InvalidateRequerySuggested();
                                }
                            }
                        }
                    }
                    // If its a PDF file... normal check: prevent duplicates from being dropped
                    else if (!ViewModel.filePathsList.Contains(file))
                    {
                        ViewModel.filePathsList.Add(file);
                        CommandManager.InvalidateRequerySuggested();
                    }
                }
            }
        }


        // As the dragged files enter the ListBox area, make sure they're PDF files
        // If not, prevent drag & drop
        private void FileList_DragOver(object sender, DragEventArgs e)
        {
            bool dropEnabled = true;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string fileOrFolder in files)
                {
                    // If its a folder(s)... continue anyway, because we automatically filter out non-PDFs in FileList_Drop
                    if (Directory.Exists(fileOrFolder))
                    {
                        continue;
                    }
                    // If its a file(s), check if they're PDFs
                    else if (System.IO.Path.GetExtension(fileOrFolder).ToUpperInvariant() != ".PDF")
                    {
                        // if not, prevent drag & drop
                        dropEnabled = false;

                        // and notify the user
                        PDFOnlyWarningLbl.Visibility = System.Windows.Visibility.Visible;
                        dispatcherTimer.Start();
                        break;
                    }
                }
            }
            else
            {
                dropEnabled = false;
            }

            if (!dropEnabled)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }


        // 4 second auto-dismiss for non-PDF file drag & drop warning label
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // After 1 timer interval...
            PDFOnlyWarningLbl.Visibility = System.Windows.Visibility.Collapsed;

            // Stop timer
            dispatcherTimer.IsEnabled = false;
        }


        // When the main application window is closed, close all other windows & exit
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}