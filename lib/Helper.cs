using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MPTCompare.lib
{
    class Helper
    {
        // возвращаю имя типа по его id
        public static string GetTypeNameById(int TypeId)
        {
            string[] TypesNames = new string[] { "Целый", "Вещественный", "Строка", "Перекл.", "Перечисл.", "Рис.", "Неизвестный", "Неизвестный", "Время" };
            try
            {
                return TypesNames[TypeId];
            }
            catch
            {
                return "Неизвестный";
            }
        }

        public static bool CompareDictionaries(Dictionary<string, Array> dict1, Dictionary<string, Array> dict2)
        {
            foreach (KeyValuePair<string, Array> dictByKey1 in dict1)
            {
                if (!dict2.ContainsKey(dictByKey1.Key)) return false; // значит состав словарей разный
                var s = dict2[dictByKey1.Key];
                var l = dictByKey1.Value;
                if (!CompareObjects(l, s)) return false;
            }
            return true;
        }

        public static bool CompareObjects(Array obj1, Array obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            string s;
            string y;
            for (int i = 0; i < obj1.Length; i++)
            {
                s = obj1.GetValue(i).ToString();
                y = obj2.GetValue(i).ToString();
                if (obj1.GetValue(i).ToString() != obj2.GetValue(i).ToString()) return false;
            }
            return true;
        }

    }
}
