using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL3.CrossCutting.Notifications;
using Dotnet5.GraphQL3.Domain.Abstractions.Entities;
using Dotnet5.GraphQL3.Repositories.Abstractions;
using Dotnet5.GraphQL3.Repositories.Abstractions.Pages;
using Dotnet5.GraphQL3.Repositories.Abstractions.UnitsOfWork;
using Dotnet5.GraphQL3.Services.Abstractions.Models;
using Dotnet5.GraphQL3.Services.Abstractions.Resources;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotnet5.GraphQL3.Services.Abstractions
{
    public abstract class Service<TEntity, TModel, TId> : IService<TEntity, TModel, TId>
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        protected readonly IMapper Mapper;
        protected readonly INotificationContext NotificationContext;
        protected readonly IRepository<TEntity, TId> Repository;
        protected readonly IUnitOfWork UnitOfWork;

        protected Service(
            IUnitOfWork unitOfWork,
            IRepository<TEntity, TId> repository,
            IMapper mapper,
            INotificationContext notificationContext)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            Mapper = mapper;
            NotificationContext = notificationContext;
        }

        public virtual void Delete(TId id)
        {
            if (IsValid(id) is false) return;
            Repository.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            if (IsValid(entity) is false) return;
            Repository.Delete(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (IsValid(id) is false) return;
            await Repository.DeleteAsync(id, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public virtual TEntity Edit(TModel model)
        {
            if (IsValid(model) is false) return default;
            var entity = Mapper.Map<TEntity>(model);
            return OnEdit(entity);
        }

        public virtual async Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken)
        {
            if (IsValid(model) is false) return default;
            var entity = Mapper.Map<TEntity>(model);
            return await OnEditAsync(entity, cancellationToken).ConfigureAwait(default);
        }

        public virtual bool Exists(TId id)
            => IsValid(id) ? Repository.Exists(id) : default;

        public virtual async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken)
            => IsValid(id) ? await Repository.ExistsAsync(id, cancellationToken) : default;

        public virtual PagedResult<TEntity> GetAll(
            PageParams pageParams,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default)
            => Repository.GetAll(pageParams, predicate, orderBy, include, asTracking);
        
        public virtual PagedResult<TResult> GetAllProjections<TResult>(
            PageParams pageParams,
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default)
            => Repository.GetAllProjections(pageParams, selector, predicate, orderBy, include, asTracking);

        public virtual async Task<PagedResult<TEntity>> GetAllAsync(
            PageParams pageParams,
            CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default)
            => await Repository.GetAllAsync(pageParams, cancellationToken, predicate, orderBy, include, asTracking);
        
        public virtual async Task<PagedResult<TResult>> GetAllProjectionsAsync<TResult>(
            PageParams pageParams,
            CancellationToken cancellationToken,
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default)
            => await Repository.GetAllProjectionsAsync(pageParams, cancellationToken, selector, predicate, orderBy, include, asTracking);

        public virtual TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default) 
            => IsValid(id) ? Repository.GetById(id, include, asTracking) : default;

        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
            => IsValid(id) ? await Repository.GetByIdAsync(id, cancellationToken, include, asTracking) : default;

        public virtual TEntity Save(TModel model)
        {
            if (IsValid(model) is false) return default;
            var entity = Mapper.Map<TEntity>(model);
            return OnSave(entity);
        }

        public virtual async Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken)
        {
            if (IsValid(model) is false) return default;
            var entity = Mapper.Map<TEntity>(model);
            return await OnSaveAsync(entity, cancellationToken).ConfigureAwait(default);
        }

        protected TEntity OnSave(TEntity entity)
        {
            if (IsValid(entity) is false) return default;
            Repository.Add(entity);
            UnitOfWork.SaveChanges();
            return entity;
        }

        protected TEntity OnEdit(TEntity entity)
        {
            if (IsValid(entity) is false) return default;
            Repository.Update(entity);
            UnitOfWork.SaveChanges();
            return entity;
        }

        protected async Task<TEntity> OnEditAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (IsValid(entity) is false) return default;
            await Repository.UpdateAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        protected async Task<TEntity> OnSaveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (IsValid(entity) is false) return default;
            await Repository.AddAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        private bool IsValid(TEntity entity)
        {
            switch (entity)
            {
                case {IsValid: false}:
                    NotificationContext.AddNotifications(entity.ValidationResult);
                    return default;
                case null:
                    NotificationContext.AddNotificationWithType(ServicesResource.Object_Null, typeof(TEntity));
                    return default;
                default:
                    return true;
            }
        }

        private bool IsValid(TModel model)
        {
            if (model is not null) return true;
            NotificationContext.AddNotificationWithType(ServicesResource.Object_Null, typeof(TModel));
            return default;
        }

        private bool IsValid(TId id)
        {
            if (Equals(id, default(TId)) is false) return true;
            NotificationContext.AddNotificationWithType(ServicesResource.Identifier_Invalid, typeof(TEntity));
            return default;
        }
    }
}