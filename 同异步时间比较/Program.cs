using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 同异步时间比较
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 异步
            DateTime startTime = DateTime.Now;
            int x = 0;
            Console.WriteLine("我是主线程，id是"+Thread.CurrentThread.ManagedThreadId);
            var task1 = DoCount();
            for (int i = 0; i < 1000000000; i++)
            {
                x++;
            }
            Console.WriteLine("第一个计算");
            x = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                x++;
            }
            Console.WriteLine("第二个计算");
            string slExecutedTime = (DateTime.Now - startTime).ToString();
            //Console.WriteLine(slExecutedTime);
            //startTime = DateTime.Now;
            Console.WriteLine("当前线程，id是" + Thread.CurrentThread.ManagedThreadId);
            //slExecutedTime = (DateTime.Now - startTime).ToString();
            Console.WriteLine(task1.Result);
            Console.WriteLine(slExecutedTime);
            Console.Read();
            #endregion
            #region 同步
            //DateTime startTime = DateTime.Now;
            //int x = 0;
            //for (int i = 0; i < 1000000000; i++)
            //{
            //    x++;
            //}
            //x = 0;
            //for (int i = 0; i < 1000000000; i++)
            //{
            //    x++;
            //}
            //x = 0;
            //for (int i = 0; i < 1000000000; i++)
            //{
            //    x++;
            //}
            //string slExecutedTime = (DateTime.Now - startTime).ToString();
            //Console.WriteLine(slExecutedTime);
            //Console.Read();
            #endregion
        }

        public  static  Task<int> Count()
        {
            int x=0;
            Console.WriteLine("Count1当前线程，id是" + Thread.CurrentThread.ManagedThreadId);
            return  Task.Run(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    x++;
                }
                //Console.WriteLine("aaa");
                Console.WriteLine("Count2当前线程，id是" + Thread.CurrentThread.ManagedThreadId);
                return x;
            });
           
        }
        public static async Task<int> DoCount()
        {
            Console.WriteLine("DoCount1当前线程，id是" + Thread.CurrentThread.ManagedThreadId);
            // DateTime startTime = DateTime.Now;
            int x1 = await Count();
            Console.WriteLine("DoCount2当前线程，id是" + Thread.CurrentThread.ManagedThreadId);
            //string slExecutedTime = (DateTime.Now - startTime).ToString();
            //Console.WriteLine(slExecutedTime);

            Console.WriteLine("Docount"+x1);
            return x1;
        }
    }

}
