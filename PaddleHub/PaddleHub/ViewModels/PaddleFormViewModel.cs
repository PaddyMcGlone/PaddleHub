
using System;
using System.Collections;
using System.Globalization;

namespace PaddleHub.ViewModels
{
    public class PaddleFormViewModel
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }


        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public string Date { get; set; }


        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public string Time { get; set; }
        

        /// <summary>
        /// Gets or sets the paddletype.
        /// </summary>
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
    }
}