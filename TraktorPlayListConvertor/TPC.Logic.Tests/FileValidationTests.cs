using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPC.Logic.FileValidation;

namespace TPC.Logic.Tests
{
	[TestClass]
	public class FileValidationTests
	{
		private string _htmlFileName = "test.html";
		private string _exeFileName = "test.exe";
		private string _wordFileName = "test.docx";

		private string _htmlFilePath = "";
		private string _wavFilePath = "";
		private string _exeFilePath = "";

		[TestMethod]
		public void EnsureFileExtensionIsDotHtml()
		{
			//Arrange:
			FileExtensionChecker fileExtensionChecker = new FileExtensionChecker();

			//Act:
			bool htmlResult = fileExtensionChecker.IsHtmlFile(_htmlFileName);
			bool exeResult = fileExtensionChecker.IsHtmlFile(_exeFileName);
			bool wordResult = fileExtensionChecker.IsHtmlFile(_wordFileName);
			//Assert:
			Assert.IsTrue(htmlResult);
			Assert.IsFalse(exeResult);
			Assert.IsFalse(wordResult);
		}

		[TestMethod]
		public void EnsureFileMimeTypeIsTextSlashHtml()
		{
			//Arrange:
			FileMimeTypeChecker fileMimeTypeChecker = new FileMimeTypeChecker();
			//Act:
			bool htmlResult = fileMimeTypeChecker.IsFileMimeTypeHtml(_htmlFilePath);
			bool wavResult = fileMimeTypeChecker.IsFileMimeTypeHtml(_wavFilePath);
			bool exeResult = fileMimeTypeChecker.IsFileMimeTypeHtml(_exeFilePath);
			//Assert:
			Assert.IsTrue(htmlResult);
			Assert.IsFalse(wavResult);
			Assert.IsFalse(exeResult);
		}

		[TestMethod]
		public void EnsureFileContentIsParsable()
		{
			//Arrange:
			FileContentChecker fileContentChecker = new FileContentChecker();

			//Act:
			bool htmlResult = fileContentChecker.IsContentParsable(_htmlFilePath);
			bool wavResult = fileContentChecker.IsContentParsable(_wavFilePath);
			bool exeResult = fileContentChecker.IsContentParsable(_exeFilePath);
			//Assert:
			Assert.IsTrue(htmlResult);
			Assert.IsFalse(wavResult);
			Assert.IsFalse(exeResult);
		}
	}
}
