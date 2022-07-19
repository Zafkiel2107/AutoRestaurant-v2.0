using AutoRestaurant.Models.BaseModels;
using System;
using System.Collections.Generic;

namespace AutoRestaurant.Interfaces
{
    public interface IDatabase
    {
        IEnumerable<TEntity> GetElements<TEntity>() where TEntity : BaseEntity;
        TEntity GetElementById<TEntity>(Guid id) where TEntity : BaseEntity;
        void Create<TEntity>(TEntity item) where TEntity : BaseEntity;
        void Update<TEntity>(TEntity item) where TEntity : BaseEntity;
        void Delete<TEntity>(Guid id) where TEntity : BaseEntity;
    }
}
