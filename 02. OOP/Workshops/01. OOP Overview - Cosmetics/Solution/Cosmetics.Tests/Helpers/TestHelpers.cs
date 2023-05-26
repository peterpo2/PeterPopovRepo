using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Tests.Helpers
{
    public class TestHelpers
    {
        /**
         * Returns a new List with size equal to wantedSize.
         * Useful when you do not care what the contents of the List are,
         * for example when testing if a list of a command throws exception
         * when it's parameters list's size is less/more than expected.
         *
         * @param wantedSize the size of the List to be returned.
         * @return a new List with size equal to wantedSize
         */
        public static List<string> InitializeListWithSize(int wantedSize)
        {
            return new string[wantedSize].ToList();
        }

        public static Repository InitializeRepository()
        {
            return new Repository();
        }

        public static Category InitializeCategory()
        {
            return new Category(TestData.CategoryData.ValidName);
        }

        public static Product InitializeProduct()
        {
            return new Product(TestData.ProductData.ValidName, TestData.ProductData.ValidBrand, 10, GenderType.Unisex);
        }

        public static Category AddInitializedCategoryToRepo(IRepository repository)
        {
            repository.CreateCategory(TestData.CategoryData.ValidName);
            return repository.FindCategoryByName(TestData.CategoryData.ValidName);
        }

        public static Product AddInitializedProductToRepo(IRepository repository)
        {
            repository.CreateProduct(
                TestData.ProductData.ValidName,
                TestData.ProductData.ValidBrand,
                10, GenderType.Unisex);
            return repository.FindProductByName(TestData.ProductData.ValidName);
        }
    }
}
