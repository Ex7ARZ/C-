using System;
using System.Runtime.InteropServices;

namespace lab4._2
{
    internal static class NativeMethods
    {
       // [DllImport("Clab.dll")]
        [DllImport("MyLibrary.dll")]
        //internal static extern System.Int32 LabFunc(System.Int32 a);
        internal static extern  float f1t(float ne, float a, float b, float e);
    }

    class Program
    {
        //  [DllImport("MyLibrary.dll")]
        //  internal extern  float f1t(float ne, float a, float b, float e);

        // public extern float f2(float ne, float a, float b, float e);

        public static void Main(string[] args)
        {
           // System.Int32 s = NativeMethods.LabFunc(56);
           float s = NativeMethods.f1t(4, 2, 8, (float) 0.5);
            Console.Write(s);
        }
    }
}