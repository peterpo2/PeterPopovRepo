using Cosmetics.Models;
using Cosmetics.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using static Cosmetics.Tests.Helpers.TestData;

namespace Cosmetics.Tests.Models
{
    [TestClass]
    public class CreamTests
    {
        [TestMethod]
        public void Constructor_Should_ThrowException_When_NameLengthOutOfBounds()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Cream(
                    name: CreamData.InvalidName,
                    brand: CreamData.ValidBrand,
                    price: 10m,
                    gender: GenderType.Men,
                    scent: ScentType.Lavender));
        }

        [TestMethod]
        public void Constructor_Should_ThrowException_When_BrandLengthOutOfBounds()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Cream(
                    name: CreamData.ValidName,
                    brand: CreamData.InvalidBrand,
                    price: 10m,
                    gender: GenderType.Women,
                    scent: ScentType.Lavender));
        }

        [TestMethod]
        public void Constructor_Should_ThrowException_When_PriceIsNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Cream(CreamData.ValidName, CreamData.ValidBrand, -1m, GenderType.Men, ScentType.Lavender));
        }

        [TestMethod]
        public void Constructor_Should_CreateCream_When_ValidValuesArePassed()
        {
            var cream = new Cream(CreamData.ValidName, CreamData.ValidBrand, 10m, GenderType.Women, ScentType.Lavender);
            Assert.IsInstanceOfType(cream, typeof(Cream));
        }
    }
}
