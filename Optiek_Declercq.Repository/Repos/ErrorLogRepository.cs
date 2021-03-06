﻿using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Repository.Contracts;
using Optiek_Declercq.Repository.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Repository.Repos
{
    public class ErrorLogRepository : Repository<ErrorLog>, IErrorLogRepository
    {
        public ErrorLogRepository(DbContext context) : base(context)
        {
        }

        public OptiekDbContext OptiekDbContext => Context as OptiekDbContext;
    }
}
