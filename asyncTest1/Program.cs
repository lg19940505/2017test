using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始获取搜狐首页字符数量");
            Task<int> task1 = CountCharsAsync("http://www.sohu.com");
            Console.WriteLine("开始获取百度首页字符数量");
            Task<int> task2 = CountCharsAsync("http://www.baidu.com");

            Console.WriteLine("Main方法中做其他事情");

            Console.WriteLine("搜狐:" + task1.Result);
            Console.WriteLine("百度:" + task2.Result);

            Console.WriteLine("====所有执行完====");
            Console.ReadLine();
        }

        static async Task<int> CountCharsAsync(string url)
        {
            WebClient wc = new WebClient();
            string result = await wc.DownloadStringTaskAsync(new Uri(url));
            /* 
             * 1、以前我们用Thread.Sleep(1000)，这是它的替代方式              
             * 2、Thread.Sleep 是同步延迟。 Task.Delay异步延迟。 
             * 3、Thread.Sleep 会阻塞线程，Task.Delay不会。 
             * 4、Thread.Sleep不能取消，Task.Delay可以。 
             */
            await Task.Delay(1000);
            return result.Length;
        }
    }
}

