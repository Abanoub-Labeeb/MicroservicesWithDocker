using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMWSurvey
{
    /**
        * this class should be put under App_start 
        * but we put it in another folder to be noticed easily
        * this mapper should be registed under Global.asax.CS >> Application_Start()
        * using Mapper.Intialize(x => x.AddProfile<MappingProfile>())
        * used by calling Mapper.Map<Customer,CustomerDto>() to return CustomerDto
        * or just pass a Mapper.Map<Customer,CustomerDto> as a delegate reference to that method on select of linq to be executed nd returened
        
        * Note : this registeration deprecated now and replaced with
        * AutoMapperConfigurationRegisteration : our custom class that intialize it
        * refer to https://www.codementor.io/@zedotech/how-to-using-automapper-on-asp-net-core-3-0-via-dependencyinjection-zq497lzsq
        * to know how to use Automap with Dependency injection in MVC Core
    **/
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Auther, AutherDto>();
            CreateMap<AutherDto, Auther>();
        }
    }
}