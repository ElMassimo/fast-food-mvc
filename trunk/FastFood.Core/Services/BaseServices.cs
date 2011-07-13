using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Dal.Infrastructure;
using AutoMapper;

namespace FastFood.Core.Services
{
    public abstract class BaseServices<E, M>
    {
        protected IRepository<E> _mainRepo;
        
        public BaseServices(IRepository<E> mainRepo)
        {
            _mainRepo = mainRepo;
        }
        
        public virtual IList<M> GetAll()
        {
            IList<E> entities = _mainRepo.GetAll();            
            IList<M> models = new List<M>();
            models = Mapper.Map(entities, models);
            return models;
        }
    }
}
