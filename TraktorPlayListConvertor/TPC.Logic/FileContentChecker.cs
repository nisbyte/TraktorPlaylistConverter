using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;

namespace TPC.Logic
{
	public class FileContentChecker
	{
		private static string _tablesXpath = "//table";

		public bool IsContentParsable(string filePath)
		{
			if(filePath.EndsWith(".html") && File.Exists(filePath))
			{
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.Load(filePath);
				Encoding encoding = htmlDocument.DeclaredEncoding;
				
				if (HasTable(htmlDocument))
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

		private static bool HasTable(HtmlDocument htmlDocument)
		{
			return htmlDocument.DocumentNode.SelectNodes(_tablesXpath).Count > 0;
		}
	}
}
