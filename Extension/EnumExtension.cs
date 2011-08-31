//-----------------------------------------------------------------------
// <copyright file="EnumExtension.cs" company="Hewlett-Packard Company">
//     Copyright (c) kirkchen, Hewlett-Packard Company. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace KirkChen.Library.Extension
{
    /// <summary>
    /// EnumExtensioms
    /// </summary>
    public static class EnumExtensioms
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
