using System;

namespace Factorial_serise
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n;
            try
            {
                Console.WriteLine("输入一个整数：");
                n = checked(int.Parse(Console.ReadLine()));
                int i = 1;
                int temp = 1;
                int sum = 0;
                while(i<= n)
                {
                    temp = checked(temp * i);
                    sum = checked(temp + sum) ;
                    ++i;
                }
                Console.WriteLine(sum);
            }catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
