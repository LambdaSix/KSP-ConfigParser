using Xunit;
using parse.Extensions;

namespace parse.Tests.Extensions
{
    public class StringExtensionsTests
    {
        //TODO: Use MemberData and split this test into three separate tests

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("", "", null, null)]
        [InlineData("//", "", null, "")]
        [InlineData("A//", "A", null, "")]
        [InlineData("A//B", "A", null, "B")]
        [InlineData("A B C D  // BXY", "A B C D  ", null, " BXY")]
        [InlineData("B C D  // BXY//XYZ", "B C D  ", null, " BXY//XYZ")]
        [InlineData("=", "", "", null)]
        [InlineData("=//", "", "", "")]
        [InlineData("x=3//C", "x", "3", "C")]
        [InlineData("PART {", "PART {", null, null)]
        [InlineData("PART { v = 2 // test", "PART { v ", " 2 ", " test")]
        [InlineData("y=4 //C=DV", "y", "4 ", "C=DV")]
        [InlineData("PART { // Y=4", "PART { ", null, " Y=4")]
        public void ParseLine_works_correctly(string input, string expectedData, string expectedValue, string expectedComment)
        {
            var result = input.ParseLine();
            Assert.Equal(expectedData, result.Data);
            Assert.Equal(expectedValue, result.Value);
            Assert.Equal(expectedComment, result.Comment);
        }
    }
}