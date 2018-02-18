using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PaddleHub.Annotations
{
    /// <summary>
    /// Data annotation for date validation
    /// </summary>
    public class ValidDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                                                 "d",
                                                 CultureInfo.CurrentCulture,
                                                 DateTimeStyles.None, 
                                                 out date);

            return isValid && date > DateTime.Today;
        }
    }
}