using Optiek_Declercq.Repository.EF;
using Optiek_Declercq.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Services.Factories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork CreateInstance()
        {
            return new UnitOfWork();
        }
    }
}
