using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Repo;
namespace PS.Service
{
    public interface IUnitOfWork : IDisposable
    {
        ISurveyRepository Survies { get; }
        IModelRepository  Models  { get; }

        int Complete();
    }
}
