using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data
{
    public class BaseEntity
    {
        #region ID
        public Int64 Id { get; set; }
        #endregion
        #region AddedDate
        public DateTime? AddedDate { get; set; }
        #endregion
        #region ModifiedDate
        public DateTime? ModifiedDate { get; set; }
        #endregion
        #region IPAddress
        public string IPAddress { get; set; }
        #endregion
    }
}
