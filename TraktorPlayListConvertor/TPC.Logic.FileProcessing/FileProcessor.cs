using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TPC.Models;
using TPC.Enums;
using TPC.Helpers;

namespace TPC.Logic.FileProcessing
{
    public class FileProcessor
    {
        public HeadingModel GetHeadingModel(Headings heading, HtmlDocument document)
        {
            HeadingModel headingModel = new HeadingModel();

            return headingModel;
        }
    }
}
