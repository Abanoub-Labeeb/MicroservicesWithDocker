using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PS.Data;

namespace BMWSurvey
{
    public class CollectSurveyModelViewModel
    {
        #region Properties 
        #region ModelName
        [Display(Name = Messages.MODEL_FIELD)]
        //[RegularExpression("^(B)")]
        public string ModelName { get; set; }
        #endregion
        #endregion
    }
}
