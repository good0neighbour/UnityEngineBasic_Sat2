﻿using System;

namespace ClassUsageBasic
{
    internal class ClassUsageBasic
    {
        static void Main(string[] args)
        {
            SwordMan swordMan = new SwordMan();
            swordMan.SayName();
        }
    }
    class SwordMan
    {
        private int lv = 1;
        private float exp;
        private bool isAvaiable;
        private char gender;
        private string name;

        public SwordMan()
        {

        }

        ~SwordMan()
        {

        }

        public void SayName()
        {
            Console.WriteLine(name);
        }
    }
}
