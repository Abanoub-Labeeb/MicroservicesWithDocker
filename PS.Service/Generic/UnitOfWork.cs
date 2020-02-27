using Microsoft.EntityFrameworkCore;
using PS.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Service
{
    public class UnitOfWork : IUnitOfWork
    {

        public ISurveyRepository Survies { get; private set; }
        public IModelRepository  Models  { get; private set; }
        protected readonly DbContext _context;
        
        public UnitOfWork(DbContext context)
        {
            _context = context;
            Survies = new SurveyRepository(context);
            Models = new ModelRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
