using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMWSurvey.ModelDtosMapping
{
    public abstract class AutoMapperConfigurationService : IAutoMapperConfigurationService
    {
        /**
        protected readonly IMapper _mapper;

        protected AutoMapperConfigurationService()
        {
            var config = new MapperConfiguration(x =>
            {
                //way 1 : add the mapping directly in here
                //x.CreateMap<Product, ProductDto>();
                
                //way 2 : add a profile that contains the mapping
                  x.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public IMapper AutoMapper() {
            return _mapper;
        }
        **/
    }
}