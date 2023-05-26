using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hackaton
{
    [TestClass]
    public class ArrayHelpersTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        public void AddLast_Should(int[] source, int element, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.AddLast(source, element);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 2, 3, 4 }, 1, new int[] { 1, 2, 3, 4 })]
        public void AddFirst_Should(int[] source, int element, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.AddFirst(source, element);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void AppendAll_Should(int[] source, int[] elements, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.AppendAll(source, elements);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 2, true)]
        [DataRow(new int[] { 1, 2, 3 }, 4, false)]
        public void Contains_Should(int[] source, int element, bool expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.Contains(source, element);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new int[4] { 0, 0, 0, 0 }, new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[6] { 0, 0, 0, 0, 0, 0 }, new int[] { 1, 2, 3, 0, 0, 0 })]
        public void Copy_Should(int[] source, int[] destination, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            ArrayHelpers.Copy(source, destination, destination.Length);

            //Assert
            CollectionAssert.AreEqual(expected, destination);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 0, new int[4] { 0, 0, 0, 0 }, 1, 2, new int[] { 0, 1, 2, 0 })]
        [DataRow(new int[] { 1, 2, 3 }, 0, new int[5] { 0, 0, 0, 0, 0 }, 1, 2, new int[] { 0, 1, 2, 0, 0 })]
        [DataRow(new int[] { 1, 2, 3 }, 0, new int[4] { 0, 0, 0, 0 }, 1, 3, new int[] { 0, 1, 2, 3 })]
        public void CopyFrom_Should(int[] source, int sourceStartIndex, int[] destination, int destinationStartIndex, int count, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            ArrayHelpers.CopyFrom(source, sourceStartIndex, destination, destinationStartIndex, count);

            //Assert
            CollectionAssert.AreEqual(expected, destination);
        }

        [TestMethod]
        [DataRow(new int[4] { 0, 0, 0, 0 }, 1, new int[] { 1, 1, 1, 1 })]
        public void Fill_Should(int[] source, int element, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            ArrayHelpers.Fill(source, element);

            //Assert
            CollectionAssert.AreEqual(expected, source);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 7, -1)]
        [DataRow(new int[] { 1, 2, 3 }, 2, 1)]
        [DataRow(new int[] { 1, 2, 2, 3 }, 2, 1)]
        public void FirstIndexOf_Should(int[] source, int target, int expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.FirstIndexOf(source, target);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 7, -1)]
        [DataRow(new int[] { 1, 2, 3 }, 2, 1)]
        [DataRow(new int[] { 1, 2, 2, 3 }, 2, 2)]
        public void LastIndexOf_Should(int[] source, int target, int expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.LastIndexOf(source, target);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
        public void InsertAt_Should(int[] source, int index, int element, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.InsertAt(source, index, element);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, -1, false)]
        [DataRow(new int[] { 1, 2, 3 }, 0, true)]
        [DataRow(new int[] { 1, 2, 3 }, 1, true)]
        [DataRow(new int[] { 1, 2, 3 }, 2, true)]
        [DataRow(new int[] { 1, 2, 3 }, 3, false)]
        public void IsValidIndex_Should(int[] source, int index, bool expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.IsValidIndex(source, index);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 2, 4, 2, 5, 6 }, 2, new int[] { 1, 3, 4, 5, 6 })]
        [DataRow(new int[] { 1, 2, 3, 2, 4, 2, 5, 6 }, 7, new int[] { 1, 2, 3, 2, 4, 2, 5, 6 })]
        public void RemoveAllOccurences_Should(int[] source, int element, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.RemoveAllOccurrences(source, element);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void Reverse_Should(int[] source, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            ArrayHelpers.Reverse(source);

            //Assert
            CollectionAssert.AreEqual(expected, source);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 4, new int[] { 2, 3, 4, 5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 4, new int[] { 1, 2, 3, 4, 5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 10, new int[] { 3, 4, 5, 6 })]
        public void Section_Should(int[] source, int startIndex, int endIndex, int[] expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = ArrayHelpers.Section(source, startIndex, endIndex);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
