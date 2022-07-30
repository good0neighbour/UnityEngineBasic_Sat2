using System;

namespace Methods
{
    internal class Methods
    {
        static void Main(string[] args)
        {
            PrintHelloWorld();
            PrintString("안녕");
            int num = PrintStringWithReturningLength("안녕못해");
            Console.WriteLine(num);
        }
        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
        static void PrintString(string target)
        {
            Console.WriteLine(target);
        }
        static int PrintStringWithReturningLength(string target)
        {
            int num = target.Length;
            Console.WriteLine(target);
            return num;
        }
    }
}
