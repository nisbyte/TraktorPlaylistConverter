using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPC.Logic.FileProcessing;
using TPC.Enums;
using TPC.Models;

namespace TPC.Logic.Tests
{
	[TestClass]
	public class FileProcessingTests
	{
		private FileProcessor _fileProcessor = new FileProcessor();
		private string _htmlWithTable = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">< style type=\"text/css\"><!--body { margin: 10px; }	body, th, td, p, div, li {font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 11px;}h1 {font-size: 18px;font-weight: bold;}table.border {border: 1px solid #666666;border-collapse: collapse;}th {font-weight: bold;vertical-align: top;padding: 5px;text-align: left;background: #990000;border-right: 1px solid #FFFFFF;color: #FFFFFF;}td {vertical-align: top;padding: 5px;text-align: left;border-top: 1px solid #666666;border-right: 1px solid #666666;}td.key {background: #CCCCCC;font-weight: bold;}--></style> <? xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?><html>  <head>    <title>Track List</title>    <meta content = \"text/html; charset=utf-8\" http-equiv=\"Content-Type\"/>  </head>  <body bgcolor = \"#ffffff\" >	< h1 > Track List: Tracklist</h1>    <table cellpadding = \"0\" cellspacing=\"0\" class=\"border\" width=\"100px\"> <tr>" +
		"<th>Num.</th>" +
		"<th>Title</th>" +
		"<th>Artist</th>" +
		"<th>Time</th>" +
		"<th>BPM</th>" +
		"<th>Track</th>" +
		"<th>Release</th>" +
		"<th>Label</th>" +
		"<th>Genre</th>" +
		"<th>Key Text</th>" +
		"<th>Key</th>" +
		"<th>Comment</th>" +
		"<th>Lyrics</th>" +
		"<th>Rating</th>" +
		"<th>File</th>" +
		"<th>Analyzed (Peak, Perceived)</th>" +
		"<th>Remixer</th>" +
		"<th>Producer</th>" +
		"<th>Release Date</th>" +
		"<th>Bitrate</th>" +
		"<th>Comment2</th>" +
		"<th>Play Count</th>" +
		"<th>Last Played</th>" +
		"<th>Import Date</th>" +
		"<th>Start Time</th>" +
		"<th>Duration</th>" +
		"<th>Deck</th>" +
		"<th>Played Public</th>" +" </tr>" + 
		"<tr>" +
		"<td>1</td>" +
		"<td>Dragons Dynamite (Perc remix)</td>" +
		"<td>ANSOME</td>" +
		"<td>06:01</td>" +
		"<td>134.000</td>" +
		"<td>3</td>" +
		"<td>Coffin Dodge EP</td>" +
		"<td>Them Recordings</td>" +
		"<td>Techno</td>" +
		"<td></td>" +
		"<td>G#m</td>" +
		"<td></td>" +
		"<td></td>" +
		"<td></td>" +
		"<td>C:\\Users\\User\\Music\\Techno\\Ansome\\Coffin Dodge EP - Them Recordings\\3-Ansome - Dragons Dynamite (Perc remix)-320kb s MP3.mp3</td>" +
		"< td>Stripe, Transients, Gain (+0.2 dB), Key</td>" +
		"<td></td>" +
		"<td></td>" +
		"<td>2018/04/06</td>" +
		"<td>320000</td>" +
		"<td></td>" +
		"<td>1</td>" +
		"<td>2018/04/08</td>" +
		"<td>2018/04/08</td>" +
		"<td>2018/4/8 11:24:05</td>" +
		"<td>02:38</td>" +
		"<td>Deck A</td>" +
		"<td>yes</td>" +
	  "</tr>" +
  "</table>" +
  "</body>" +
"</html>";

		[TestMethod]
		public void EnsureTableHeadingsAreRead()
		{
			//Arrange:
			HeadingModel titleHeading = new HeadingModel();
			HeadingModel artistHeading = new HeadingModel();
			
			//Act:
			titleHeading = _fileProcessor.GetHeadingModel(Headings.Title);
			artistHeading = _fileProcessor.GetHeadingModel(Headings.Artist);
            //Assert:
            Assert.AreEqual("Title", titleHeading.HeadingText);
            Assert.AreEqual("Artist", artistHeading.HeadingText);
            Assert.AreEqual(1, titleHeading.HeadingIndex);
            Assert.AreEqual(2, artistHeading.HeadingIndex);
        }
	}
}
