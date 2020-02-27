using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data
{
    public class Messages
    {
        #region Survey
        
        #region Validation Messages
        public const string AGE_VALIDATION_ERROR    = "Age must be in a range between [0 - 100] .";
        #endregion

        #region Field Names
        public const string OWN_LICENCE_FIELD       = "Do you own a car driving license?";
        public const string FIRST_CAR_FIELD         = "Is this your first car?";
        public const string DRIVE_TRAIN_FIELD       = "Which drivetrain do you prefer?";
        public const string DRIFTING_FIELD          = "Do you care about drifting?";
        public const string NUMBER_OF_BMWS_FIELD    = "How many BMWs did you drive?";
        #endregion

        #region GENERAL
        public const string THANKS_MSG_BELOW_18     = "Thank for your interest in helping BMW .";
        public const string THANKS_MSG_FIRST_CAR    = "We are targeting more experienced clients, thank you for your interest .";
        public const string THANKS_MSG_PREFER_PUBLIC_TRANSPORT = "Thank for your interest in helping BMW .";
        public const string THANKS_MSG_SUCCESSED = "Thank for helping BMW .";
        #endregion

        #endregion

        #region Model

        #region Field Names
        public const string MODEL_FIELD = "Which BMW did you drive?";
        #endregion

        #endregion

    }
}
