using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZXNTCount
{
    public enum FlagIndex
    {
        C = 0,
        N = 1,
        PV = 2,
        H = 3,
        Z = 4,
        S = 5
    };

    public enum FlagType
    {
        Unknown = 0,
        Unaffected,
        AffectedAsDefined,
        DetectsParity,
        DetectsOverflow,
        Set,
        Reset,
        Exceptional
    }

    class Z80Node : IComparable<Z80Node>
    {
        private string[] FlagStrings =
        {
            "Unknown",
            "Unaffected",
            "Affected As Defined",
            "Detects Parity",
            "Detects Overflow",
            "Set",
            "Reset",
            "Exceptional"
        };

        public int Index = 0;
        public int Grade = 0;
        public string OpCode;
        public string Name;
        public int Size;
        public int[] Time;
        public string Description;
        public FlagType[] Flags;
        public bool IsUndocumented;
        public bool IsNext;
        public Regex Regex;

        public Z80Node()
        {
        }

        public Z80Node(string opCode, string name, int size, int[] time, string description, FlagType[] flags, bool isUndocumented, bool isNext)
        {
            OpCode = opCode;
            Name = name;
            Size = size;
            Time = time;
            Description = description;
            Flags = flags;
            IsUndocumented = isUndocumented;
            IsNext = isNext;

            Initialize();
        }

        public void Initialize()
        {
            Regex = new Regex(RegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Grade = GetGrade();
        }

        public string RegexString
        {
            get
            {
                bool hasSpace = Name.Contains(" ");
                string retString = "";

                retString += Name;

                retString = retString.Replace("(", @"\(");
                retString = retString.Replace(")", @"\)");
                retString = retString.Replace("**", "##");
                retString = retString.Replace("*", "#");
                retString = retString.Replace("+#", @"(?<displacement>|[+-]#)");
                retString = retString.Replace("##", "(?<twoasterisks>.*)");
                retString = retString.Replace("#", "(?<oneasterisk>.*)");
                retString = retString.Replace(" ", @"[ \t]+)");
                retString = retString.Replace(",", @",[ \t]*");

                if (!hasSpace)
                    retString += ")";

                retString = retString.Insert(0, "^(?<mnemonic>");
                retString += "$";

                return retString;
            }
        }

        public void ProcessValue(ref StringBuilder stringBuilder, Group displacementGroup, Group asteriskGroup, string asteriskString)
        {
            for (int i = asteriskGroup.Captures.Count - 1; i >= 0; i--)
            {
                Capture asteriskCapture = asteriskGroup.Captures[i];
                string asteriskValue = asteriskCapture.Value;
                int startIndex = StringTools.IndexOf(stringBuilder, asteriskString);

                foreach (Capture displacementCapture in displacementGroup.Captures)
                {
                    string displacementValue = displacementGroup.Value;

                    if (displacementValue.Length == 0)
                        continue;

                    if (asteriskValue.Equals(displacementValue.Substring(1)))
                    {
                        asteriskValue = displacementValue;

                        if (asteriskValue.StartsWith("+"))
                            asteriskValue = asteriskValue.Substring(1);

                        break;
                    }
                }

                stringBuilder.Remove(startIndex, asteriskString.Length);
                stringBuilder.Insert(startIndex, asteriskValue);
            }
        }

        public bool GetInfo(string instruction, out string mnemonic, out string operands, out string description)
        {
            mnemonic = String.Empty;
            operands = String.Empty;
            description = Description;
            Match match = Regex.Match(instruction);

            if (match.Success)
            {
                StringBuilder stringBuilder = new StringBuilder(description);
                Group mnemonicGroup = match.Groups["mnemonic"];
                Group displacementGroup = match.Groups["displacement"];
                Group twoAsterisksGroup = match.Groups["twoasterisks"];
                Group oneAsteriskGroup = match.Groups["oneasterisk"];

                ProcessValue(ref stringBuilder, displacementGroup, twoAsterisksGroup, "**");
                ProcessValue(ref stringBuilder, displacementGroup, oneAsteriskGroup, "*");

                stringBuilder.Replace("*", "0");

                mnemonic = mnemonicGroup.Value.Trim();
                //operands = instruction.Substring(mnemonicGroup.Value.Length).Replace(", ", ",");
                operands = instruction.Substring(mnemonicGroup.Value.Length);
                description = stringBuilder.ToString();

                return true;
            }

            return false;
        }

        public int GetGrade()
        {
            int grade = !Name.Contains("(") ? 1 : 0; // no parentheses 1, parentheses 0
            grade += Name.Contains("+*") ? 2 : 0;   // ixy displacement is +2
            grade += Name.Contains("(*") ? 4 : 0;   // (**) addressing and (*) in/out is +4
            grade += Name.Contains(",*") ? 8 : 0;   // immediate arg2 is +8
            grade += Name.Contains(" *") ? 16 : 0;  // immediate arg1 is +16
            return grade;
        }

        public string FlagString
        {
            get
            {
                string retString = "";
                char[] flagArray = { ' ', '-', '+', 'P', 'V', '1', '0', '*' };

                for (int i = 0; i < Flags.Length; i++)
                    retString += flagArray[(int)Flags[i]];

                return retString;
            }
        }

        public string FlagArrayString
        {
            get
            {
                string retString = "new FlagType[] { ";

                for (int i = 0; i < Flags.Length; i++)
                {
                    retString += String.Format("FlagType.{0}", Flags[i]);

                    if (i < Flags.Length - 1)
                        retString += ", ";
                }

                retString += " }";

                return retString;
            }
        }

        public string FlagTextString
        {
            get
            {
                string[] retArray = new string[6];

                retArray[0] = String.Format("C: {0}", FlagStrings[(int)C]);
                retArray[1] = String.Format("N: {0}", FlagStrings[(int)N]);
                retArray[2] = String.Format("P/V: {0}", FlagStrings[(int)PV]);
                retArray[3] = String.Format("H: {0}", FlagStrings[(int)H]);
                retArray[4] = String.Format("Z: {0}", FlagStrings[(int)Z]);
                retArray[5] = String.Format("S: {0}", FlagStrings[(int)S]);

                return String.Join(Environment.NewLine, retArray);
            }
        }

        public string TimeArrayString
        {
            get
            {
                string retString = "new int[] { ";

                for (int i = 0; i < Time.Length; i++)
                {
                    retString += Time[i].ToString();

                    if (i < Time.Length - 1)
                        retString += ", ";
                }

                retString += " }";

                return retString;
            }
        }

        public string TimeString
        {
            get { return Time.Length == 1 ? Time[0].ToString() : String.Format("{0}/{1}", MinTime, MaxTime); }
        }

        public int MaxTime
        {
            get { return Time.Length == 1 ? Time[0] : Math.Max(Time[0], Time[1]); }
        }

        public int MinTime
        {
            get { return Time.Length == 1 ? Time[0] : Math.Min(Time[0], Time[1]); }
        }

        public string ToolTip
        {
            get
            {
                List<string> retList = new List<string>();

                retList.Add(String.Format("Opcode: {0}", OpCode));
                retList.Add(String.Format("Name: {0}", Name));
                retList.Add(String.Format("Size (bytes): {0}", Size));
                retList.Add(String.Format("Time (clock cycles): {0}", TimeString));
                retList.Add(FlagTextString);
                retList.Add(StringTools.WordWrap(Description, 30));

                return String.Join(Environment.NewLine, retList.ToArray());
            }
        }

        public void ReadIni(IniFile inifile, string section)
        {
            OpCode = inifile.Read(section, "OpCode");
            Name = inifile.Read(section, "Name");
            Size = inifile.Read<int>(section, "Size");
            Time = inifile.ReadArray<int>(section, "Time");
            Description = inifile.Read(section, "Description");
            Flags = inifile.ReadArray<FlagType>(section, "Flags");
            IsUndocumented = inifile.Read<bool>(section, "IsUndocumented");
            IsNext = inifile.Read<bool>(section, "IsNext");

            Initialize();
        }

        public void WriteIni(IniFile inifile, string section)
        {
            inifile.Write(section, "OpCode", OpCode);
            inifile.Write(section, "Name", Name);
            inifile.Write<int>(section, "Size", Size);
            inifile.WriteArray<int>(section, "Time", Time);
            inifile.Write(section, "Description", Description);
            inifile.WriteArray<FlagType>(section, "Flags", Flags);
            inifile.Write<bool>(section, "IsUndocumented", IsUndocumented);
            inifile.Write<bool>(section, "IsNext", IsNext);
        }

        public override string ToString()
        {
            return String.Format("new Z80Node(\"{0}\", \"{1}\", {2}, {3}, \"{4}\", {5}, {6}, {7}),", OpCode, Name, Size, TimeArrayString, Description, FlagArrayString, IsUndocumented.ToString().ToLower(), IsNext.ToString().ToLower());
        }

        public override bool Equals(object obj)
        {
            Z80Node other = (Z80Node)obj;

            if (!this.OpCode.Equals(other.OpCode))
                return false;
            if (!this.Name.Equals(other.Name))
                return false;
            if (!this.Size.Equals(other.Size))
                return false;
            if (!this.Time.SequenceEqual(other.Time))
                return false;
            if (!this.Description.Equals(other.Description))
                return false;
            if (!this.Flags.SequenceEqual(other.Flags))
                return false;
            if (!this.IsUndocumented.Equals(other.IsUndocumented))
                return false;
            if (!this.IsNext.Equals(other.IsNext))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Z80Node other)
        {
            //  [grade asc, length desc, lexicographic asc, index asc]
            if (this.Grade != other.Grade)
                return this.Grade.CompareTo(other.Grade);

            if (this.Name.Length != other.Name.Length)
                return -this.Name.Length.CompareTo(other.Name.Length);

            if (!this.Name.Equals(other.Name))
                return this.Name.CompareTo(other.Name);

            return this.Index.CompareTo(other.Index);
        }

        public FlagType C
        {
            get { return Flags[(int)FlagIndex.C]; }
        }

        public FlagType N
        {
            get { return Flags[(int)FlagIndex.N]; }
        }

        public FlagType PV
        {
            get { return Flags[(int)FlagIndex.PV]; }
        }

        public FlagType H
        {
            get { return Flags[(int)FlagIndex.H]; }
        }

        public FlagType Z
        {
            get { return Flags[(int)FlagIndex.Z]; }
        }
        public FlagType S
        {
            get { return Flags[(int)FlagIndex.S]; }
        }
    }
}
