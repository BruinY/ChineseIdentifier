using ChineseIdentifier;
using FluentAssertions;
using NUnit.Framework;

namespace ChineseIndentifier.Tests
{
    [TestFixture]
    public class ResxCheckerTests
    {
        private ResxChecker resxChecker;

        [SetUp]
        public void Setup()
        {
            resxChecker = new ResxChecker();
        }

        [Test]
        public void Given_Traditional_Resx_File_That_Is_Ok_Expect_True()
        {
            var expected = new IdentificationResults { WasMatch = true };
            var actual = resxChecker.IsOfType(ChineseType.Traditional, @"C:\Dev\Misc\ChineseIdentifier\ChineseIdentifier.TestHarness\App_GlobalResources\Global.zh-HK.resx");
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Given_Simplified_Resx_File_That_Is_Ok_Expect_True()
        {
            var expected = new IdentificationResults { WasMatch = true };
            var actual = resxChecker.IsOfType(ChineseType.Simplified, @"C:\Dev\Misc\ChineseIdentifier\ChineseIdentifier.TestHarness\App_GlobalResources\Global.zh-CN.resx");
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Given_Simplified_Resx_File_But_Expecting_Traditional_Expect_False_With_Message()
        {
            var expected = new IdentificationResults
            {
                WasMatch = false,
                Message = "Mismatch found in file: C:\\Dev\\Misc\\ChineseIdentifier\\ChineseIdentifier.TestHarness\\App_GlobalResources\\Global.zh-CN.resx.\nExpected Traditional, but found issue in resource Content."
            };
            var actual = resxChecker.IsOfType(ChineseType.Traditional, @"C:\Dev\Misc\ChineseIdentifier\ChineseIdentifier.TestHarness\App_GlobalResources\Global.zh-CN.resx");
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
