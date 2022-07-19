using AutoRestaurant.Models.ControlModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoRestaurantTest
{
    [TestClass]
    public class LoggerControlTest
    {
        private ExceptionLoggerControl Logger { get; set; }
        public LoggerControlTest()
        {
            Logger = new ExceptionLoggerControl();
        }
        [TestMethod]
        public void CreateLogTest()
        {
            try
            {
                throw new Exception("TestException");
            }
            catch(Exception ex)
            {
                Logger.CreateLog(ex);
                Assert.IsTrue(true);
            }
        }
    }
}
