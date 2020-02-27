using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Data   
{ 
    [Table("Models")]
    public class Model : BaseEntity
    {
        #region Properties 

        #region ModelName
        [Display(Name = Messages.MODEL_FIELD)]
        //[RegularExpression("^(B)")]
        public string ModelName { get; set; }
        #endregion
        #endregion

        #region Navigation Properties And Forign Keys

        #region SurveyId
        [Display(Name = Messages.MODEL_FIELD)]
        [ForeignKey("Survey")]
        public Int64 SurveyId { get; set; }
        #endregion

        #region Survey
        public Survey Survey { get; set; }
        #endregion
        #endregion 

    }
}
