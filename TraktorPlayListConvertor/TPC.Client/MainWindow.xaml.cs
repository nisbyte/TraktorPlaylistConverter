using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using HtmlAgilityPack;
using TPC.Logic.FileValidation;
using TPC.Logic.FileProcessing;
using TPC.Enums;

namespace TPC.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static FileExtensionChecker _fileExtensionChecker = new FileExtensionChecker();
        private static FileProcessor _fileProcessor = new FileProcessor();
        private List<Headings> _headings = new List<Headings>();
        
        private bool _fileIsValid = false;
        private const string _invalidFileMessage = "Invalid file. Please select an HTML file.";

        public MainWindow()
        {
            InitializeComponent();
            _headings.Add(Headings.Artist);
            _headings.Add(Headings.Title);
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                if(_fileExtensionChecker.IsHtmlFile(openFileDialog.FileName))
                {
                    txtSelectedFile.Text = openFileDialog.FileName;
                    _fileIsValid = true;
                    btnProcessFile.IsEnabled = true;
                }
                else
                {
                    txtSelectedFile.Text = string.Empty;
                    txtFeedback.Text = _invalidFileMessage;
                    btnProcessFile.IsEnabled = false;
                }
                
            }
        }

        private void btnProcessFile_Click(object sender, RoutedEventArgs e)
        {
            string result = string.Empty;
            try
            {
                result = _fileProcessor.ConvertHtmlToText(_headings, txtSelectedFile.Text);
                txtResultBox.Text = result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                txtResultBox.Text = result;
                throw;
            }
        }
    }
}
