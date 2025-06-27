using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZXNTCount
{
    public partial class frmMain : Form
    {
        private BackgroundWorker m_backgroundWorker = new BackgroundWorker();
        private ListViewColumnSorter m_lvwColumnSorter;

        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = Text.Replace("[VERSION]", Globals.Version);
            m_backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            m_backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            m_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            m_backgroundWorker.WorkerReportsProgress = true;

            ReadInstructionsIni(Globals.FileNames.InstructionsIni);
            WriteInstructionIni(Globals.FileNames.InstructionsIni);

            //OutputTable();

            for (int i = 0; i < ZXN.Z80Array.Length; i++)
                ZXN.Z80Array[i].Index = i;

            Array.Sort(ZXN.Z80Array);

            ReadConfig(Globals.FileNames.ConfigIni);
        }

        private void OutputTable()
        {
            ParseZ80Table();

            foreach (Z80Node z80Node in ZXN.Z80Array)
                Console.WriteLine(z80Node.ToString());
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_backgroundWorker.IsBusy)
            {
                e.Cancel = true;
            }

            WriteConfig(Globals.FileNames.ConfigIni);
        }

        private void ReadInstructionsIni(string fileName)
        {
            if (!File.Exists(fileName))
                return;

            List<Z80Node> z80List = new List<Z80Node>();

            using (IniFile iniFile = new IniFile(fileName))
            {
                for (int i = 0; i < 2000; i++)
                {
                    string section = String.Format("Instruction_{0:0000}", i);

                    if (!iniFile.SectionDictionary.ContainsKey(section.ToLower()))
                        break;

                    Z80Node z80Node = new Z80Node();
                    z80Node.ReadIni(iniFile, section);

                    z80List.Add(z80Node);
                }
            }

            ZXN.Z80Array = z80List.ToArray();
        }

        private void WriteInstructionIni(string fileName)
        {
            if (File.Exists(fileName))
                return;

            using (IniFile iniFile = new IniFile(fileName))
            {
                for (int i = 0; i < ZXN.Z80Array.Length; i++)
                {
                    Z80Node z80Node = ZXN.Z80Array[i];

                    string section = String.Format("Instruction_{0:0000}", i);
                    z80Node.WriteIni(iniFile, section);
                }
            }
        }

        private FlagType[] ParseFlagString(string input)
        {
            char[] flagArray = { ' ', '-', '+', 'P', 'V', '1', '0', '*' };
            FlagType[] flags = new FlagType[6];

            for (int i = 0; i < input.Length; i++)
            {
                int index = Array.IndexOf(flagArray, input[i]);
                flags[i] = (index == -1 ? FlagType.Unknown : (FlagType)index);
            }

            return flags;
        }

        private void ParseZ80Table()
        {
            List<Z80Node> z80List = new List<Z80Node>();
            string[] lineArray = File.ReadAllLines(Path.Combine(Application.StartupPath, "z80table_zxn.htm"));
            Regex regEx;
            Match match;
            string title = null;
            int col = 0, row = 0;

            for (int i = 0; i < lineArray.Length; i++)
            {
                bool isUndocumented = false, isNext = false;
                string line = lineArray[i].Trim();
                regEx = new Regex("<table title=\"(?<title>(.*))\">");
                match = regEx.Match(line);

                if (match.Success)
                {
                    title = match.Groups["title"].Value;
                }

                regEx = new Regex("<th>(?<row>(.*))</th>");
                match = regEx.Match(line);

                if (match.Success)
                {
                    col = 0;
                    row = Convert.ToInt32(match.Groups["row"].Value, 16);
                }

                if (!line.StartsWith("<td"))
                    continue;

                if (line.Contains("class=\"un\" "))
                {
                    isUndocumented = true;
                    line = line.Replace("class=\"un\" ", "");
                }


                if (line.Contains("class=\"nn\" "))
                {
                    isNext = true;
                    line = line.Replace("class=\"nn\" ", "");
                }

                regEx = new Regex("<td axis=\"(?<flags>(.*))\\|(?<size>(.*))\\|(?<time>(.*))\\|(?<description>(.*))\">(?<name>(.*))</td>");
                match = regEx.Match(line);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    int size = Int32.Parse(match.Groups["size"].Value);
                    int[] time = null;
                    string timeString = match.Groups["time"].Value;
                    string description = System.Net.WebUtility.HtmlDecode(match.Groups["description"].Value);

                    description = description.Replace(@"""", @"\""");

                    FlagType[] flags = ParseFlagString(match.Groups["flags"].Value);

                    if (timeString.Contains("/"))
                    {
                        string[] timeSplit = timeString.Split(new char[] { '/' });
                        time = new int[] { Int32.Parse(timeSplit[0]), Int32.Parse(timeSplit[1]) };
                    }
                    else
                        time = new int[] { Int32.Parse(timeString) };

                    string opCode = title + ((byte)((row << 4) | col)).ToString("X2");

                    z80List.Add(new Z80Node(opCode, name, size, time, description, flags, isUndocumented, isNext));
                }

                col++;
            }

            z80List.Add(new Z80Node("87", "add a", 1, new int[] { 4 }, "Adds a to a.", new FlagType[] { FlagType.AffectedAsDefined, FlagType.AffectedAsDefined, FlagType.DetectsOverflow, FlagType.AffectedAsDefined, FlagType.AffectedAsDefined, FlagType.AffectedAsDefined }, false, false));
            z80List.Add(new Z80Node("C6", "add *", 2, new int[] { 7 }, "Adds * to a.", new FlagType[] { FlagType.AffectedAsDefined, FlagType.AffectedAsDefined, FlagType.DetectsOverflow, FlagType.AffectedAsDefined, FlagType.AffectedAsDefined, FlagType.AffectedAsDefined }, false, false));

            ZXN.Z80Array = z80List.ToArray();
        }

        private class WorkNode : ICloneable
        {
            public bool IsInstruction = false;

            public string Text = null;
            public string Instruction = null;
            public string Mnemonic = null;
            public string Operands = null;
            public string Comments = null;
            public string Description = null;

            public Z80Node Z80Node = null;
            public TextNode TextNode = null;

            public static int TotalMinTime = 0;
            public static int TotalMaxTime = 0;
            public static int TotalBytes = 0;

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        private void ProcessComments(List<TextNode> textList)
        {
            for (int i = textList.Count - 1; i >= 0; i--)
            {
                if (textList[i].TextType != TextType.Comment)
                    continue;

                bool foundMatch = false;

                foreach (TextNode textNode in textList)
                {
                    if (textList[i].Equals(textNode))
                        continue;

                    if (textNode.TextType != TextType.Comment &&
                        textNode.TextType != TextType.Unknown)
                        continue;

                    if (textList[i].LineNumber == textNode.LineNumber)
                    {
                        string comments = textList[i].Text;

                        if (comments.StartsWith("; "))
                            comments = comments.Substring(2);
                        else if (comments.StartsWith(";"))
                            comments = comments.Substring(1);

                        textNode.Comments = comments;

                        foundMatch = true;
                    }
                }

                if (foundMatch)
                    textList.RemoveAt(i);
            }
        }

        private List<TextNode> ProcesssAllText(string allText)
        {
            List<TextNode> textList = new List<TextNode>();
            StringBuilder stringBuilder = new StringBuilder();
            string[] textArray = StringTools.SplitString(allText, new string[] { " ", "\n", "\t", ":", ";" }, true, false);
            int startIndex = 0, lineNumber = 0;
            TextType textType = TextType.NewLine;

            foreach (string text in textArray)
            {
                bool isWhiteSpace = (text.Equals(" ") || text.Equals("\t"));
                bool isLineBreak = text.Equals(":");
                bool isComment = text.Equals(";");
                bool isNewLine = text.Equals("\n");

                if (startIndex > 0 && textType == TextType.NewLine)
                {
                    lineNumber++;
                }

                if (isNewLine)
                {
  
                    textList.Add(new TextNode(textType, lineNumber, startIndex, stringBuilder.ToString()));
                    startIndex += stringBuilder.Length;

                    stringBuilder.Clear();
                    stringBuilder.Append(text);

                    textType = TextType.NewLine;

                    continue;
                }

                if (isLineBreak)
                {
                    if (textType != TextType.Comment && textType != TextType.Label)
                    {
                        textList.Add(new TextNode(textType, lineNumber, startIndex, stringBuilder.ToString()));
                        startIndex += stringBuilder.Length;

                        stringBuilder.Clear();
                        stringBuilder.Append(text);

                        textType = TextType.LineBreak;

                        continue;
                    }
                }

                if (isComment)
                {
                    if (textType != TextType.Comment)
                    {
                        textList.Add(new TextNode(textType, lineNumber, startIndex, stringBuilder.ToString()));
                        startIndex += stringBuilder.Length;

                        stringBuilder.Clear();
                        stringBuilder.Append(text);

                        textType = TextType.Comment;

                        continue;
                    }
                }

                if (isWhiteSpace)
                {
                    if (textType == TextType.NewLine || textType == TextType.Label)
                    {
                        textList.Add(new TextNode(textType, lineNumber, startIndex, stringBuilder.ToString()));
                        startIndex += stringBuilder.Length;

                        stringBuilder.Clear();
                        stringBuilder.Append(text);

                        textType = TextType.Whitespace;

                        continue;
                    }
                }
                else
                {
                    if (textType != TextType.Unknown && textType != TextType.Comment && textType != TextType.Label)
                    {
                        textList.Add(new TextNode(textType, lineNumber, startIndex, stringBuilder.ToString()));
                        startIndex += stringBuilder.Length;

                        stringBuilder.Clear();
                        stringBuilder.Append(text);

                        textType = (textType == TextType.NewLine ? TextType.Label : TextType.Unknown);

                        continue;
                    }
                }

                stringBuilder.Append(text);
            }

            if (stringBuilder.Length > 0)
            {
                textList.Add(new TextNode(textType, lineNumber, startIndex, stringBuilder.ToString()));
            }

            ProcessComments(textList);

            return textList;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            WorkNode workNode = (WorkNode)e.Argument;
            List<TextNode> textList = ProcesssAllText(workNode.Text);
            string instructionSeperator = (Settings.InstructionSeparator == SpaceType.Space ? " " : "\t");

            for (int i = 0; i < textList.Count; i++)
            {
                TextNode textNode = textList[i];
                int percentage = (int)Math.Round(((float)i + 1) / textList.Count * 100);
                string instruction = textList[i].Text;
                bool foundMatch = false;

                if (textNode.TextType != TextType.Unknown &&
                    textNode.TextType != TextType.Label &&
                     textNode.TextType != TextType.Comment)
                    continue;

                foreach (Z80Node z80Node in ZXN.Z80Array)
                {
                    Match match = z80Node.Regex.Match(instruction);

                    if (match.Success)
                    {
                        workNode.IsInstruction = true;
                        workNode.Z80Node = z80Node;
                        workNode.TextNode = textNode;
                        z80Node.GetInfo(instruction, out workNode.Mnemonic, out workNode.Operands, out workNode.Description);
                        workNode.Instruction = String.Format("{0}{1}{2}", workNode.Mnemonic, instructionSeperator, workNode.Operands);
                        workNode.Comments = textNode.Comments;
                        WorkNode.TotalMinTime += z80Node.MinTime;
                        WorkNode.TotalMaxTime += z80Node.MaxTime;
                        WorkNode.TotalBytes += z80Node.Size;

                        m_backgroundWorker.ReportProgress(percentage, workNode.Clone());

                        foundMatch = true;

                        break;
                    }
                }

                if (!foundMatch)
                {
                    workNode.IsInstruction = false;
                    workNode.Z80Node = null;
                    workNode.TextNode = textNode;
                    workNode.Instruction = instruction;
                    workNode.Comments = textNode.Comments;

                    m_backgroundWorker.ReportProgress(percentage, workNode.Clone());
                }
            }

            e.Result = workNode;
        }

        private string GetInstructionText(List<WorkNode> workList, WorkNode workNode)
        {
            Z80Node z80Node = workNode.Z80Node;
            TextNode textNode = workNode.TextNode;
            int totalMinTime = 0, totalMaxTime, totalBytes = 0;
            string totalTimeString = "";
            string instructions = null;

            if (TryGetInstructions(workList, workNode, out instructions, out totalMinTime, out totalMaxTime, out totalBytes))
            {
                totalTimeString = (totalMinTime != totalMaxTime ? String.Format("{0}/{1}T", totalMinTime, totalMaxTime) : String.Format("{0}T", totalMinTime));
            }
            else
            {
                instructions = workNode.Instruction;

                if (z80Node != null)
                {
                    totalBytes = z80Node.Size;
                    totalTimeString = String.Format(" {0,2}T", z80Node.TimeString);
                }
            }

            string text = null;
            string comments = "";

            if (z80Node != null && workNode.IsInstruction)
            {
                if (Settings.TCount)
                    comments += totalTimeString;

                if (Settings.ByteCount)
                    comments += String.Format(" {0}B", totalBytes);

                if (Settings.Flags)
                    comments += String.Format(" {0}", z80Node.FlagString);

                if (Settings.Comments)
                    comments += String.Format(" {0}", workNode.Comments);

                if (Settings.Description)
                    comments += String.Format(" {0}", z80Node.Description);
            }

            if (workNode.IsInstruction)
            {
                if (!String.IsNullOrEmpty(comments))
                {
                    text = String.Format("{0}{1,-30} {2}", GetIndentString(), instructions, comments.Insert(0, "; ").Trim());
                }
                else
                {
                    text = String.Format("{0}{1,-30} ", GetIndentString(), instructions);
                }
            }
            else
            {
                text = instructions;
            }

            return text;
        }

        private void SetLabelTotals(int totalMinTime, int totalMaxTime, int totalBytes)
        {
            tsslTotalTCount.Text = String.Format("Total Time (clock cycles): {0}", totalMinTime != totalMaxTime ? String.Format("{0}/{1}", totalMinTime, totalMaxTime) : totalMinTime.ToString());
            tsslTotalBytes.Text = String.Format("Total Bytes: {0}", totalBytes);
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                WorkNode workNode = (WorkNode)e.UserState;
                Z80Node z80Node = workNode.Z80Node;
                TextNode textNode = workNode.TextNode;
                ListViewItem listViewItem = null;

                if (z80Node != null)
                {
                    listViewItem = new ListViewItem(new string[] { workNode.Instruction.Replace("\t", " "), z80Node.TimeString, z80Node.Size.ToString(), z80Node.FlagString, workNode.Comments, workNode.Description });

                    if (z80Node.IsUndocumented)
                        listViewItem.BackColor = Color.LightPink;
                    else if (z80Node.IsNext)
                        listViewItem.BackColor = Color.LightCyan;
                    else
                        listViewItem.BackColor = SystemColors.Window;
                }
                else
                    listViewItem = new ListViewItem(new string[] { workNode.Instruction.Replace("\t", " "), String.Empty, String.Empty, String.Empty, workNode.Comments, String.Empty });

                listViewItem.Tag = workNode;

                tspbProcessing.Value = e.ProgressPercentage;

                lvwTable.Items.Add(listViewItem);
                //listViewItem.EnsureVisible();
            }));
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                WorkNode workNode = (WorkNode)e.Result;
                Z80Node z80Node = workNode.Z80Node;

                SetLabelTotals(WorkNode.TotalMinTime, WorkNode.TotalMaxTime, WorkNode.TotalBytes);

                for (int i = 0; i < lvwTable.Columns.Count; i++)
                {
                    if (i == 0 || i == 4)
                        continue;

                    lvwTable.Columns[i].Width = -2;
                }
            }));
        }

        private void rtbSource_TextChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void HighlightOpcode(TextNode textNode, WorkNode workNode)
        {
            if (textNode == null)
                return;

            /* if (workNode != null && workNode.Mnemonic != null)
            {
                rtbSource.Select(textNode.StartIndex, workNode.Mnemonic.Length);
                rtbSource.SelectionColor = Color.Orange;
                rtbSource.SelectionBackColor = SystemColors.Highlight;

                rtbSource.Select(textNode.StartIndex + workNode.Mnemonic.Length, textNode.Text.Length - workNode.Mnemonic.Length);
                rtbSource.SelectionColor = Color.OrangeRed;
                rtbSource.SelectionBackColor = SystemColors.Highlight;
            }
            else */

            rtbSource.Select(textNode.StartIndex, textNode.Text.Length);
            rtbSource.SelectionColor = SystemColors.HighlightText;
            rtbSource.SelectionBackColor = SystemColors.Highlight;

            if (!rtbSource.ClientRectangle.Contains(rtbSource.GetPositionFromCharIndex(rtbSource.SelectionStart)))
                rtbSource.ScrollToCaret();
        }

        private void ClearOpcodes()
        {
            int selectionStart = rtbSource.SelectionStart;
            rtbSource.SelectAll();
            rtbSource.SelectionColor = Color.Black;
            rtbSource.SelectionBackColor = rtbSource.BackColor;
            rtbSource.SelectionStart = selectionStart;
            rtbSource.SelectionLength = 0;
        }

        private void ReadConfig(string fileName)
        {
            FileIO.ReadFormState(fileName, this);

            using (IniFile iniFile = new IniFile(fileName))
            {
                tscbTCount.Checked = iniFile.Read<bool>("General", "TCount", true);
                tscbByteCount.Checked = iniFile.Read<bool>("General", "ByteCount", false);
                tscbFlags.Checked = iniFile.Read<bool>("General", "Flags", false);
                tscbComments.Checked = iniFile.Read<bool>("General", "Comments", true);
                tscbDescription.Checked = iniFile.Read<bool>("General", "Description", false);

                Settings.InstructionSeparator = iniFile.Read<SpaceType>("Settings", "InstructionSeparator", SpaceType.Space);
                Settings.IndentType = iniFile.Read<SpaceType>("Settings", "IndentType", SpaceType.Space);
                Settings.IndentSpaceCount = iniFile.Read <int>("Settings", "IndentSpaceCount", 4);

                rtbSource.Text = StringTools.DecodeBase64(iniFile.Read("General", "Source", StringTools.EncodeBase64("")));
            }
        }

        private void WriteConfig(string fileName)
        {
            FileIO.WriteFormState(fileName, this);

            using (IniFile iniFile = new IniFile(fileName))
            {
                iniFile.Write<bool>("General", "TCount", tscbTCount.Checked);
                iniFile.Write<bool>("General", "ByteCount", tscbByteCount.Checked);
                iniFile.Write<bool>("General", "Flags", tscbFlags.Checked);
                iniFile.Write<bool>("General", "Comments", tscbComments.Checked);
                iniFile.Write<bool>("General", "Description", tscbDescription.Checked);

                iniFile.Write<SpaceType>("Settings", "InstructionSeparator", Settings.InstructionSeparator);
                iniFile.Write<SpaceType>("Settings", "IndentType", Settings.IndentType);
                iniFile.Write<int>("Settings", "IndentSpaceCount", Settings.IndentSpaceCount);

                iniFile.Write("General", "Source", StringTools.EncodeBase64(rtbSource.Text));
            }
        }

        private void lvwTable_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo listViewHitTestInfo = lvwTable.HitTest(e.X, e.Y);

            if (listViewHitTestInfo.Item != null && listViewHitTestInfo.SubItem != null)
            {
                ListViewItem listViewItem = listViewHitTestInfo.Item;
                ListViewItem.ListViewSubItem listViewSubItem = listViewHitTestInfo.SubItem;
                WorkNode workNode = (WorkNode)listViewItem.Tag;
                Z80Node z80Node = workNode.Z80Node;

                if (z80Node != null)
                {
                    lvwTable.ShowItemToolTips = true;
                    listViewItem.ToolTipText = z80Node.ToolTip;
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem toolStripItem = (ToolStripItem)e.ClickedItem;

            if (toolStripItem.Text == "Reload")
            {
                Reload();
            }
            else if (toolStripItem.Text == "Cut")
            {
                CopySelectedItemsToClipboard(true, true);
            }
            else if (toolStripItem.Text == "Copy")
            {
                CopySelectedItemsToClipboard(false, true);
            }
            else if (toolStripItem.Text == "Delete")
            {
                CopySelectedItemsToClipboard(true, false);
            }
        }

        private void lvwTable_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != lvwTable)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                CopySelectedItemsToClipboard(true, false);

                return;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.X:
                        CopySelectedItemsToClipboard(true, true);
                        break;
                    case Keys.C:
                        CopySelectedItemsToClipboard(false, true);
                        break;
                    case Keys.A:
                        SelectAll();
                        break;
                    case Keys.N:
                        SelectNone();
                        break;
                }
            }
        }

        private void ReadText(string fileName)
        {
            rtbSource.Text = File.ReadAllText(fileName);
        }

        private void WriteText(string fileName)
        {
            string text = GetInstructionText(false, false);

            File.WriteAllText(fileName, text);
        }

        private void Reload()
        {
            if (m_backgroundWorker.IsBusy)
                return;

            m_lvwColumnSorter = new ListViewColumnSorter();
            lvwTable.ListViewItemSorter = m_lvwColumnSorter;

            WorkNode.TotalMinTime = 0;
            WorkNode.TotalMaxTime = 0;
            WorkNode.TotalBytes = 0;

            WorkNode workNode = new WorkNode();
            workNode.Text = rtbSource.Text;
            Settings.TCount = tscbTCount.Checked;
            Settings.ByteCount = tscbByteCount.Checked;
            Settings.Flags = tscbFlags.Checked;
            Settings.Comments = tscbComments.Checked;
            Settings.Description = tscbDescription.Checked;

            lvwTable.Items.Clear();

            m_backgroundWorker.RunWorkerAsync(workNode);
        }

        private void SelectAll()
        {
            lvwTable.BeginUpdate();

            foreach (ListViewItem listViewItem in lvwTable.Items)
                listViewItem.Selected = true;

            lvwTable.EndUpdate();
        }

        private void SelectNone()
        {
            lvwTable.BeginUpdate();

            foreach (ListViewItem listViewItem in lvwTable.Items)
                listViewItem.Selected = false;

            lvwTable.EndUpdate();

            ClearOpcodes();
        }

        private bool TryGetInstructions(List<WorkNode> workList, WorkNode workNode, out string instructions, out int totalMinTime, out int totalMaxTime, out int totalBytes)
        {
            instructions = null;
            totalMinTime = 0;
            totalMaxTime = 0;
            totalBytes = 0;

            if (!workNode.IsInstruction)
                return false;

            List<string> instructionList = new List<string>();
            bool foundMatch = false;

            for (int i = workList.Count - 1; i >= 0; i--)
            {
                Z80Node z80Node = workList[i].Z80Node;

                if (!workList[i].IsInstruction)
                    continue;

                if (workList[i].TextNode.LineNumber == workNode.TextNode.LineNumber)
                {
                    totalMinTime += z80Node.MinTime;
                    totalMaxTime += z80Node.MaxTime;
                    totalBytes += z80Node.Size;

                    instructionList.Insert(0, workList[i].Instruction);

                    if (!workList[i].Equals(workNode))
                    {
                        workList.RemoveAt(i);
                    }

                    foundMatch = true;
                }
            }

            instructions = String.Join(" : ", instructionList.ToArray());

            return foundMatch;
        }

        private string GetInstructionText(bool selectedItems, bool removeItem)
        {
            List<WorkNode> workList = new List<WorkNode>();
            List<string> instructionList = new List<string>();
            IList<ListViewItem> listViewItemList = (IList<ListViewItem>)(selectedItems ? lvwTable.SelectedItems.Cast<ListViewItem>().ToList() : lvwTable.Items.Cast<ListViewItem>().ToList());
            int totalMinTime = 0, totalMaxTime = 0, totalBytes = 0;

            lvwTable.BeginUpdate();

            foreach (ListViewItem listViewItem in listViewItemList)
                workList.Add((WorkNode)listViewItem.Tag);

            for (int i = listViewItemList.Count - 1; i >= 0; i--)
            {
                int percentage = (int)Math.Round((float)(listViewItemList.Count - i) / listViewItemList.Count * 100);

                tspbProcessing.Value = percentage;

                ListViewItem listViewItem = listViewItemList[i];
                WorkNode workNode = (WorkNode)listViewItem.Tag;
                Z80Node z80Node = workNode.Z80Node;

                if (workList.Contains(workNode))
                {
                    instructionList.Insert(0, GetInstructionText(workList, workNode));

                    workList.Remove(workNode);
                }

                if (removeItem)
                    lvwTable.Items.Remove(listViewItem);

                if (!workNode.IsInstruction)
                    continue;

                totalMinTime += z80Node.MinTime;
                totalMaxTime += z80Node.MaxTime;
                totalBytes += z80Node.Size;
            }

            lvwTable.EndUpdate();

            string totalText = String.Format("{0}{1,-30} ;", GetIndentString(), "");

            if (tscbTCount.Checked)
                totalText += (totalMinTime != totalMaxTime ? String.Format(" = {0}/{1}T", totalMinTime, totalMaxTime) : String.Format(" = {0}T", totalMinTime));

            if (tscbByteCount.Checked)
                totalText += String.Format(" {0}B", totalBytes);

            instructionList.Add(totalText);

            return String.Join(Environment.NewLine, instructionList.ToArray());
        }

        private void CopySelectedItemsToClipboard(bool removeItem, bool copyToClipboard)
        {
            if (lvwTable.SelectedItems.Count == 0)
                return;

            string text = GetInstructionText(true, removeItem);

            if (copyToClipboard)
                Clipboard.SetText(text);
        }

        public string GetIndentString()
        {
            return (Settings.IndentType == SpaceType.Space ? "".PadLeft(Settings.IndentSpaceCount) : "\t");
        }

        private void rtbSource_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;

            int charIndex = rtbSource.GetCharIndexFromPosition(e.Location);
            ListViewItem selectedListViewItem = null;

            for (int i = 0; i < lvwTable.Items.Count; i++)
            {
                ListViewItem listViewItem = lvwTable.Items[i];
                WorkNode workNode = (WorkNode)listViewItem.Tag;
                TextNode textNode = workNode.TextNode;

                if (textNode == null)
                    continue;

                if (charIndex < textNode.StartIndex || charIndex > textNode.StartIndex + textNode.Text.Length)
                    continue;

                selectedListViewItem = listViewItem;
            }

            if (selectedListViewItem != null)
            {
                lvwTable.SelectedIndices.Clear();
                selectedListViewItem.Selected = true;
                selectedListViewItem.EnsureVisible();
            }
        }

        bool m_selectionChangeHandled = false;

        private void lvwTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_selectionChangeHandled)
            {
                m_selectionChangeHandled = true;
                Application.Idle += OnSelectionChangeDone;
            }
        }

        private void OnSelectionChangeDone(object sender, EventArgs e)
        {
            Application.Idle -= OnSelectionChangeDone;
            m_selectionChangeHandled = false;

            lvwTable_MouseDown(sender, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }

        private void lvwTable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (lvwTable.SelectedItems.Count == 0)
                return;

            rtbSource.TextChanged -= rtbSource_TextChanged;

            ClearOpcodes();

            int totalMinTime = 0, totalMaxTime = 0, totalBytes = 0;

            for (int i = 0; i < lvwTable.SelectedItems.Count; i++)
            {
                ListViewItem listViewItem = lvwTable.SelectedItems[i];
                WorkNode workNode = (WorkNode)listViewItem.Tag;
                Z80Node z80Node = workNode.Z80Node;
                TextNode textNode = workNode.TextNode;

                if (z80Node != null)
                {
                    totalMinTime += z80Node.MinTime;
                    totalMaxTime += z80Node.MaxTime;
                    totalBytes += z80Node.Size;
                }

                HighlightOpcode(textNode, workNode);
            }

            SetLabelTotals(totalMinTime, totalMaxTime, totalBytes);

            rtbSource.TextChanged += rtbSource_TextChanged;
        }

        private void lvwTable_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == m_lvwColumnSorter.SortColumn)
            {
                if (m_lvwColumnSorter.Order == SortOrder.Ascending)
                    m_lvwColumnSorter.Order = SortOrder.Descending;
                else
                    m_lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                m_lvwColumnSorter.SortColumn = e.Column;
                m_lvwColumnSorter.Order = SortOrder.Ascending;
            }

            lvwTable.Sort();
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;

            if (toolStripMenuItem.Text == "Reload")
            {
                Reload();
            }
            else if (toolStripMenuItem.Text == "Cut")
            {
                CopySelectedItemsToClipboard(true, true);
            }
            else if (toolStripMenuItem.Text == "Copy")
            {
                CopySelectedItemsToClipboard(false, true);
            }
            else if (toolStripMenuItem.Text == "Delete")
            {
                CopySelectedItemsToClipboard(true, false);
            }
            else if (toolStripMenuItem.Text == "Options")
            {
                using (frmOptions frmOptions = new frmOptions())
                {
                    if (frmOptions.ShowDialog(this) == DialogResult.OK)
                    {
                        WriteConfig(Globals.FileNames.ConfigIni);

                        Reload();
                    }
                }
            }
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = (ToolStripButton)sender;

            if (toolStripButton.Text == "Reload")
            {
                Reload();
            }
            else if (toolStripButton.Text == "Cut")
            {
                CopySelectedItemsToClipboard(true, true);
            }
            else if (toolStripButton.Text == "Copy")
            {
                CopySelectedItemsToClipboard(false, true);
            }
            else if (toolStripButton.Text == "Paste")
            {
                rtbSource.Text = Clipboard.GetText();
            }
            else if (toolStripButton.Text == "Select All")
            {
                SelectAll();
            }
            else if (toolStripButton.Text == "Select None")
            {
                SelectNone();
            }
            else if (toolStripButton.Text == "Delete")
            {
                CopySelectedItemsToClipboard(true, false);
                //rtbSource.Text = String.Empty;
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TryOpenFile(this, null, null, "Z80 Assembly Files", new string[] { ".s", ".asm" }, out fileName))
            {
                ReadText(fileName);
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TrySaveFile(this, null, null, "Z80 Assembly Files", new string[] { ".s", ".asm" }, out fileName))
            {
                WriteText(fileName);
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            using (frmAbout frmAbout = new frmAbout())
                frmAbout.ShowDialog(this);
        }

        private bool TryGetFileName(out string fileName, DragEventArgs e)
        {
            fileName = null;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;

                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        fileName = ((string[])data)[0];

                        return true;
                    }
                }
            }

            return false;
        }

        private void rtbSource_DragEnter(object sender, DragEventArgs e)
        {
            string fileName = null;

            if (TryGetFileName(out fileName, e))
            {
                ReadText(fileName);
            }
        }
    }
}
