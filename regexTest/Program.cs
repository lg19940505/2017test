using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //参考url     http://www.jb51.net/article/360.htm

            //            常用元字符
            /*代码  说明
            .匹配除换行符以外的任意字符。
            \w 匹配字母或数字或下划线或汉字。
            \s 匹配任意的空白符。
            \d 匹配数字。
            \b 匹配单词的开始或结束。
            [ck]
                    匹配包含括号内元素的字符
            ^	匹配行的开始。
            $ 	匹配行的结束。
            \	对下一个字符转义。比如$是个特殊的字符。要匹配$的话就得用\$
            |	分支条件，如：x|y匹配 x 或 y。
            反义元字符
            代码  说明
            \W 匹配任意不是字母，数字，下划线，汉字的字符。
            \S 匹配任意不是空白符的字符。等价于[^ \f\n\r\t\v]。
            \D 匹配任意非数字的字符。等价于[^ 0 - 9]。
            \B 匹配不是单词开头或结束的位置。
            [^CK]
                    匹配除了CK以外的任意字符。
            特殊元字符
            代码  说明
            \f 匹配一个换页符。等价于 \x0c 和 \cL。
            \n 匹配一个换行符。等价于 \x0a 和 \cJ。
            \r 匹配一个回车符。等价于 \x0d 和 \cM。
            \t 匹配一个制表符。等价于 \x09 和 \cI。
            \v 匹配一个垂直制表符。等价于 \x0b 和 \cK。
            限定符
            代码  说明
            * 匹配前面的子表达式零次或多次。
            +	匹配前面的子表达式一次或多次。
            ?	匹配前面的子表达式零次或一次。
            {n
                }
                n 是一个非负整数。匹配确定的 n 次。
            {n,}
            n 是一个非负整数。至少匹配n 次。
            {n,m}	m 和 n 均为非负整数，其中n <= m。最少匹配 n 次且最多匹配 m 次。
            懒惰限定符
            代码  说明
            *?
            重复任意次，但尽可能少重复。
            如 "acbacb"  正则  "a.*?b" 只会取到第一个"acb" 原本可以全部取到但加了限定符后，只会匹配尽可能少的字符 ，而"acbacb"最少字符的结果就是"acb" 。
            +? 重复1次或更多次，但尽可能少重复。与上面一样，只是至少要重复1次。
            ??	
            重复0次或1次，但尽可能少重复。
            如 "aaacb" 正则 "a.??b" 只会取到最后的三个字符"acb"。
            {n,m}?
            重复n到m次，但尽可能少重复。
            如 "aaaaaaaa"  正则 "a{0,m}" 因为最少是0次所以取到结果为空。
            {n,}?
            重复n次以上，但尽可能少重复。
            如 "aaaaaaa"  正则 "a{1,}" 最少是1次所以取到结果为 "a"。
            捕获分组
            代码  说明
            (exp)                                                   匹配exp,并捕获文本到自动命名的组里。
            (?<name>exp)	匹配exp,并捕获文本到名称为name的组里。
            (?:exp)	匹配exp,不捕获匹配的文本，也不给此分组分配组号以下为零宽断言。
            (?=exp)	
            匹配exp前面的位置。
            如 "How are you doing" 正则"(?<txt>.+(?=ing))" 这里取ing前所有的字符，并定义了一个捕获分组名字为 "txt" 而"txt"这个组里的值为"How are you do";
            (?<=exp)	
            匹配exp后面的位置。
            如 "How are you doing" 正则"(?<txt>(?<=How).+)" 这里取"How"之后所有的字符，并定义了一个捕获分组名字为 "txt" 而"txt"这个组里的值为" are you doing";
            (?!exp)	
            匹配后面跟的不是exp的位置。
            如 "123abc" 正则 "\d{3}(?!\d)"匹配3位数字后非数字的结果
            (?<!exp)
            匹配前面不是exp的位置。
            如 "abc123 " 正则 "(?<![0-9])123" 匹配"123"前面是非数字的结果也可写成"(?!<\d)123"  */
            // 名称 说明
            //IsMatch(String, String) 指示 Regex 构造函数中指定的正则表达式在指定的输入字符串中是否找到了匹配项。
            //Match(String, String)   在指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式的第一个匹配项。
            //Matches(String, String) 在指定的输入字符串中搜索正则表达式的所有匹配项。
            //Replace(String, String) 在指定的输入字符串内，使用指定的替换字符串替换与某个正则表达式模式匹配的所有字符串。
            //Split(String, String)   在由 Regex 构造函数指定的正则表达式模式所定义的位置，拆分指定的输入字符串。

            string RegexStr = string.Empty;

            #region 字符串匹配

            RegexStr = "^[0-9]+$"; //匹配字符串的开始和结束是否为0-9的数字[定位字符]
            Console.WriteLine("判断'R1123'是否为数字:{0}", Regex.IsMatch("R1123", RegexStr));
            Console.WriteLine("判断'1123'是否为数字:{0}", Regex.IsMatch("1123", RegexStr));

            RegexStr = @"\d+"; //匹配字符串中间是否包含数字(这里没有从开始进行匹配噢,任意位子只要有一个数字即可)
            Console.WriteLine("'R1123'是否包含数字:{0}", Regex.IsMatch("R1123", RegexStr));
            Console.WriteLine("'博客园'是否包含数字:{0}", Regex.IsMatch("博客园", RegexStr));

            //感谢@zhoumy的提醒..已修改错误代码
            RegexStr = @"^Hello World[\w\W]*"; //已Hello World开头的任意字符(\w\W：组合可匹配任意字符)
            Console.WriteLine("'HeLLO WORLD xx hh xx'是否已Hello World开头:{0}", Regex.IsMatch("HeLLO WORLD xx hh xx", RegexStr, RegexOptions.IgnoreCase));
            Console.WriteLine("'LLO WORLD xx hh xx'是否已Hello World开头:{0}", Regex.IsMatch("LLO WORLD xx hh xx", RegexStr, RegexOptions.IgnoreCase));
            //RegexOptions.IgnoreCase：指定不区分大小写的匹配。

            #endregion

            Console.WriteLine("");
            #region 字符串查找

            string LinkA = "<a href=\"http://www.baidu.com\" target=\"_blank\">百度</a>";

            RegexStr = @"href=""[\S]+"""; // ""匹配"
            //""代表在@" " 里的一个"
            Match mt = Regex.Match(LinkA, RegexStr);

            Console.WriteLine("{0}。", LinkA);
            Console.WriteLine("获得href中的值：{0}。", mt.Value);

            RegexStr = @"<h[^23456]>[\S]+<h[1]>"; //<h[^23456]>:匹配h除了2,3,4,5,6之中的值,<h[1]>:h匹配包含括号内元素的字符
            Console.WriteLine("{0}。GetH1值：{1}", "<H1>标题<H1>", Regex.Match("<H1>标题<H1>", RegexStr, RegexOptions.IgnoreCase).Value);
            Console.WriteLine("{0}。GetH1值：{1}", "<h2>小标<h2>", Regex.Match("<h2>小标<h2>", RegexStr, RegexOptions.IgnoreCase).Value);
            //RegexOptions.IgnoreCase:指定不区分大小写的匹配。

            RegexStr = @"ab\w+|ij\w{1,}"; //匹配ab和字母 或 ij和字母
            Console.WriteLine("{0}。多选结构：{1}", "abcd", Regex.Match("abcd", RegexStr).Value);
            Console.WriteLine("{0}。多选结构：{1}", "efgh", Regex.Match("efgh", RegexStr).Value);
            Console.WriteLine("{0}。多选结构：{1}", "ijk", Regex.Match("ijk", RegexStr).Value);

            RegexStr = @"张三?丰"; //?匹配前面的子表达式零次或一次。
            Console.WriteLine("{0}。可选项元素：{1}", "张三丰", Regex.Match("张三丰", RegexStr).Value);
            Console.WriteLine("{0}。可选项元素：{1}", "张丰", Regex.Match("张丰", RegexStr).Value);
            Console.WriteLine("{0}。可选项元素：{1}", "张飞", Regex.Match("张飞", RegexStr).Value);

            /* 
             例如：
            July|Jul　　可缩短为　　July?
            4th|4　　 可缩短为　　4(th)?
            */

            //匹配特殊字符
            RegexStr = @"Asp\.net"; //匹配Asp.net字符，因为.是元字符他会匹配除换行符以外的任意字符。这里我们只需要他匹配.字符即可。所以需要转义\.这样表示匹配.字符
            Console.WriteLine("{0}。匹配Asp.net字符：{1}", "Java Asp.net SQLServer", Regex.Match("Java Asp.net SQLServer", RegexStr).Value);
            Console.WriteLine("{0}。匹配Asp.net字符：{1}", "C# Java", Regex.Match("C# Java", RegexStr).Value);

            #endregion

            Console.WriteLine("");
            #region  贪婪与懒惰
            string f = "fooSotS";
            //贪婪匹配
            RegexStr = @"f[\w]+S";
            Match m1 = Regex.Match(f, RegexStr);
            Console.WriteLine("{0}贪婪匹配(匹配尽可能多的字符)：{1}", f, m1.ToString());

            //懒惰匹配
            RegexStr = @"f[\w]+?S";
            Match m2 = Regex.Match(f, RegexStr);
            Console.WriteLine("{0}懒惰匹配(匹配尽可能少重复)：{1}", f, m2.ToString());
            #endregion
            Console.WriteLine("");
            #region  分组
            string TaobaoLink = "<a href=\"http://www.taobao.com\" title=\"淘宝网 - 淘！我喜欢\" target=\"_blank\">淘宝</a>";
            RegexStr = @"<a[^>]+href=""(\S+)""[^>]+title=""([\s\S]+?)""[^>]+>(\S+)</a>";
            Match mat = Regex.Match(TaobaoLink, RegexStr);
            for (int i = 0; i < mat.Groups.Count; i++)
            {
                Console.WriteLine("第" + i + "组：" + mat.Groups[i].Value);
            }

            //(?<name>exp) 分组取名
            string Resume = "基本信息姓名:CK|求职意向:.NET软件工程师|性别:男|学历:本专|出生日期:1988-08-08|户籍:湖北.孝感|E - Mail:9245162@qq.com|手机:15000000000";
            RegexStr = @"姓名:(?<name>[\S]+)\|\S+性别:(?<sex>[\S]{1})\|学历:(?<xueli>[\S]{1,10})\|出生日期:(?<Birth>[\S]{10})\|[\s\S]+手机:(?<phone>[\d]{11})";
            Match matc = Regex.Match(Resume, RegexStr);
            Console.WriteLine("姓名：{0},手机号：{1}", matc.Groups["name"].ToString(), matc.Groups["phone"].ToString());

            string PageInfo = @"<hteml>
                                <div id=""div1"">
                                 <a href=""http://www.baidu.con"" target=""_blank"">百度</a>
                                 <a href=""http://www.taobao.con"" target=""_blank"">淘宝</a>
                                 <a href=""http://www.cnblogs.com"" target=""_blank"">博客园</a>
                                 <a href=""http://www.google.con"" target=""_blank"">google</a>
                                </div>
                                <div id=""div2"">
                                 <a href=""/zufang/"">整租</a>
                                 <a href=""/hezu/"">合租</a>
                                 <a href=""/qiuzu/"">求租</a>
                                 <a href=""/ershoufang/"">二手房</a>
                                 <a href=""/shangpucz/"">商铺出租</a>
                                </div>
                               </hteml>";
            RegexStr = @"<a[^>]+href=""(?<href>[\S]+?)""[^>]*>(?<text>[\S]+?)</a>";
            MatchCollection mc = Regex.Matches(PageInfo, RegexStr);
            foreach (Match item in mc)
            {
                Console.WriteLine("href:{0}--->text:{1}", item.Groups["href"].ToString(), item.Groups["text"].ToString());
            }
            #endregion
            Console.WriteLine("");
            #region Replace 替换字符串
            string PageInputStr = "靠.TMMD,今天真不爽....";
            RegexStr = @"靠|TMMD|妈的";
            Regex rep_regex = new Regex(RegexStr);
            Console.WriteLine("用户输入信息：{0}", PageInputStr);
            Console.WriteLine("页面显示信息：{0}", rep_regex.Replace(PageInputStr, "***"));
            #endregion
            #region split
            string SplitInputStr = "1xxxxx.2ooooo.3eeee.4kkkkkk.";
            RegexStr = @"\d";
            Regex spl_regex = new Regex(RegexStr);
            string[] str = spl_regex.Split(SplitInputStr);
            foreach (string item in str)
            {
                Console.WriteLine(item);
            }
            #endregion
            Console.Read();
        }
    }
}
