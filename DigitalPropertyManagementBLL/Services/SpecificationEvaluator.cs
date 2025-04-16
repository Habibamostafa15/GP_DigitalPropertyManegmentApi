using DigitalPropertyManagementBLL.Interfaces;
using DigitslPropertyManangementDAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntitty> GetQuery<TEntitty>(this IQueryable<TEntitty> inputQuery, ISpecification<TEntitty> spec)
            where TEntitty : BaseEntity
        {
            var query = inputQuery;

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if (spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.IsPagination)
                query = query.Skip(spec.Skip).Take(spec.Take);


            if (spec.IncludeExpressions.Any())
                query = spec.IncludeExpressions.Aggregate(query, (currentQuery, includeExpression)
                    => currentQuery.Include(includeExpression));

            return query;
        }
    }
}
