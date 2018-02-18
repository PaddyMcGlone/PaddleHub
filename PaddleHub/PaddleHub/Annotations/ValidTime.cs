using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PaddleHub.Annotations
{
    /// <summary>
    /// Data annotation for time validation
    /// </summary>
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime time;
            return DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out time);            
        }
    }
}