using AutoRestaurant.Interfaces;
using System;

namespace AutoRestaurant.Models.ControlModels
{
    public class ExceptionLoggerControl : IExceptionLogger
    {
        private AutoRestaurantDbControl Db { get; set; }
        public ExceptionLoggerControl()
        {
            Db = new AutoRestaurantDbControl();
        }
        public void CreateLog(Exception ex)
        {
            var exDetail = new ExceptionDetail(ex);
            Db.Create<ExceptionDetail>(exDetail);
        }
    }
}
