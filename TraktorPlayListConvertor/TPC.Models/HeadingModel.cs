using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC.Models
{
    public class HeadingModel
    {
        public string HeadingText { get; set; }

        public int HeadingIndex { get; set; }

        public HeadingModel()
        {

        }

        public HeadingModel(string headingText, int headingIndex)
        {
            HeadingText = headingText;
            HeadingIndex = headingIndex;
        }
    }
}
