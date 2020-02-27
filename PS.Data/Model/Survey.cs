using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Data
{
    [Table("Surveys")]
    public class Survey : BaseEntity
    {
        #region Age
        [Required]
        [Range(0,100,ErrorMessage = Messages.AGE_VALIDATION_ERROR)]
        public int? Age { get; set; }
        #endregion
        #region Gender
        [EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }
        #endregion
        #region OwnLicence
        [Display(Name  = Messages.OWN_LICENCE_FIELD)]
        [EnumDataType(typeof(OwnLicence))]
        public OwnLicence? OwnLicence { get; set; }
        #endregion
        #region FirstCar
        [Display(Name = Messages.FIRST_CAR_FIELD)]
        [EnumDataType(typeof(YesNo))]
        public YesNo? FirstCar { get; set; }
        #endregion
        #region DriveTrain
        [Display(Name = Messages.DRIVE_TRAIN_FIELD)]
        [EnumDataType(typeof(DriveTrain))]
        public DriveTrain? DriveTrain { get; set; }
        #endregion
        #region Drifting
        [Display(Name = Messages.DRIFTING_FIELD)]
        [EnumDataType(typeof(YesNo))]
        public YesNo? Drifting { get; set; }
        #endregion
        #region NumberOfBMWs
        [Display(Name = Messages.NUMBER_OF_BMWS_FIELD)]
        [Range(0,10000)]
        public int? NumberOfBMWs { get; set; }
        #endregion
        #region Models
        public IList<Model> Models { get; set; }
        #endregion

    }
}
