using AutoRestaurant.ConnectionDb;
using AutoRestaurant.Interfaces;
using AutoRestaurant.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AutoRestaurant.Models.ControlModels
{
    public class AutoRestaurantDbControl : IDatabase, IDisposable
    {
        private AutoRestaurantDbContext Database { get; set; }
        public AutoRestaurantDbControl()
        {
            this.Database = new AutoRestaurantDbContext();
        }

        public void Create<TEntity>(TEntity item) where TEntity : BaseEntity
        {
            var entity = Database.Set<TEntity>();
            if (item != null)
                entity.Add(item);
            Database.SaveChanges();
        }

        public void Delete<TEntity>(Guid id) where TEntity : BaseEntity
        {
            var entity = Database.Set<TEntity>();
            var item = entity.Find(id);
            if (item != null)
                entity.Remove(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public TEntity GetElementById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            return Database.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetElements<TEntity>() where TEntity : BaseEntity
        {
            return Database.Set<TEntity>();
        }

        public void Update<TEntity>(TEntity item) where TEntity : BaseEntity
        {
            if (item != null)
                Database.Entry<TEntity>(item).State = EntityState.Modified;
            Database.SaveChanges();
        }
        #region Метод аутентификации пользователя
        public Autorization Authenticate(string login, string password)
        {
            var passwordHash = Autorization.GetHash(password);
            var auth = Database.Autorizations.FirstOrDefault(y => y.Login == login & y.Password == passwordHash);
            if(auth != null)
                return auth;
            else
                return null;
        }
        #endregion
    }
}