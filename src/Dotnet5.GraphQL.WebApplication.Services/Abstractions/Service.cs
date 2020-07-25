using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL.WebApplication.Domain.Abstractions;
using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;
using Dotnet5.GraphQL.WebApplication.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.WebApplication.Services.Abstractions
{
    public abstract class Service<TEntity, TModel, TId> : IService<TEntity, TModel, TId>
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity, TId> _repository;

        protected Service(IRepository<TEntity, TId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(TId id)
        {
            if (Equals(id, Guid.Empty)) return;
            _repository.Delete(id);
        }

        public async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, Guid.Empty)) return;
            await _repository.DeleteAsync(id, cancellationToken);
        }

        public TEntity Edit(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) _repository.Update(entity);
            return entity;
        }

        public async Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) await _repository.UpdateAsync(entity, cancellationToken);
            return entity;
        }

        public bool Exists(TId id) => _repository.Exists(id);

        public async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken) =>
            await _repository.ExistsAsync(id, cancellationToken);

        public IList<TEntity> GetAll() => _repository.SelectAll().ToList();

        public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken) =>
            await _repository.SelectAll().ToListAsync(cancellationToken);

        public TEntity GetById(TId id) => _repository.SelectById(id);

        public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken) =>
            await _repository.SelectByIdAsync(id, cancellationToken);

        public TEntity Save(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) _repository.Insert(entity);
            return entity;
        }

        public async Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) await _repository.InsertAsync(entity, cancellationToken);
            return entity;
        }
    }
}