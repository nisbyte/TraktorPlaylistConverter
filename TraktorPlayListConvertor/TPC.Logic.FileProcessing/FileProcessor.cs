using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TPC.Models;
using TPC.Enums;
using TPC.Helpers;
using System.Text.RegularExpressions;

namespace TPC.Logic.FileProcessing
{
    public class FileProcessor
    {
        public string ConvertHtmlToText(List<Headings> headings, string filePath)
        {
            HtmlDocument document = new HtmlDocument();
            document.Load(filePath);
            string convertedHtml = ConvertHtml(headings, document);

            return convertedHtml;
        }
        public string ConvertHtmlToText(List<Headings> headings, HtmlDocument document)
        {
            string convertedHtml = ConvertHtml(headings, document);

            return convertedHtml;
        }

        private HtmlNode ExtractTableFromDocument(HtmlDocument document)
        {
            HtmlNode tableNode = document.DocumentNode.SelectSingleNode("//table");
            tableNode.InnerHtml = Regex.Replace(tableNode.InnerHtml, @"( |\t|\r?\n)\1+", "$1");
            return tableNode;
        }

        private HtmlNodeCollection ExtractTableHeadingsFromTable(HtmlNode tableNode)
        {
            HtmlNodeCollection headingNodes = tableNode.SelectNodes("//tr//th");

            return headingNodes;
        }

        private List<HeadingModel> ExtractHeadingIndexes(HtmlNodeCollection headingNodes)
        {
            List<HeadingModel> headingIndexes = new List<HeadingModel>();

            foreach(HtmlNode headingNode in headingNodes)
            {
                string heading = headingNode.InnerText;
                int index = headingNodes.IndexOf(headingNode);

                HeadingModel headingModel = new HeadingModel(heading, index);
                headingIndexes.Add(headingModel);
            }

            return headingIndexes;
        }

        private List<HeadingModel> ExtractSelectedHeadingIndexes(List<Headings> selectedHeadings, List<HeadingModel> allHeadings)
        {
            List<HeadingModel> selectedHeadingModels = new List<HeadingModel>();

            foreach (Headings heading in selectedHeadings)
            {
                string headingText = EnumHelper.GetEnumDescription(heading);
                int headingIndex = allHeadings.Where(h => h.HeadingText == headingText).Distinct().Select(h => h.HeadingIndex).FirstOrDefault();

                HeadingModel headingModel = new HeadingModel(headingText, headingIndex);
                selectedHeadingModels.Add(headingModel);
            }

            return selectedHeadingModels;
        }

        private List<string> ExtractTextFromTable(List<HeadingModel> selectedHeadingModels, HtmlNode table)
        {
            List<string> extractedText = new List<string>();
            HtmlNodeCollection tableRowNodes = table.SelectNodes("//tr");
            
            foreach (HtmlNode tableRow in tableRowNodes)
            {
                string text = null;
                text = ExtractSelectedTextFromTableRow(selectedHeadingModels, tableRow);
                if(text.StartsWith(" - "))
                {
                    text = text.Substring(3);
                }
                extractedText.Add(text);
            }

            extractedText.RemoveAt(0);

            return extractedText;
        }

        private string ExtractSelectedTextFromTableRow(List<HeadingModel> selectedHeadingModels, HtmlNode tableRow)
        {
            string extractedText = string.Empty;
            
            for (int i = 0; i < selectedHeadingModels.Count; i++)
            {
                if(i == 0)
                {
                    //List<HtmlNode> nodes = tableRow.SelectNodes("//td").ToList();
                    //var shit = tableRow.ChildNodes[(selectedHeadingModels[i].HeadingIndex + 1)].InnerText;
                    //extractedText += tableRow.SelectNodes("//td")[selectedHeadingModels[i].HeadingIndex].InnerText;
                    extractedText += tableRow.ChildNodes[(selectedHeadingModels[i].HeadingIndex + 3)].InnerText;
                }
                else
                {
                    //TODO Parameterise/Configure seperator:
                    //extractedText += " - " + tableRow.SelectNodes("//td")[selectedHeadingModels[i].HeadingIndex].InnerText;
                    extractedText += " - " + tableRow.ChildNodes[(selectedHeadingModels[i].HeadingIndex + 2)].InnerText;
                }
            }

            return extractedText;
        }

        private string ConcatenatedText(List<string> rowsText)
        {
            string concatenatedText = string.Empty;

            foreach(string rowText in rowsText)
            {
                concatenatedText += rowText + Environment.NewLine;
            }

            return concatenatedText;
        }

        private string ConvertHtml(List<Headings> headingsToExtract, HtmlDocument document)
        {
            HtmlNode table = ExtractTableFromDocument(document);
            HtmlNodeCollection headings = ExtractTableHeadingsFromTable(table);
            List<HeadingModel> headingModels = ExtractHeadingIndexes(headings);
            List<HeadingModel> selectedHeadingModels = ExtractSelectedHeadingIndexes(headingsToExtract, headingModels);
            List<string> extractedText = ExtractTextFromTable(selectedHeadingModels, table);
            string convertedHtml = ConcatenatedText(extractedText);

            return convertedHtml;
        }
    }
}
