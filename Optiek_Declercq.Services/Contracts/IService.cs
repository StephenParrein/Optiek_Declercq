using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Services.Contracts
{
    public interface IService <TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IList<TEntity> All();
        TEntity Create(TEntity entity);
        TEntity Edit(TEntity entity);
        bool Remove(int id);
    }
}
