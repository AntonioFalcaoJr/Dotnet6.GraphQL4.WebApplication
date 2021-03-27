using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet6.GraphQL4.Repositories.Abstractions;
using Dotnet6.GraphQL4.Repositories.Abstractions.Pages;
using Dotnet6.GraphQL4.Repositories.Abstractions.UnitsOfWork;
using Dotnet6.GraphQL4.CrossCutting.Notifications;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;
using Dotnet6.GraphQL4.Services.Abstractions.Models;
using Dotnet6.GraphQL4.Services.Abstractions.Resources;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotnet6.GraphQL4.Services.Abstractions
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

        protected Service(IRepository<TEntity, TId> repository, IUnitOfWork unitOfWork, INotificationContext notificationContext, IMapper mapper)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
            NotificationContext = notificationContext;
            Mapper = mapper;
        }

        public virtual bool Delete(TId id)
        {
            if (IsValid(id) is false) return default;
            Repository.Delete(id);
            return UnitOfWork.SaveChanges();
        }

        public virtual bool Delete(TModel model)
        {
            if (IsValid(model) is false) return default;
            var entity = Mapper.Map<TEntity>(model);
            return OnDelete(entity);
        }

        public virtual async Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (IsValid(id) is false) return default;
            await Repository.DeleteAsync(id, cancellationToken);
            return await UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        
        public virtual async Task<bool> DeleteAsync(TModel model, CancellationToken cancellationToken)
        {
            if (IsValid(model) is false) return default;
            var entity = Mapper.Map<TEntity>(model);
            return await OnDeleteAsync(entity, cancellationToken);
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
            return await OnEditAsync(entity, cancellationToken);
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
            where TResult : class
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
            where TResult : class
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
            return await OnSaveAsync(entity, cancellationToken);
        }

        protected TEntity OnSave(TEntity entity)
        {
            if (IsValid(entity) is false) return default;
            Repository.Add(entity);
            return UnitOfWork.SaveChanges() ? entity : default;
        }

        protected TEntity OnEdit(TEntity entity)
        {
            if (IsValid(entity) is false) return default;
            Repository.Update(entity);
            return UnitOfWork.SaveChanges() ? entity : default;
        }

        protected bool OnDelete(TEntity entity)
        {
            if (IsValid(entity) is false) return default;
            Repository.Delete(entity);
            return UnitOfWork.SaveChanges();
        }

        protected async Task<TEntity> OnEditAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (IsValid(entity) is false) return default;
            await Repository.UpdateAsync(entity, cancellationToken);
            return await UnitOfWork.SaveChangesAsync(cancellationToken) ? entity : default;
        }

        protected async Task<TEntity> OnSaveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (IsValid(entity) is false) return default;
            await Repository.AddAsync(entity, cancellationToken);
            return await UnitOfWork.SaveChangesAsync(cancellationToken) ? entity : default;
        }
        
        protected async Task<bool> OnDeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (IsValid(entity) is false) return default;
            await Repository.DeleteAsync(entity, cancellationToken);
            return await UnitOfWork.SaveChangesAsync(cancellationToken);
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