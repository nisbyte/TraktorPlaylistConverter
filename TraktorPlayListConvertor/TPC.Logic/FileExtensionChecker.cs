using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC.Logic.FileValidation
{
	public class FileExtensionChecker
	{
		private const string _htmlExtension = ".html";

		public bool IsHtmlFile(string fileName)
		{
			if (fileName.EndsWith(_htmlExtension))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
