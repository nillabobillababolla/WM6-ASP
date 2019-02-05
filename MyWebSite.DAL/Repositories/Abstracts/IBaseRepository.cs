﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyWebSite.DAL.Repositories.Abstracts
{
    public interface IBaseRepository<T> where T : class // reference type constraint
    {
        int AddItem(T item);
        int DeleteItem(T item);
        int UpdateItem(T item);
        T GetItem(Expression<Func<T, bool>> lambda = null);
        ICollection<T> GetAllItem(Expression<Func<T, bool>> lambda = null);

    }
}
