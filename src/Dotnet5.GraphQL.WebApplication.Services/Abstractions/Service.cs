using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL.WebApplication.Domain.Abstractions;
using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;
using Dotnet5.GraphQL.WebApplication.Services.Models;

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

        public virtual void Delete(TId id)
            => OnDelete(id);

        public virtual Task DeleteAsync(TId id, CancellationToken cancellationToken)
            => OnDeleteAsync(id, cancellationToken);

        public virtual TEntity Edit(TModel model)
            => OnEdit(model);

        public virtual Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken)
            => OnEditAsync(model, cancellationToken);

        public virtual bool Exists(TId id)
            => OnExists(id);

        public virtual Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken)
            => OnExistsAsync(id, cancellationToken);

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
            => OnGetAll(predicate);

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
            => OnGetAllAsync(predicate, cancellationToken);

        public virtual TEntity GetById(TId id)
            => OnGetById(id);

        public virtual Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
            => OnGetByIdAsync(id, cancellationToken);

        public virtual TEntity Save(TModel model)
            => OnSave(model);

        public virtual Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken)
            => OnSaveAsync(model, cancellationToken);

        protected void OnDelete(TId id)
        {
            if (Equals(id, default(TId))) return;
            _repository.Delete(id);
        }

        protected async Task OnDeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId))) return;
            await _repository.DeleteAsync(id, cancellationToken);
        }

        protected TEntity OnEdit(TModel model)
        {
            if (model is null) return default;
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) _repository.Update(entity);
            return entity;
        }

        protected async Task<TEntity> OnEditAsync(TModel model, CancellationToken cancellationToken)
        {
            if (model is null) return default;
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) await _repository.UpdateAsync(entity, cancellationToken);
            return entity;
        }

        protected bool OnExists(TId id)
            => Equals(id, default(TId)) ? default : _repository.Exists(id);

        protected async Task<bool> OnExistsAsync(TId id, CancellationToken cancellationToken)
            => Equals(id, default(TId)) ? default : await _repository.ExistsAsync(id, cancellationToken);

        protected IEnumerable<TEntity> OnGetAll(Expression<Func<TEntity, bool>> predicate)
            => _repository.GetAll(predicate);

        protected async Task<IEnumerable<TEntity>> OnGetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
            => await _repository.GetAllAsync(predicate, cancellationToken);

        protected TEntity OnGetById(TId id)
            => Equals(id, default(TId)) ? default : _repository.GetById(id);

        protected async Task<TEntity> OnGetByIdAsync(TId id, CancellationToken cancellationToken)
            => Equals(id, default(TId)) ? default : await _repository.GetByIdAsync(id, cancellationToken);

        protected TEntity OnSave(TModel model)
        {
            if (model is null) return default;
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) _repository.Add(entity);
            return entity;
        }

        protected async Task<TEntity> OnSaveAsync(TModel model, CancellationToken cancellationToken)
        {
            if (model is null) return default;
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) await _repository.AddAsync(entity, cancellationToken);
            return entity;
        }
    }
}