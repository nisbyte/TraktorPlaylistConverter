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
using TPC.Logic.FileValidation;

namespace TPC.Client
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private static FileExtensionChecker _fileExtensionChecker = new FileExtensionChecker();
		private bool _fileIsValid = false;
		private const string _invalidFileMessage = "Invalid file. Please select an HTML file.";
		public MainWindow()
		{
			InitializeComponent();
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
				}
				else
				{
					txtSelectedFile.Text = string.Empty;
					txtFeedback.Text = _invalidFileMessage; 
				}
				
			}
		}
	}
}
