using PS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMWSurvey
{
    /**
      * Services registered to be injected on Startup.cs > ConfigureServices 
    **/
    public class UnitOfWorkServiceProvider : IUnitOfWorkServiceProvider
    {
        private UnitOfWork UnitOfWork;
        public UnitOfWorkServiceProvider()
        {
            UnitOfWork  = new UnitOfWork(new BMWApplicationContext());
        }

        
        public UnitOfWork GetUnitOfWork()
        {
            //return  unique id of the created instance in the constructor
            return UnitOfWork;
        }

        //return unique id for the instantiated obj. from this class
        public int GetInstanceUniqueID()
        {
            return GetHashCode();
        }
    }
}