using System;

namespace PaddleHub.Models
{
    public class Transaction
    {
        #region Fields

        /// <summary>
        /// Gets or sets the transaction id
        /// </summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the transaction type
        /// </summary>
        public string TransactionType { get; set; }

        /// <summary>
        /// Gets or sets the transactions payload
        /// </summary>
        public string Payload { get; set; }

        #endregion

        #region Methods
        #endregion
    }
}