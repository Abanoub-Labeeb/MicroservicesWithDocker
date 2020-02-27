using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMWSurvey
{
    /**
     * Services registered to be injected on Startup.cs > ConfigureServices 
    **/
    public class AutoMappingServiceProvider : IAutoMappingServiceProvider
    {
        private IMapper _mapper;
        public AutoMappingServiceProvider()
        {
            //Configure mapper 
            //PM> install-package automapper
            //http://docs.automapper.org/en/stable/Configuration.html
            //https://docs.automapper.org/en/stable/Setup.html
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            configuration.CompileMappings();
            _mapper = configuration.CreateMapper();
        }
        public IMapper GetImapper()
        {
            return _mapper;
        }

        //return unique id for the instantiated obj. from this class
        public int GetInstanceUniqueID()
        {
            return GetHashCode();
        }
    }
}