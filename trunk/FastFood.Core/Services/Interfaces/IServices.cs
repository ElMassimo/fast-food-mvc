using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FastFood.Core.Services
{
    public interface IServices<T>
    {
        void Add(T model);

        void Delete(T model);

        void Update(T model);

        IList<T> GetAll();
    }
}
