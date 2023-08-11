using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZXNTCount
{
    class FileIO
    {
        public static bool TryOpenFile(Form owner, string initialDirectory, string initialFileName, string fileFormat, string[] extensions, out string fileName)
        {
            fileName = null;

            try
            {
                OpenFileDialog fd = new OpenFileDialog();

                fd.Title = "Open File";
                fd.InitialDirectory = initialDirectory;
                fd.FileName = initialFileName;
                fd.Filter = String.Format("{0} ({1})|*{2}|All Files (*.*)|*.*", fileFormat, String.Join(",", extensions).Replace(".", "").ToUpper(), String.Join(";*", extensions));
                fd.RestoreDirectory = true;
                fd.CheckFileExists = true;

                if (fd.ShowDialog(owner) == DialogResult.OK)
                {
                    fileName = fd.FileName;

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public static bool TrySaveFile(Control parent, string initialDirectory, string initialFileName, string fileFormat, string[] extensions, out string fileName)
        {
            fileName = null;

            try
            {
                SaveFileDialog fd = new SaveFileDialog();

                fd.Title = "Save Layout";
                fd.InitialDirectory = initialDirectory;
                fd.FileName = initialFileName;
                fd.Filter = String.Format("{0} ({1})|*{2}|All Files (*.*)|*.*", fileFormat, String.Join(",", extensions).Replace(".", "").ToUpper(), String.Join(";*", extensions));
                fd.OverwritePrompt = false;
                fd.RestoreDirectory = true;

                if (fd.ShowDialog(parent) == DialogResult.OK)
                {
                    fileName = fd.FileName;

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public static void ReadFormState(string fileName, Form form)
        {
            using (IniFile iniFile = new IniFile(fileName))
            {
                form.Size = iniFile.Read<Size>(form.Name, "Size", form.Size);
                form.Location = iniFile.Read<Point>(form.Name, "Location", form.Location);
                form.WindowState = iniFile.Read<FormWindowState>(form.Name, "WindowState", form.WindowState);
            }
        }

        public static void WriteFormState(string fileName, Form form)
        {
            using (IniFile iniFile = new IniFile(fileName))
            {
                iniFile.Write<FormWindowState>(form.Name, "WindowState", form.WindowState);

                if (form.WindowState == FormWindowState.Normal)
                {
                    iniFile.Write<Size>(form.Name, "Size", form.Size);
                    iniFile.Write<Point>(form.Name, "Location", form.Location);
                }
                else
                {
                    iniFile.Write<Size>(form.Name, "Size", form.RestoreBounds.Size);
                    iniFile.Write<Point>(form.Name, "Location", form.RestoreBounds.Location);
                }
            }
        }
    }
}
