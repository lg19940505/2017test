using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json.net
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Person1
    {
        public int Age { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        public string Sex { get; set; }

        public bool IsMarry { get; set; }

        public DateTime Birthday { get; set; }
    }




    [JsonObject(MemberSerialization.OptOut)]
    public class Person2
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        [JsonIgnore]
        public bool IsMarry { get; set; }

        public DateTime Birthday { get; set; }
    }

    [JsonObject]
    public class Person3
    {
        [DefaultValue(10)]
        public int Age { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }
        
        public bool IsMarry { get; set; }

        public DateTime Birthday { get; set; }
    }

    [JsonObject]
    public class Person4
    {
        
        public int Age { get; set; }

        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Sex { get; set; }

        public bool IsMarry { get; set; }

        public DateTime Birthday { get; set; }
    }
    [JsonObject]
     class Person5
    {
        public Person5(string room)
        {
            this.Room = room;
        }
        [JsonProperty]
        private string Room { get; set; }
        public int Age { get; set; }

        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Sex { get; set; }

        public bool IsMarry { get; set; }

        public DateTime Birthday { get; set; }
    }

    class Person6
    {
        public int Age { get; set; }

        public string Name { get; set; }
        
        public string Sex { get; set; }

        public bool IsMarry { get; set; }
        [JsonConverter(typeof(ChinaDateTimeConverter))]
        public DateTime Birthday { get; set; }
    }
    //重写时间类  定义自己的时间格式
    public class ChinaDateTimeConverter : DateTimeConverterBase
    {
        private static IsoDateTimeConverter dtConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy/MM/dd" };

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return dtConverter.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            dtConverter.WriteJson(writer, value, serializer);
        }
    }


    class Person7
    {
        public int Age { get; set; }
        [JsonProperty(PropertyName = "CName")]
        public string Name { get; set; }

        public string Sex { get; set; }

        public bool IsMarry { get; set; }
        public DateTime Birthday { get; set; }
    }
    /// <summary>
    /// 选出传出值
    /// </summary>
    public class LimitPropsContractResolver : DefaultContractResolver
    {
        string[] props = null;

        bool retain;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="props">传入的属性数组</param>
        /// <param name="retain">true:表示props是需要保留的字段  false：表示props是要排除的字段</param>
        public LimitPropsContractResolver(string[] props, bool retain = true)
        {
            //指定要序列化属性的清单
            this.props = props;

            this.retain = retain;
        }

        protected override IList<JsonProperty> CreateProperties(Type type,

        MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list =
            base.CreateProperties(type, memberSerialization);
            //只保留清单有列出的属性
            return list.Where(p =>
            {
                if (retain)
                {
                    return props.Contains(p.PropertyName);
                }
                else
                {
                    return !props.Contains(p.PropertyName);
                }
            }).ToList();
        }
    }

    public enum NotifyType
    {
        /// <summary>
        /// Emil发送
        /// </summary>
        Mail = 0,

        /// <summary>
        /// 短信发送
        /// </summary>
        SMS = 1
    }

    public class TestEnmu
    {
        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// 消息发送类型
        /// </summary>
        public NotifyType Type { get; set; }
    }

    /// <summary>
    /// 自定义类型转换  把false 转换成 否
    /// </summary>
    public class BoolConvert : JsonConverter
    {
        private string[] arrBString { get; set; }

        public BoolConvert()
        {
            arrBString = "是,否".Split(',');
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="BooleanString">将bool值转换成的字符串值</param>
        public BoolConvert(string BooleanString)
        {
            if (string.IsNullOrEmpty(BooleanString))
            {
                throw new ArgumentNullException();
            }
            arrBString = BooleanString.Split(',');
            if (arrBString.Length != 2)
            {
                throw new ArgumentException("BooleanString格式不符合规定");
            }
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool isNullable = IsNullableType(objectType);
            Type t = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            if (reader.TokenType == JsonToken.Null)
            {
                if (!IsNullableType(objectType))
                {
                    throw new Exception(string.Format("不能转换null value to {0}.", objectType));
                }

                return null;
            }

            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    string boolText = reader.Value.ToString();
                    if (boolText.Equals(arrBString[0], StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    else if (boolText.Equals(arrBString[1], StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }

                if (reader.TokenType == JsonToken.Integer)
                {
                    //数值
                    return Convert.ToInt32(reader.Value) == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error converting value {0} to type '{1}'", reader.Value, objectType));
            }
            throw new Exception(string.Format("Unexpected token {0} when parsing enum", reader.TokenType));
        }

        /// <summary>
        /// 判断是否为Bool类型
        /// </summary>
        /// <param name="objectType">类型</param>
        /// <returns>为bool类型则可以进行转换</returns>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }


        public bool IsNullableType(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }
            return (t.BaseType.FullName == "System.ValueType" && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            bool bValue = (bool)value;

            if (bValue)
            {
                writer.WriteValue(arrBString[0]);
            }
            else
            {
                writer.WriteValue(arrBString[1]);
            }
        }
    }

    public class Person9
    {
        [JsonConverter(typeof(BoolConvert))]
        public bool IsMarry { get; set; }
    }

}
