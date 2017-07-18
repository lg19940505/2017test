using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace redis
{
    class Program
    {
        //参考网站   http://www.cnblogs.com/woxpp/p/5007623.html     Redis 环境搭建与使用(C#)
        static void Main(string[] args)
        {
            PooledRedisClientManager prcm = CreateManager();
            //读写客户端
            using (IRedisClient Redis = prcm.GetClient())
            {
                Redis.Set("test", "testvalue" + DateTime.Now.ToString(), DateTime.Now.AddDays(10));
            }
            //只读客户端
            using (IRedisClient Redis = prcm.GetReadOnlyClient())
            {
                Console.WriteLine(Redis.Get<string>("test"));
            }
            Console.WriteLine("-----");
            Thread.Sleep(15000);
            Console.WriteLine("-----");
            using (IRedisClient Redis = prcm.GetReadOnlyClient())
            {
                Console.WriteLine("15秒后：" + Redis.Get<string>("test"));
            }
            Console.Read();
        }

        public static PooledRedisClientManager CreateManager()
        {
            //支持读写分离，均衡负载，负载均衡需要单独部署
            return new PooledRedisClientManager(new string[] { "127.0.0.1:6379" }//用于写
                , new string[] { "127.0.0.1:6379" }//用于读
                , new RedisClientManagerConfig
                {
                    MaxWritePoolSize = 10,//“写”链接池链接数
                    MaxReadPoolSize = 10,//“写”链接池链接数
                    AutoStart = true,

                });
        }
    }
}
