using System;

namespace ticket
{
    class Program
    {
        static double price1 = 60;
        static double price2 = 40;
        static void Main(string[] args)
        {
            try
            {
                double price;
                DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                int month = currentTime.Month;
                //Console.WriteLine(month);
                bool judge = true;

                while (judge)
                {
                    int choice;
                    Console.WriteLine("\n欢迎参观故宫：");
                    Console.WriteLine("\n======= 票价 =======\n");
                    Console.WriteLine("11月1日-3月31日 40元");
                    Console.WriteLine("4月1日-10月31日 60元");
                    Console.WriteLine("\n----- 优惠政策 -----\n");
                    Console.WriteLine("1--1.2米以下儿童免票");
                    Console.WriteLine("2--大中小学生门票20元");
                    Console.WriteLine("3--离休人员免票");
                    Console.WriteLine("4--60岁及以上老人享受半价优惠");
                    Console.WriteLine("5--正常购票");
                    Console.WriteLine("0--退出");
                    Console.WriteLine("请输入购票序号：");
                    choice = checked(int.Parse(Console.ReadLine()));
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("票价：0元");
                                break;
                            }
                        case 2: 
                            {
                                Console.WriteLine("票价：20元");
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("票价：0元");
                                break;
                            }
                        case 4:
                            {
                                if (month >= 4 && month <= 10)
                                    price = price1;
                                else
                                    price = price2;
                                price = price * 0.5;
                                Console.WriteLine("票价：{0}元", price);
                                break;
                            }
                        case 5:
                            {
                                if (month >= 4 && month <= 10)
                                    price = price1;
                                else
                                    price = price2;
                                Console.WriteLine("票价：{0}元", price);
                                break;
                            }
                        case 0: 
                            { 
                                Console.WriteLine("退出"); 
                                judge = false; 
                                break;
                            }
                        default:Console.WriteLine("输入错误");break;
                    }

                    //Console.WriteLine("Hello World!");
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
