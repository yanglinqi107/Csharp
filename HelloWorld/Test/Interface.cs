using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test
{
    public delegate double MyDelegate(double a);

    public delegate void EventHandler(object sender, EventArgs e);
    interface Runner
    {
        void run()
        {
            Console.WriteLine("interface");
        }
    }

    class Interface:Runner
    {
        public event EventHandler eventhandler;
        public void run()
        {
            Console.WriteLine("int");
        }

        public static void Main()
        {
            MyDelegate d = new MyDelegate(System.Math.Sqrt);
            double q = d(100);
            Console.WriteLine(q);
            Runner runner;
            Interface erface = new Interface();
            erface.run();
            runner = erface;
            runner.run();

            Directory.CreateDirectory("E:\\TEXT");
            bool exist = Directory.Exists("E:\\TEXT");
            Console.WriteLine(exist);
            string[] sd = Directory.GetDirectories("E:\\TEXT");
            foreach (string s in sd)
            {
                Console.WriteLine(s);
            }
            string[] sf = Directory.GetFiles("E:\\TEXT");
            foreach (string s in sf)
            {
                Console.WriteLine(s);
            }
        }
    }
}
