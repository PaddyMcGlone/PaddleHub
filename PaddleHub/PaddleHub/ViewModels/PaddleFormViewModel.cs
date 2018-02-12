using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PaddleHub.ViewModels
{
    public class PaddleFormViewModel : IValidatableObject
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Required]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [Required]
        public string Date { get; set; }


        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        [Required]
        public string Time { get; set; }
        

        /// <summary>
        /// Gets or sets the paddletype.
        /// </summary>
        [Required]
        public byte PaddleType { get; set; }


        /// <summary>
        /// Gets or sets the paddle types list.
        /// </summary>
        public IEnumerable PaddleTypes { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Return formatted datetime
        /// </summary>
        /// <returns></returns>
        public DateTime PaddleDateTime()
        {
            DateTime result;
            DateTime.TryParseExact(string.Format("{0} {1}", Date, Time), "g", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

            return result;
        }

        #endregion
        
        /// <summary>
        /// Validate the current object state.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date.IsNullOrWhiteSpace()) throw new ArgumentNullException("Date");

            var validationResult = new List<ValidationResult>();

            DateTime date;
            DateTime.TryParse(Date, out date);

            if (date == DateTime.MinValue)
            {
                validationResult.Add(new ValidationResult("Invalid date format, please retry", new[] { "Date" }));
                return validationResult;
            }

            if (date < DateTime.Today)
            {
                validationResult.Add(new ValidationResult("Date must not be in the past", new[] { "Date" }));
                return validationResult;
            }
                
            return validationResult;            
        }        
    }
}