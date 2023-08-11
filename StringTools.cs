using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXNTCount
{
    public class StringTools
    {
        public static int IndexOf(StringBuilder stringBuilder, string value)
        {
            if (stringBuilder == null)
                throw new ArgumentNullException("stringBuilder");

            if (value == null)
                value = string.Empty;

            for (int i = 0; i < stringBuilder.Length; i++)
            {
                int j;
                for (j = 0; j < value.Length && i + j < stringBuilder.Length && stringBuilder[i + j] == value[j]; j++) ;
                if (j == value.Length)
                    return i;
            }

            return -1;
        }

        /* public static Tuple<int, string>[] SplitString(string input, string[] separatorArray, bool includeSeparators, bool ignoreCase)
        {
            List<Tuple<int, string>> retList = new List<Tuple<int, string>>();
            int length = input.Length;
            int lastMatchEnd = 0;
            int matchIndex = 0;
            string matchString = null;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < separatorArray.Length; j++)
                {
                    string seperatorString = separatorArray[j];
                    int seperatorLength = seperatorString.Length;

                    if (String.Compare(input, i, seperatorString, 0, seperatorLength, ignoreCase) == 0)
                    {
                        matchIndex = lastMatchEnd;
                        matchString = input.Substring(matchIndex, i - matchIndex);
                        retList.Add(new Tuple<int, string>(matchIndex, matchString));

                        if (includeSeparators)
                        {
                            matchIndex = lastMatchEnd + matchString.Length;
                            matchString = input.Substring(matchIndex, seperatorLength);
                            retList.Add(new Tuple<int, string>(matchIndex, matchString));
                        }

                        i += seperatorLength - 1;
                        lastMatchEnd = i + 1;
                        break;
                    }
                }
            }

            if (lastMatchEnd != length)
            {
                matchIndex = lastMatchEnd;
                matchString = input.Substring(matchIndex);
                retList.Add(new Tuple<int, string>(matchIndex, matchString));
            }

            return retList.ToArray();
        } */

        public static string[] SplitString(string input, string[] separatorArray, bool includeSeparators, bool ignoreCase)
        {
            List<string> retList = new List<string>();
            int length = input.Length;
            int lastMatchEnd = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < separatorArray.Length; j++)
                {
                    string seperatorString = separatorArray[j];
                    int seperatorLength = seperatorString.Length;

                    if (String.Compare(input, i, seperatorString, 0, seperatorLength, ignoreCase) == 0)
                    {
                        string matchString = input.Substring(lastMatchEnd, i - lastMatchEnd);

                        if (matchString.Length != 0)
                            retList.Add(matchString);

                        if (includeSeparators)
                            retList.Add(input.Substring(lastMatchEnd + matchString.Length, seperatorLength));

                        i += seperatorLength - 1;
                        lastMatchEnd = i + 1;
                        break;
                    }
                }
            }

            if (lastMatchEnd != length)
                retList.Add(input.Substring(lastMatchEnd));

            return retList.ToArray();
        }

        public static string WordWrap(string sText, int iMaxLength)
        {
            if (String.IsNullOrEmpty(sText))
                return sText;

            string sWrappedText = "";
            string sLine = "";

            while (sText.Length > 0)
            {
                if (sText.Length >= iMaxLength)
                {
                    sLine = sText.Substring(0, iMaxLength);

                    if (sLine.LastIndexOf(" ") == -1 && sLine.LastIndexOf("\r") == -1)
                    {
                        sText.Insert(iMaxLength - Environment.NewLine.Length, Environment.NewLine);
                        sLine = sText.Substring(0, iMaxLength);
                        sWrappedText += sLine + Environment.NewLine;
                    }
                    else
                    {
                        if (sLine.EndsWith(" ") == false)
                            sLine = sLine.Substring(0, 1 + sLine.LastIndexOf(" "));

                        if (sLine.LastIndexOf("\r") != -1)
                        {
                            if (sLine.EndsWith("\n") == false)
                                sLine = sLine.Substring(0, 1 + sLine.LastIndexOf("\r"));
                            sWrappedText += sLine;
                        }
                        else
                        {
                            if (sLine.Length == 0)
                                sLine = sText;

                            sWrappedText += sLine + Environment.NewLine;
                        }
                    }
                }
                else
                {
                    sLine = sText;
                    sWrappedText += sLine;
                }

                sText = sText.Substring(sLine.Length);
            }

            return sWrappedText;
        }

        public static string EncodeBase64(string value)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(valueBytes);
        }

        public static string DecodeBase64(string value)
        {
            byte[] valueBytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }
    }
}
