using System;

namespace BitmapConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Converter.ConvertBitmapToByte();
                Console.WriteLine("Completed!");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
