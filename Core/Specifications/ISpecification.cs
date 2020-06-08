using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //Gets Blog posts according to their id and their filter specs
        Expression<Func<T, bool>> Criteria { get; }
        
        List<Expression<Func<T, object>>> Includes { get; }
        
        //Implements order functions
        
        Expression<Func<T, object>> OrderBy { get; }
        
        Expression<Func<T, object>> OrderByDescending { get; }
        
        //Implements Paging index
        int Take { get; }
        
        int Skip { get; }
        
        bool IsPagingEnabled { get; }
    }
}