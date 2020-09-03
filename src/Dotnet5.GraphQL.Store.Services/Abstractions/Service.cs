using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL.Store.CrossCutting.Notifications;
using Dotnet5.GraphQL.Store.Domain.Abstractions;
using Dotnet5.GraphQL.Store.Repositories.Abstractions;
using Dotnet5.GraphQL.Store.Repositories.UnitsOfWorks;
using Dotnet5.GraphQL.Store.Services.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotnet5.GraphQL.Store.Services.Abstractions
{
    public abstract class Service<TEntity, TModel, TId> : IService<TEntity, TModel, TId>
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        private readonly IMapper _mapper;
        private readonly INotificationContext _notificationContext;
        private readonly IRepository<TEntity, TId> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected Service(
            IUnitOfWork unitOfWork,
            IRepository<TEntity, TId> repository,
            IMapper mapper,
            INotificationContext notificationContext)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public virtual void Delete(TId id)
        {
            if (IsValid(id) is false) return;
            _repository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            if (IsValid(entity) is false) return;
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (IsValid(id) is false) return;
            await _repository.DeleteAsync(id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public virtual TEntity Edit(TModel model)
        {
            if (IsValid(model) is false) return default;
            var entity = _mapper.Map<TEntity>(model);
            return OnEdit(entity);
        }

        public virtual async Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken)
        {
            if (IsValid(model) is false) return default;
            var entity = _mapper.Map<TEntity>(model);
            return await OnEditAsync(entity, cancellationToken);
        }

        public virtual bool Exists(TId id)
            => IsValid(id) ? _repository.Exists(id) : default;

        public virtual async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken)
            => IsValid(id) ? await _repository.ExistsAsync(id, cancellationToken) : default;

        public virtual IEnumerable<TResult> GetAll<TResult>(
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false)
            => _repository.GetAll(selector, predicate, orderBy, include, withTracking);

        public virtual Task<IEnumerable<TResult>> GetAllAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false,
            CancellationToken cancellationToken = default)
            => _repository.GetAllAsync(selector, predicate, orderBy, include, withTracking, cancellationToken);

        public virtual TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool withTracking = false)
            => IsValid(id) ? _repository.GetById(id, include, withTracking) : default;

        public virtual async Task<TEntity> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool withTracking = false, CancellationToken cancellationToken = default)
            => IsValid(id) ? await _repository.GetByIdAsync(id, include, withTracking, cancellationToken) : default;

        public virtual TEntity Save(TModel model)
        {
            if (IsValid(model) is false) return default;
            var entity = _mapper.Map<TEntity>(model);
            return OnSave(entity);
        }

        public virtual async Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken)
        {
            if (IsValid(model) is false) return default;
            var entity = _mapper.Map<TEntity>(model);
            return await OnSaveAsync(entity, cancellationToken);
        }

        protected TEntity OnSave(TEntity entity)
        {
            if (IsValid(entity) is false) return default;
            _repository.Add(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        protected TEntity OnEdit(TEntity entity)
        {
            if (IsValid(entity) is false) return default;
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        protected async Task<TEntity> OnEditAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (IsValid(entity) is false) return default;
            await _repository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        protected async Task<TEntity> OnSaveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (IsValid(entity) is false) return default;
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        private bool IsValid(TEntity entity)
        {
            switch (entity)
            {
                case {IsValid: false}:
                    _notificationContext.AddNotifications(entity.ValidationResult);
                    return default;
                case null:
                    _notificationContext.AddNotificationWithType(Resource.Object_Null, typeof(TEntity));
                    return default;
                default:
                    return true;
            }
        }

        private bool IsValid(TModel model)
        {
            if (model is {}) return true;
            _notificationContext.AddNotificationWithType(Resource.Object_Null, typeof(TEntity));
            return default;
        }

        private bool IsValid(TId id)
        {
            if (Equals(id, default(TId)) is false) return true;
            _notificationContext.AddNotificationWithType(Resource.Identifier_Invalid, typeof(TEntity));
            return default;
        }
    }
}