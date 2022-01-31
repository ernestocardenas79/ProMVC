using EssentialTools.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimunDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            //arrange
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            //act
            var discountedTotal = target.ApplyDiscount(total);

            // asert
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            //arrange
            IDiscountHelper target = getTestObject();

            //act
            var TenDollarDiscount = target.ApplyDiscount(10);
            var HundredDollarDiscount = target.ApplyDiscount(100);
            var FiftyDollarDiscount = target.ApplyDiscount(50);

            // asert
            Assert.AreEqual(5, TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftyDollarDiscount, "$45 discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            //arrange
            IDiscountHelper target = getTestObject();

            //act
            var discout5 = target.ApplyDiscount(5);
            var discout0 = target.ApplyDiscount(0);

            // asert
            Assert.AreEqual(5, discout5);
            Assert.AreEqual(0, discout0 );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Nengative_Total()
        {
            //arrange
            IDiscountHelper target = getTestObject();

            //act
            target.ApplyDiscount(-1);
        }
    }
}
