using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMWSurvey
{
    public interface IAutoMappingServiceProvider
    {
        IMapper GetImapper();
        int     GetInstanceUniqueID();
    }
}
