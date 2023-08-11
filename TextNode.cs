using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXNTCount
{
    public enum TextType
    {
        Unknown,
        Whitespace,
        NewLine,
        LineBreak,
        Label,
        Comment
    };

    class TextNode
    {
        public TextType TextType;
        public int LineNumber;
        public int StartIndex;
        public string Text;
        public string Comments;

        public TextNode(TextType textType, int lineNumber, int startIndex, string text)
        {
            TextType = textType;
            LineNumber = lineNumber;
            StartIndex = startIndex;
            Text = text.Trim();
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} '{3}'", TextType, LineNumber, StartIndex, Text);
        }
    }
}
