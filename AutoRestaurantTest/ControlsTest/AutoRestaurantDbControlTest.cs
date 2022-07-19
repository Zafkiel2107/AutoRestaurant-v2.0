using AutoRestaurant.Models;
using AutoRestaurant.Models.ControlModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoRestaurantTest
{
    [TestClass]
    public class AutoRestaurantDbControlTest
    {
        private AutoRestaurantDbControl Db { get; set; }
        private Ingredient Ingredient { get; set; }
        public AutoRestaurantDbControlTest()
        {
            Db = new AutoRestaurantDbControl();
            Ingredient = new Ingredient();
        }
        [TestMethod]
        public void CreateTest()
        {
            Ingredient.Name = "TestIngredient";
            Db.Create<Ingredient>(Ingredient);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Ingredient.Name = "UpdateTestIngredient";
            Db.Update<Ingredient>(Ingredient);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GetElementByIdTest()
        {
            var result = Db.GetElementById<Ingredient>(Ingredient.Id);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetElementsTest()
        {
            var result = Db.GetElements<Ingredient>();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Db.Delete<Ingredient>(Ingredient.Id);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void AuthenticateTest()
        {
            var result = Db.Authenticate("admin", "admin");
            Assert.IsNotNull(result);
        }
    }
}
