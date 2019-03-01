using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Repository.Includes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Optiek_Declercq.Repository.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> All(CompanyIncludes includes);
        IEnumerable<Company> Find(Expression<Func<Company, bool>> predicate, CompanyIncludes includes);
        Company Get(int id, CompanyIncludes includes);
    }
}
