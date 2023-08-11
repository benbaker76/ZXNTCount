using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZXNTCount
{
    public enum SpaceType
    {
        Space,
        Tab
    };

    class Globals
    {
        public static string Version = "v1.1.5";

        public class FileNames
        {
            public static string ConfigIni = Path.Combine(Application.StartupPath, "ZXNTCount.ini");
            public static string InstructionsIni = Path.Combine(Application.StartupPath, "Instructions.ini");
        }
    }

    public class Settings
    {
        public static bool TCount = true;
        public static bool ByteCount = false;
        public static bool Flags = false;
        public static bool Comments = true;
        public static bool Description = false;

        public static SpaceType InstructionSeparator = SpaceType.Space;
        public static SpaceType IndentType = SpaceType.Space;
        public static int IndentSpaceCount = 4;
    }
}
