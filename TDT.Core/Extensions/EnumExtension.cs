using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value, string formatValue = "")
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                string description = attributes[0].Description.ToString();
                return formatValue.Length != 0 && description.Contains("{0}") ? string.Format(description, formatValue) : description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
