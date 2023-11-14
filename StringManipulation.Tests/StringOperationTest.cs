using Humanizer;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Tests
{
    public class StringOperationTest
    {
        
        public StringOperationTest()
        {
                
        }

        [Fact(Skip = "only test, Ticket-001 ")]
        public void ConcatenateStrings_Skip_Test()
        {
            var strOperations = new StringOperations();


            var result = strOperations.ConcatenateStrings("Hello", "World");

            var expected = "Hello World";
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConcatenateStrings_Test()
        {
            var strOperations = new StringOperations();


            var result = strOperations.ConcatenateStrings("Hello", "World");

            var expected = "Hello World";
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReverseStringTest()
        {
            var strOperations = new StringOperations();


            var result = strOperations.ReverseString("Hello");

            var expected = "olleH";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetStringLengthTest()
        {
            var strOperations = new StringOperations();


            var result = strOperations.GetStringLength("Hello");

            var expected = 5;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetStringLength_NullParameter_Test()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(()=>strOperations.GetStringLength(null));
        }

        [Fact]
        public void RemoveWhitespaceTest()
        {
            var strOperations = new StringOperations();


            var result = strOperations.RemoveWhitespace("Hello World");

            var expected = "HelloWorld";
            Assert.Equal(expected, result);
            Assert.DoesNotContain(result, " ");
        }

        [Fact]
        public void TruncateStringTest()
        {
            var strOperations = new StringOperations();


            var result = strOperations.TruncateString("Hello", 3);

            var expected = "Hel";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TruncateString_StringNull_Test()
        {
            var strOperations = new StringOperations();


            var result = strOperations.TruncateString("", 3);

            var expected = "";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TruncateString_MaxLength0_Test()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("Hello", 0));
        }

        [Fact]
        public void IsPalindrome_True_Test()
        {
            var strOperations = new StringOperations();


            var result = strOperations.IsPalindrome("ana");

            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False_Test()
        {
            var strOperations = new StringOperations();


            var result = strOperations.IsPalindrome("Hello");

            Assert.False(result);
        }

        [Theory]
        [InlineData("ana", true)]
        [InlineData("Ana", true)]
        [InlineData("Hello", false)]
        public void IsPalindrome_Test(string word, bool expected)
        {
            var strOperations = new StringOperations();


            var result = strOperations.IsPalindrome(word);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void CountOccurrencesTest()
        {
            var mock = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mock.Object);

            var result = strOperations.CountOccurrences("Hello World", 'l');

            var expected = 3;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PluralizeTest()
        {
            var strOperations = new StringOperations();


            var result = strOperations.Pluralize("Dog");

            var expected = "Dogs";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void QuantintyInWords_singular_Test()
        {
            var strOperations = new StringOperations();


            var result = strOperations.QuantintyInWords("Dog", 1);

            var expected = "one Dog";
            Assert.StartsWith("one", result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void QuantintyInWords_Plural_Test()
        {
            var strOperations = new StringOperations();


            var result = strOperations.QuantintyInWords("Dog", 7);

            var expected = "seven Dogs";
            Assert.StartsWith("seven", result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromRomanToNumberTest()
        {
            var strOperations = new StringOperations();


            var result = strOperations.FromRomanToNumber("XV");

            var expected = 15;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        [InlineData("C", 100)]
        public void FromRomanToNumber_MultipleParameters_Test(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();


            var result = strOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadFileTest()
        {
            var strOperations = new StringOperations();
            var mockReader = new Mock<IFileReaderConector>();
            mockReader.Setup(x => x.ReadString("file.txt")).Returns("Reading File");

            var actual = strOperations.ReadFile(mockReader.Object, "file.txt");

            var expected = "Reading File";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadFile_Configuration_Fail_Test()
        {
            var strOperations = new StringOperations();
            var mockReader = new Mock<IFileReaderConector>();
            mockReader.Setup(x => x.ReadString("a word")).Returns("Reading File");

            var actual = strOperations.ReadFile(mockReader.Object, "other word");

            Assert.Null(actual);
        }

        [Fact]
        public void ReadFile_Configuration_It_Test()
        {
            var strOperations = new StringOperations();
            var mockReader = new Mock<IFileReaderConector>();
            mockReader.Setup(x => x.ReadString(It.IsAny<string>())).Returns("Reading File");

            var actual = strOperations.ReadFile(mockReader.Object, "file.txt");

            var expected = "Reading File";
            Assert.Equal(expected, actual);
        }
    }
}
