using System;
using System.Runtime.InteropServices;

namespace ChangeTime
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }

    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now}");
            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = 2009;
            st.wMonth = 1;
            st.wDay = 1;
            st.wHour = 0;
            st.wMinute = 0;
            st.wSecond = 0;

            SetSystemTime(ref st);
            Console.WriteLine($"{DateTime.Now}");
        }
    }
}
