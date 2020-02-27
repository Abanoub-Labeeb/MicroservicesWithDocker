using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data
{
    public enum Gender : byte { 
        Male ,
        Female,
        UnKnown
    }

    public enum YesNo : byte
    {
        No,
        Yes
    }

    public enum OwnLicence : byte
    {
        No,
        Yes,
        Prefer_public_transport
    }

    public enum DriveTrain 
    {
        DoNotKnow,
        FDW,
        RDW
    }

}
