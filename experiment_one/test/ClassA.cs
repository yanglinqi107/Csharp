using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
     class ClassA
    {
        public virtual int MyMethod(int a)
        {
            a += 10;
            Console.WriteLine("A:a=" + a);
            return a;
        }
    }
}


