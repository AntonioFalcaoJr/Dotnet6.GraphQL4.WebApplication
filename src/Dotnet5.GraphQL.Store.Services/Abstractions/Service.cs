using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL.Store.Domain.Abstractions;
using Dotnet5.GraphQL.Store.Repositories.Abstractions;
using Dotnet5.GraphQL.Store.Repositories.UnitsOfWorks;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotnet5.GraphQL.Store.Services.Abstractions
{
    public abstract class Service<TEntity, TModel, TId> : IService<TEntity, TModel, TId>
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity, TId> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected Service(IUnitOfWork unitOfWork, IRepository<TEntity, TId> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public virtual void Delete(TId id)
            => OnDelete(id);

        public virtual void Delete(TEntity entity)
            => OnDelete(entity);

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

        public virtual IEnumerable<TResult> GetAll<TResult>(
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false) => OnGetAll(selector, predicate, orderBy, include, withTracking);

        public virtual Task<IEnumerable<TResult>> GetAllAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false, CancellationToken cancellationToken = default)
            => OnGetAllAsync(selector, predicate, orderBy, include, withTracking, cancellationToken);

        public virtual TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false) => OnGetById(id, include, withTracking);

        public virtual Task<TEntity> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,
            object>> include = default, bool withTracking = false, CancellationToken cancellationToken = default)
            => OnGetByIdAsync(id, include, withTracking, cancellationToken);

        public virtual TEntity Save(TModel model)
            => OnSave(model);

        public virtual Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken)
            => OnSaveAsync(model, cancellationToken);

        protected void OnDelete(TId id)
        {
            if (Equals(id, default(TId))) return;
            _repository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        protected void OnDelete(TEntity entity)
        {
            if (entity is null) return;
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        protected async Task OnDeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId))) return;
            await _repository.DeleteAsync(id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        protected TEntity OnEdit(TModel model)
        {
            if (model is null) return default;
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) _repository.Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        protected async Task<TEntity> OnEditAsync(TModel model, CancellationToken cancellationToken)
        {
            if (model is null) return default;
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid) await _repository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        protected bool OnExists(TId id)
            => Equals(id, default(TId)) ? default : _repository.Exists(id);

        protected async Task<bool> OnExistsAsync(TId id, CancellationToken cancellationToken)
            => Equals(id, default(TId)) ? default : await _repository.ExistsAsync(id, cancellationToken);

        protected IEnumerable<TResult> OnGetAll<TResult>(
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false)
            => _repository.GetAll(selector, predicate, orderBy, include, withTracking);

        protected Task<IEnumerable<TResult>> OnGetAllAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false,
            CancellationToken cancellationToken = default)
            => _repository.GetAllAsync(selector, predicate, orderBy, include, withTracking, cancellationToken);

        protected TEntity OnGetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false) => Equals(id, default(TId)) ? default : _repository.GetById(id, include, withTracking);

        protected async Task<TEntity> OnGetByIdAsync(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,
            object>> include = default, bool withTracking = false, CancellationToken cancellationToken = default)
            => Equals(id, default(TId)) ? default : await _repository.GetByIdAsync(id, include, withTracking, cancellationToken);

        protected TEntity OnSave(TModel model)
        {
            if (model is null) return default;
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid is false) return entity;
            _repository.Add(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        protected async Task<TEntity> OnSaveAsync(TModel model, CancellationToken cancellationToken)
        {
            if (model is null) return default;
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid is false) return entity;
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}