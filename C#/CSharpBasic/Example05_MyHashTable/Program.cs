using System;

namespace Example05_MyHashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<string, int> myHashTable = new MyHashTable<string,int>();
            myHashTable.Add("철수", 90);
            myHashTable.Add("영희", 80);
            myHashTable.Remove("영희");
        }
    }
}
