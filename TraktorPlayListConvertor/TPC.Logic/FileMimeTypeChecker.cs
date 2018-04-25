using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HeyRed.Mime;


namespace TPC.Logic
{
	public class FileMimeTypeChecker
	{
		private const string permittedMimeType = "text/html";

		public bool IsFileMimeTypeHtml(string filePath)
		{
			if(filePath.IndexOf(".") > 0 && File.Exists(filePath))
			{
				string mimeType = MimeGuesser.GuessMimeType(filePath);
				if(mimeType == permittedMimeType)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
	}
}
