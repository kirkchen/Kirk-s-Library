using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using NPOI.HSSF.UserModel;
using System.ComponentModel;

namespace Extension
{
    public static class ExportExcelExtensions
    {
        public static void ExportExcel<T>(this IEnumerable<T> dataList, string fileName)
        {
            //Create workbook
            var datatype = typeof(T);
            var workbook = new HSSFWorkbook();
            var worksheet = workbook.CreateSheet(string.Format("{0}", datatype.GetDisplayName()));

            //Insert titles
            var row = worksheet.CreateRow(0);
            var titleList = datatype.GetPropertyDisplayNames();
            for (int i = 0; i < titleList.Count; i++)
            {
                row.CreateCell(i).SetCellValue(titleList[i]);
            }

            //Insert data values
            for (int i = 1; i < dataList.Count() + 1; i++)
            {
                var tmpRow = worksheet.CreateRow(i);
                var valueList = dataList.ElementAt(i - 1).GetPropertyValues();

                for (int j = 0; j < valueList.Count; j++)
                {
                    tmpRow.CreateCell(j).SetCellValue(valueList[j]);
                }
            }

            //Save file
            FileStream file = new FileStream(fileName, FileMode.Create);
            workbook.Write(file);
            file.Close();
        }

        public static string GetDisplayName(this MemberInfo memberInfo)
        {
            var titleName = string.Empty;

            //Try get DisplayName
            var attribute = memberInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault();
            if (attribute != null)
            {
                titleName = (attribute as DisplayNameAttribute).DisplayName;
            }
            //If no DisplayName
            else
            {
                titleName = memberInfo.Name;
            }

            return titleName;
        }

        public static List<string> GetPropertyDisplayNames(this Type type)
        {
            var titleList = new List<string>();
            var propertyInfos = type.GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                var titleName = propertyInfo.GetDisplayName();

                titleList.Add(titleName);
            }

            return titleList;
        }

        public static List<string> GetPropertyValues<T>(this T data)
        {
            var propertyValues = new List<string>();
            var propertyInfos = data.GetType().GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                propertyValues.Add(propertyInfo.GetValue(data, null).ToString());
            }

            return propertyValues;
        }
    }
}
