using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace json.net
{
    class Program
    {
        //参考url  http://www.cnblogs.com/yanweidie/p/4605212.html
        static void Main(string[] args)
        {
            #region 基本用法
            //序列化DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Age", Type.GetType("System.Int32"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Sex", Type.GetType("System.String"));
            dt.Columns.Add("IsMarry", Type.GetType("System.Boolean"));
            for (int i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Age"] = i + 1;
                dr["Name"] = "Name" + i;
                dr["Sex"] = i % 2 == 0 ? "男" : "女";
                dr["IsMarry"] = i % 2 > 0 ? true : false;
                dt.Rows.Add(dr);
            }
            Console.WriteLine(JsonConvert.SerializeObject(dt));
            //反序列化
            string json = JsonConvert.SerializeObject(dt);
            dt = JsonConvert.DeserializeObject<DataTable>(json);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dr[0], dr[1], dr[2], dr[3]);
            }
            #endregion

            #region 高级用法

            #region 一 忽略某些属性 
            //仅需某些属性 Person1
            Person1 person1 = new Person1()
            {
                Age = 13,
                Name = "张三丰",
                Sex = "男",
                IsMarry = false,
                Birthday = DateTime.Parse("2010-2-12")
            };
            Console.WriteLine(JsonConvert.SerializeObject(person1));

            //不需要某些元素
            Person2 person2 = new Person2()
            {
                Age = 13,
                Name = "张三丰",
                Sex = "男",
                IsMarry = false,
                Birthday = DateTime.Parse("2010-2-12")
            };
            Console.WriteLine(JsonConvert.SerializeObject(person2));

            #endregion
            #region 二  默认值处理
            Person3 p3 = new Person3 {Age=10,  Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
             //DefaultValueHandling.Ignore
             //序列化和反序列化时, 忽略默认值  age=默认值才忽略
             //DefaultValueHandling.Include
             //序列化和反序列化时, 包含默认值
            jsetting.DefaultValueHandling = DefaultValueHandling.Ignore;
            Console.WriteLine(JsonConvert.SerializeObject(p3, Formatting.Indented, jsetting));
            #endregion

            #region 三 空值的处理
            Person3 person3 = new Person3 {  Age = 10, Name = "张三丰", Sex = null, IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
            JsonSerializerSettings jsetting3 = new JsonSerializerSettings();
            jsetting3.NullValueHandling = NullValueHandling.Ignore;
            Console.WriteLine(JsonConvert.SerializeObject(person3, Formatting.Indented, jsetting3));

            Person4 person4 = new Person4 { Age = 10, Name = "张三丰", Sex = null, IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
            Console.WriteLine(JsonConvert.SerializeObject(person4));
            #endregion


            #region 四 支持非公共成员
            Person5 person5 = new Person5("room") { Age = 10, Name = "张三丰", Sex = null, IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
            Console.WriteLine(JsonConvert.SerializeObject(person5));
            #endregion

            #region 五.日期处理
            Person6 p6 = new Person6()
            {
                Age = 13,
                Name = "张三丰",
                Sex = "男",
                IsMarry = false,
                Birthday = DateTime.Parse("2010-2-12")
            };
            Console.WriteLine(JsonConvert.SerializeObject(p6));
            #endregion

            #region 六.自定义序列化的字段名称
            Person7 p7 = new Person7()
            {
                Age = 13,
                Name = "张三丰",
                Sex = "男",
                IsMarry = false,
                Birthday = DateTime.Parse("2010-2-12")
            };
            Console.WriteLine(JsonConvert.SerializeObject(p7));

            #endregion


            #region  七.动态决定属性是否序列化动态决定属性是否序列化
            string[] propNames = null;
            if (p7.Age > 10)
            {
                propNames = new string[] { "Age", "IsMarry" };
            }
            else
            {
                propNames = new string[] { "Age", "Sex" };
            }
            JsonSerializerSettings jsetting7 = new JsonSerializerSettings();
            jsetting7.ContractResolver = new LimitPropsContractResolver(propNames);
            Console.WriteLine(JsonConvert.SerializeObject(p7, Formatting.Indented, jsetting7));
            #endregion


            #region 八.枚举值的自定义格式化问题
            Console.WriteLine(JsonConvert.SerializeObject(new TestEnmu()));

            #endregion

            #region 九.自定义类型转换
            Person9 p9 = new Person9() { IsMarry = false };
            Console.WriteLine(JsonConvert.SerializeObject(p9));
            #endregion

            #region 十.全局序列化设置
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //空值处理
                setting.NullValueHandling = NullValueHandling.Ignore;

                //高级用法九中的Bool类型转换 设置
                setting.Converters.Add(new BoolConvert("是,否"));

                return setting;
            });

            #endregion

            #endregion

            Console.Read();
        }
    }
}
