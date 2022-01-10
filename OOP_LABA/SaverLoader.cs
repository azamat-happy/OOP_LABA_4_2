using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace OOP_LABA
{
    class SaverLoader
    {
        public void Save(int num1, int num2, int num3)
        {
            string path = @"D:\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (FileStream fstream = new FileStream($"{path}\\note.txt", FileMode.Create))
            {
                string toWrite = num1.ToString() + " " + num2.ToString() + " " + num3.ToString();
                byte[] array = System.Text.Encoding.Default.GetBytes(toWrite);
                fstream.Write(array, 0, array.Length);
            }
        }

        public bool Load(out int num1, out int num2, out int num3)
        {
            num1 = 0;
            num2 = 0;
            num3 = 0;
            string path = @"D:\";

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                return false;
            }
            try
            {
                using (FileStream fstream = File.OpenRead($"{path}\\note.txt"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string textFromFile = System.Text.Encoding.Default.GetString(array);
                    string[] strNums = textFromFile.Split();
                    num1 = int.Parse(strNums[0]);
                    num2 = int.Parse(strNums[1]);
                    num3 = int.Parse(strNums[2]);
                    return true;
                }
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
    }
}
