using ChineseIdentifier;
using FluentAssertions;
using NUnit.Framework;

namespace ChineseIndentifier.Tests
{
    [TestFixture]
    public class IdentifierTest
    {
        private Indentifier identifier;

        [SetUp]
        public void Setup()
        {
            identifier = new Indentifier();
        }

        [TestCase("這是一些將顯示的文本")]
        [TestCase("歡迎來到應用程序")]
        public void Given_String_With_Traditional_Chinese_Characters_Expect_It_Is_Reported_As_Traditional(string input)
        {
            var identifiedChineseType = identifier.Identify(input);

            identifiedChineseType.ShouldBeEquivalentTo(ChineseType.Traditional);
        }

        [TestCase("这是一些将显示的文本")]
        [TestCase("欢迎来到应用程序")]
        public void Given_String_With_Simplified_Chinese_Characters_Expect_It_Is_Reported_As_Simplified(string input)
        {
            var identifiedChineseType = identifier.Identify(input);

            identifiedChineseType.ShouldBeEquivalentTo(ChineseType.Simplified);
        }

        [TestCase("Some text")]
        [TestCase("Other text")]
        public void Given_String_With_Non_Chinese_Characters_Expect_It_Is_Reported_As_Unidentified(string input)
        {
            var identifiedChineseType = identifier.Identify(input);

            identifiedChineseType.ShouldBeEquivalentTo(ChineseType.Unidentified);
        }
    }
}
