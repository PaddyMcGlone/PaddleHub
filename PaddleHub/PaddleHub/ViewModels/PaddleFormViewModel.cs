
using System.Collections;

namespace PaddleHub.ViewModels
{
    public class PaddleFormViewModel
    {
        #region Properties

        public string Location { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
        
        public int PaddleType { get; set; }

        public IEnumerable PaddleTypes { get; set; }

        #endregion
    }
}