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
        /// Gets or sets the page title/heading
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the paddle id
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Gets the models action type
        /// </summary>
        public string Action {
            get
            {
                return (Id == 0) ? "Create" : "Edit";
            }
        }
        

        #endregion

        #region Methods

        /// <summary>
        /// Return formatted datetime
        /// </summary>
        /// <returns></returns>
        public DateTime PaddleDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }        
        
        /// <summary>
        /// Validate the current object state.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateTime parsedDate;
            DateTime.TryParse(Date, out parsedDate);
            var inValidDate = parsedDate == DateTime.MinValue;
            var dateInPast = !inValidDate && parsedDate < DateTime.Today;

            DateTime parsedTime;
            DateTime.TryParseExact(Time, "HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out parsedTime);
            var inValidTime = parsedTime == DateTime.MinValue;

            if (inValidDate)
                yield return new ValidationResult("Invalid date format, please retry", new[] { "Date" });

            if (dateInPast)
                yield return new ValidationResult("Date must not be in the past", new[] { "Date" });

            if (inValidTime)
                yield return new ValidationResult("Invalid time format, please retry", new [] { "Time" });
        }

        #endregion
    }
}