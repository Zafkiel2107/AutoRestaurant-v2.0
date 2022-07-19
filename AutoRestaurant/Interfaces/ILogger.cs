using System;

namespace AutoRestaurant.Interfaces
{
    public interface IExceptionLogger
    {
        void CreateLog(Exception ex);
    }
}
