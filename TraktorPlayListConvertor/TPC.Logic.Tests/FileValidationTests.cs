using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPC.Logic.FileValidation;

namespace TPC.Logic.Tests
{
	[TestClass]
	public class FileValidationTests
	{
		private string _emptyString = string.Empty;
		private string _htmlFileName = "test.html";
		private string _exeFileName = "test.exe";
		private string _wordFileName = "test.docx";

		private string _htmlFilePath = "C:\\Temp\\testHtml.html";
		private string _mp3FilePath  = "C:\\Temp\\testMp3.mp3";
		private string _mprjFilePath  = "C:\\Temp\\testMprj.mprj";

		private FileExtensionChecker _fileExtensionChecker = new FileExtensionChecker();
		private FileContentChecker _fileContentChecker = new FileContentChecker();

		[TestMethod]
		public void EnsureFileExtensionIsDotHtml()
		{
			//Act:
			bool emptyResult = _fileExtensionChecker.IsHtmlFile(_emptyString);
			bool htmlResult = _fileExtensionChecker.IsHtmlFile(_htmlFileName);
			bool exeResult = _fileExtensionChecker.IsHtmlFile(_exeFileName);
			bool wordResult = _fileExtensionChecker.IsHtmlFile(_wordFileName);
			//Assert:
			Assert.IsFalse(emptyResult);
			Assert.IsTrue(htmlResult);
			Assert.IsFalse(exeResult);
			Assert.IsFalse(wordResult);
		}
		
		[TestMethod]
		public void EnsureFileContentIsParsable()
		{
			//Act:
			bool emptyResult = _fileContentChecker.IsContentParsable(_emptyString);
			bool htmlResult = _fileContentChecker.IsContentParsable(_htmlFilePath);
			bool wavResult = _fileContentChecker.IsContentParsable(_mp3FilePath);
			bool exeResult = _fileContentChecker.IsContentParsable(_mprjFilePath);
			//Assert:
			Assert.IsFalse(emptyResult);
			Assert.IsTrue(htmlResult);
			Assert.IsFalse(wavResult);
			Assert.IsFalse(exeResult);
		}
	}
}
