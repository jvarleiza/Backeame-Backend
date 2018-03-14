using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Data.Helper
{
    public static class EntitiesHelper
    {
        public const string Concatenator = "|**|";

        public static string GetSafeGuid(Guid guid)
        {
            return guid.ToString().Replace("-", "");
        }

        public static string MapIntListToString(List<int> intList)
        {
            if (intList != null)
            {
                return string.Join(Concatenator + "", intList);
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<T> MapStringToEnumList<T>(string enums)
        {
            List<T> enumsList = new List<T>();
            if (enums != null)
            {
                string[] list = enums.Split(new string[] { Concatenator }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string e in list)
                {
                    T data = Entities.Enumerations.GetEnumValueByDescription<T>(e);
                    enumsList.Add(data);
                }
            }
            return enumsList;
        } 

        public static string MapEnumListToString<T>(List<T> list)
        {
            if (list != null)
            {
                return string.Join(Concatenator + "", list);
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<int> MapStringToIntList(string listText)
        {
            List<int> pageList = new List<int>();

            if (listText != null)
            {
                string[] parts = listText.Split(new string[] { Concatenator }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    int num;
                    if (int.TryParse(part, out num))
                    {
                        pageList.Add(num);
                    }
                }
            }

            return pageList;
        }

        public static string MapListToString(List<string> stringList)
        {
            if (stringList != null)
            {
                return string.Join(Concatenator + "", stringList);
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<string> MapStringToList(string listText)
        {
            List<string> pageList = new List<string>();

            if (listText != null)
            {
                pageList = listText.Split(new string[] { Concatenator }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            return pageList;
        }

        internal static string MapGuidListToString(List<Guid> value)
        {
            if (value != null)
            {
                return string.Join(Concatenator + "", value);
            }
            else
            {
                return string.Empty;
            }
        }

        internal static List<Guid> MapStringToGuidList(string value)
        {
            List<Guid> pageList = new List<Guid>();

            if (value != null)
            {
                string[] parts = value.Split(new string[] { Concatenator }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    Guid id;
                    if (Guid.TryParse(part, out id))
                    {
                        pageList.Add(id);
                    }
                }
            }

            return pageList;
        }
    }
}
