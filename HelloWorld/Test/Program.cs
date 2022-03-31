using System;

namespace Test
{
    abstract class T1
    {
		protected int t = 1;
		public abstract void v();

		public virtual void m() 
		{
			Console.WriteLine("123");
		}
	}

    class Program:T1
    {
		static int max;
		const int constent = 9;
		static readonly int q = 9;
		private string myName;
		private string[] vs = new string[10];

		public Program()
        {

		}

		public override void v()
        {
			Console.WriteLine(base.t);
        }
		public override void m()
        {
			myName = "123";
			Console.WriteLine("1234");
		}
		//属性
		public string Name
        {
            get
            {
				return myName;
            }
            set
            {
				myName = value;
            }
		}
		//索引器
		public string this[int idx]
        {
            set
            {
				if(idx<10)
                {
					vs[idx] = value;
                }
            }

            get
            {
				return vs[idx];
            }
        }
		public static void Main(string[] args)
		{
			try
			{
				int i = 0;
				int[] arint = new int[5];
				int sum = 0;
				for (i = 0; i < 5; ++i)
                {
					arint[i] = int.Parse(Console.ReadLine());
					sum += arint[i];
                }
				Console.WriteLine(sum);

				int n_num = 100;
				int[,] array = new int[n_num, 4];
				Console.Write(array.Length);
				n_num = 50;
				array[4, 2] = 15;
				Console.Write(array.Length);
				Console.Write(n_num);


				string s1;
				string s2 = "12345";
				char[] c;
				c = new char[20];
				Console.Write("Please input a line:");
				s1 = Console.ReadLine();
				int n = checked(Int32.Parse(s1));
				if(n<0)
                {
					throw new Exception("输入不能小于0");
                }
				n = ~n;
				s1 = n.ToString();
				decimal a;
				a = 134.2347M;
				Console.WriteLine($"You have entered:{n},\nYou have entered:{s1}");
				Console.WriteLine($"You have entered:{a}");
				bool j = s2.Contains(s1);
				i = string.Compare(s1, s2);
				Console.WriteLine(i);
				Console.WriteLine(j);
			}catch(Exception e)
            {
				Console.WriteLine(e.Message);
            }

			Program program = new Program();
			program.Name = "杨洋";

			Console.WriteLine(program.Name);


			double d = Convert.ToDouble("123.4");
			Console.WriteLine(d);

			int[] b = { 1, 2, 3, };
			Console.WriteLine(b.Length);

			program[0] = "dowfosifwei";
			Console.WriteLine(program[0]);

			//隐匿类型
			object ob = new { Name = "dkjf", Age = 22 };

			Type t = typeof(Program);

			Program.max = 12;
			Console.WriteLine(Program.constent);

			T1 t1;
			t1 = program;
			t1.m();
		}
	}
}
