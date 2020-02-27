using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Data;
using PS.Service;

namespace BMWSurvey.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        #region Members to be injected
        private IMapper _mapper;
        private IUnitOfWorkServiceProvider _UnitOfWorkServiceProvider;
        private IAutoMappingServiceProvider _IAutoMappingServiceProvider;
        #endregion

        #region Ctor
        //by declaring a constructor on the controller and putting input parameter
        //i'm telling the Unity dependency injection FW to inject inject an instance of UnitOfWorkServiceProvider
        //to my controller 
        public SurveyController(IUnitOfWorkServiceProvider unitOfWorkServiceProvider, IAutoMappingServiceProvider iAutoMappingServiceProvider)
        {
            _UnitOfWorkServiceProvider = unitOfWorkServiceProvider;
            _IAutoMappingServiceProvider = iAutoMappingServiceProvider;
            _mapper = _IAutoMappingServiceProvider.GetImapper();
        }
        #endregion

        // GET: api/Customer/5
        //for testing Auto Mapping
        [HttpGet]
        public IActionResult Get()
        {
            //AutoMapperTest
            Auther auther = new Auther()
            {
                Id = 0,
                FirstName = "Abanoub",
                LastName = "Labeeb",
                NickName = "Andrew"
            };

            AutherDto autherDto = _mapper.Map<AutherDto>(auther);

            return StatusCode(StatusCodes.Status200OK, autherDto.FirstName);
        }

        // GET: api/Survey/5
        //for testing Auto Mapping
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //AutoMapperTest
            Auther auther = new Auther()
            {
                Id = 0,
                FirstName = "Abanoub",
                LastName = "Labeeb",
                NickName = "Andrew"
            };

            AutherDto autherDto = _mapper.Map<AutherDto>(auther);

            return StatusCode(StatusCodes.Status200OK, autherDto.LastName);
        }

        //Call via : https://localhost:44366/api/survey/SurveyCollect
        [HttpPost("SurveyCollect")]
        public IActionResult Collect(CollectSurveyViewModel collectSurveyViewModel)
        {
            if (!ModelState.IsValid)
              return StatusCode(StatusCodes.Status417ExpectationFailed, "Model is not valid");

            
            ReturnFlag flag = SaveSurvey(collectSurveyViewModel);
            ThanksViewModel thanksViewModel = new ThanksViewModel();

            if (flag == ReturnFlag.UNDER_AGE)
            {
                thanksViewModel.Message = Messages.THANKS_MSG_BELOW_18;
            }
            else if (flag == ReturnFlag.FIRST_CAR)
            {
                thanksViewModel.Message = Messages.THANKS_MSG_FIRST_CAR;
            }
            else if (flag == ReturnFlag.PREFER_PUBLIC_TRANSPORT)
            {
                thanksViewModel.Message = Messages.THANKS_MSG_PREFER_PUBLIC_TRANSPORT;
            }
            else if (flag == ReturnFlag.SUCCESSED)
            {
                thanksViewModel.Message = Messages.THANKS_MSG_SUCCESSED;
            }

            return StatusCode(StatusCodes.Status201Created, "value");
        }

        private ReturnFlag SaveSurvey(CollectSurveyViewModel collectSurveyViewModel)
        {
            ReturnFlag flag = ValidateReturn(collectSurveyViewModel);
            //UnitOfWork unitOfWork = new UnitOfWork(new BMWApplicationContext());
            UnitOfWork unitOfWork = _UnitOfWorkServiceProvider.GetUnitOfWork();
            Survey survey = new Survey();
            survey.Age = collectSurveyViewModel.Age;
            if (flag == ReturnFlag.SUCCESSED)
            {
                survey.Gender = collectSurveyViewModel.Gender;
                survey.OwnLicence = collectSurveyViewModel.OwnLicence;
                survey.FirstCar = collectSurveyViewModel.FirstCar;
                survey.DriveTrain = collectSurveyViewModel.DriveTrain;
                survey.Drifting = collectSurveyViewModel.Drifting;
                survey.NumberOfBMWs = collectSurveyViewModel.NumberOfBMWs;
            }
            else if (flag == ReturnFlag.FIRST_CAR)
            {
                survey.Gender = collectSurveyViewModel.Gender;
                survey.OwnLicence = collectSurveyViewModel.OwnLicence;
            }
            else if (flag == ReturnFlag.PREFER_PUBLIC_TRANSPORT)
            {
                survey.Gender = collectSurveyViewModel.Gender;
            }
            else if (flag == ReturnFlag.UNDER_AGE)
            {

            }

            unitOfWork.Survies.Insert(survey);
            unitOfWork.Complete();
            if (flag == ReturnFlag.SUCCESSED)
            {
                Model model;
                foreach (var m in collectSurveyViewModel.Models)
                {
                    model = new Model();
                    model.SurveyId = survey.Id;
                    model.ModelName = m.ModelName;
                    unitOfWork.Models.Insert(model);
                }
                unitOfWork.Complete();
            }

            return flag;
        }

        private ReturnFlag ValidateReturn(CollectSurveyViewModel collectSurveyViewModel)
        {
            ReturnFlag flag = ReturnFlag.SUCCESSED;
            if (collectSurveyViewModel.Age < 18)
            {
                flag = ReturnFlag.UNDER_AGE;
            }
            else if (collectSurveyViewModel.OwnLicence == OwnLicence.Prefer_public_transport)
            {
                flag = ReturnFlag.PREFER_PUBLIC_TRANSPORT;
            }
            else if (collectSurveyViewModel.FirstCar == YesNo.Yes)
            {
                flag = ReturnFlag.FIRST_CAR;
            }
            return flag;
        }
    }
}