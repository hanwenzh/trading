using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Common
{
    public class EnumHelper
    {
        public static string Enums2String<T>(T[] enums)
        {
            var fields = typeof(T).GetFields();
            List<int> enum_values = new List<int>();
            foreach (T t in enums)
            {
                FieldInfo field = fields.FirstOrDefault(f => f.Name == t.ToString());
                if(field != null)
                {
                    enum_values.Add((int)field.GetValue(t));
                }
            }
            return string.Join(",", enum_values);
        }

        public static T[] String2Enums<T>(string strs)
        {
            if(string.IsNullOrWhiteSpace(strs))
            {
                return new T[0];
            }
            return strs.Split(',').Select(s =>
            {
                return (T)Enum.ToObject(typeof(T), int.Parse(s));
            }).ToArray();
        }

        /// <summary>
        /// 获取枚举的描述，需要DescriptionAttribute属性
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDescription(Type type)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                if (field.IsDefined(typeof(DescriptionAttribute), true))
                {
                    var attr = field.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        dic.Add(field.Name, attr.Description);
                    }
                }
            }
            return dic;
        }
    }
}