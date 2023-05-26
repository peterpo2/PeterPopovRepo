using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using Cosmetics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics.Tests.Helpers
{
    internal class TestHelpers
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

        public static ICategory InitializeCategory()
        {
            return new Category(TestData.CategoryData.ValidName);
        }

        public static IProduct InitializeTestProduct()
        {
            return new Shampoo(
                                TestData.ShampooData.ValidName,
                                TestData.ShampooData.ValidBrand,
                                10m,
                                GenderType.Unisex,
                                100,
                                UsageType.EveryDay);
        }
        public static ICategory AddInitializedCategoryToRepo(IRepository repository)
        {
            repository.CreateCategory(TestData.CategoryData.ValidName);
            return repository.FindCategoryByName(TestData.CategoryData.ValidName);
        }

        public static IProduct AddInitializedProductToRepo(IRepository repository)
        {
            repository.CreateShampoo(
                TestData.ShampooData.ValidName,
                TestData.ShampooData.ValidBrand,
                10m, GenderType.Unisex,
                100, UsageType.EveryDay);
            return repository.FindProductByName(TestData.ShampooData.ValidName);
        }
    }
}
