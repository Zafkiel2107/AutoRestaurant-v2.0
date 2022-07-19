using System;

namespace AutoRestaurant.Models.BaseModels
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
