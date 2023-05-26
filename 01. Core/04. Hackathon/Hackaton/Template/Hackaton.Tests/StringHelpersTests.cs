using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hackaton
{
    [TestClass]
    public class StringHelpersTests
    {
        [TestMethod]
        public void Abbreviate_Should_Abbreviate_Input()
        {
            string word = "Company";
            string expected = "Compan...";

            string result = StringHelpers.Abbreviate(word, 6);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abbreviate_Returns_Unchanged_When_LongerLength()
        {
            string word = "Company";
            string expected = "Company";

            string result = StringHelpers.Abbreviate(word, 30);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abbreviate_Returns_Empty_When_EmptyString()
        {
            string word = "";
            string expected = "";

            string result = StringHelpers.Abbreviate(word, 30);

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Capitalize_Should_Return_CapitalizedString()
        {
            string source = "company";
            string expected = "Company";

            string result = StringHelpers.Capitalize(source);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Capitalize_Returns_Empty_when_StringEmpty()
        {
            string source = "";
            string expected = "";

            string result = StringHelpers.Capitalize(source);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Capitalize_ShouldNot_ChangeOtherCharacters()
        {
            string source = "Company";
            string expected = "Company";

            string result = StringHelpers.Capitalize(source);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Concat_Should_Concatenate()
        {
            string word1 = "New";
            string word2 = " Company";
            string expected = "New Company";

            string actual = StringHelpers.Concat(word1, word2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_Should_ReturnTrue_When_StringContainsCharacter()
        {
            string word = "Company";

            bool result = StringHelpers.Contains(word, 'm');

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_Should_ReturnFalse_When_StringDoesNotContainCharacter()
        {
            string word = "Company";

            bool result = StringHelpers.Contains(word, 'q');

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartsWith_ReturnsTrue_When_StringStartsWithTarget()
        {
            string word = "Company";

            bool result = StringHelpers.StartsWith(word, 'C');

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void StartsWith_ReturnsFalse_When_StringDoesntStartWithTarget()
        {
            string word = "Company";

            bool result = StringHelpers.StartsWith(word, 'q');

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartsWith_ReturnsFalse_When_StringEmpty()
        {
            string word = "";

            bool result = StringHelpers.StartsWith(word, 'q');

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EndsWith_Should_ReturnTrue_When_StringEndsWithTarget()
        {
            string word = "Company";

            bool result = StringHelpers.EndsWith(word, 'y');

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EndsWith_Should_ReturnFalse_When_StringDoesntEndWithTarget()
        {
            string word = "Company";

            bool result = StringHelpers.EndsWith(word, 'k');

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EndsWith_ReturnsFalse_When_StringEmpty()
        {
            string word = "";

            bool result = StringHelpers.EndsWith(word, 'k');

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void FirstIndexOf_Should_ReturnIndex_When_StringContainsCharacter()
        {
            string word = "Company";

            int result = StringHelpers.FirstIndexOf(word, 'm');

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void FirstIndexOf_Should_ReturnMinusOne_When_StringDoesNotContainChar()
        {
            string word = "Company";

            int result = StringHelpers.FirstIndexOf(word, 'w');

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void FirstIndexOf_Should_ReturnMinusOne_When_StringIsEmpty()
        {
            string word = "";

            int result = StringHelpers.FirstIndexOf(word, 'w');

            Assert.AreEqual(-1, result);
        }


        [TestMethod]
        public void LastIndexOf_Should_ReturnIndex_When_StringContainsCharacter()
        {
            string word = "New Company";

            int result = StringHelpers.LastIndexOf(word, 'n');

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void LastIndexOf_Should_ReturnMinusOne_When_StringDoesNotContain()
        {
            string word = "Company";

            int result = StringHelpers.LastIndexOf(word, 'w');

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void LastIndexOf_Should_ReturnMinusOne_When_StringIsEmpty()
        {
            string word = "";

            int result = StringHelpers.LastIndexOf(word, 'w');

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Pad_Should_PadString_FromBothSides()
        {
            string source = "Company";
            char paddingSymbol = '-';
            string expected = "---Company---";

            string result = StringHelpers.Pad(source, expected.Length, paddingSymbol);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pad_Should_PadEvenly_FromBothSides()
        {
            string source = "Company";
            char paddingSymbol = '-';
            string expected = "-Company-";

            string result = StringHelpers.Pad(source, 10, paddingSymbol);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pad_ReturnsSource_When_Longer()
        {
            string source = "Company";
            char paddingSymbol = '-';
            string expected = "Company";

            string result = StringHelpers.Pad(source, 1, paddingSymbol);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PadEnd_Should_Return_PaddedString()
        {
            string source = "Company";
            char paddingSymbol = '-';
            string expected = "Company---";

            string result = StringHelpers.PadEnd(source, expected.Length, paddingSymbol);

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void PadStart_Should_ReturnPaddedString()
        {
            string source = "Company";
            char paddingSymbol = '-';
            string expected = "---Company";

            //Act
            string actual = StringHelpers.PadStart(source, expected.Length, paddingSymbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Repeat_Should_ReturnSourceRepeated()
        {
            string word = "C#";
            string expected = "C#C#C#C#";

            string result = StringHelpers.Repeat(word, 4);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Reverse_Should_ReverseString()
        {
            string word = "Company";
            string expected = "ynapmoC";

            string result = StringHelpers.Reverse(word);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Section_Should_ReturnCorrectPartOfTheSourceString()
        {
            string source = "xxCompanyxx";
            string expected = "Company";

            string result = StringHelpers.Section(source, 2, 8);

            Assert.AreEqual(expected, result);

        }
    }
}
