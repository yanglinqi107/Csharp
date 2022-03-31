using System;

namespace test
{
    class Program
    {
        static void Main(String[] args)
        {
            int a = 10;
            ClassA A = new ClassA();
            ClassB B = new ClassB();
            Console.WriteLine("a={0}", a);
            A.MyMethod(a);
            B.MyMethod(a);
        }
    }
}
