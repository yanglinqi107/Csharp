using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    class ClassB:ClassA
    {
        public override int MyMethod(int a)
        {
            a += 50;
            Console.WriteLine("B:a="+ a);
            return a;
        }
    }
}

