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
        [TestCase("另一方面，我們以正義的憤慨和不喜歡那些被那些因為慾望而蒙蔽的那一刻的快樂魅力所迷惑和挫敗的人，他們不能預見到隨之而來的痛苦和麻煩; 和同樣的責任屬於那些通過意志薄弱而失敗的人，這與通過勉強和痛苦的說法是一樣的。 這些情況是非常簡單和容易區分。 在一個自由的時間，當我們的選擇權力沒有受到限制，沒有什麼能阻止我們能夠做我們最喜歡做的事情，每一個快樂是歡迎，每一個疼痛避免。 但是在某些情況下，由於義務的索賠或商業的義務，經常發生的是，樂趣必須被拒絕和煩惱被接受。 聰明人因此在這些事情上總是堅持這種選擇原則：他拒絕快樂，以確保其他更大的快樂，或者他忍受痛苦，以避免更糟的疼痛")]
        public void Given_String_With_Traditional_Chinese_Characters_Expect_It_Is_Reported_As_Traditional(string input)
        {
            var identifiedChineseType = identifier.Identify(input);

            identifiedChineseType.ShouldBeEquivalentTo(ChineseType.Traditional);
        }

        [TestCase("这是一些将显示的文本")]
        [TestCase("欢迎来到应用程序")]
        [TestCase("另一方面，我们以正义的愤慨和不喜欢那些被那些因为欲望而蒙蔽的那一刻的快乐魅力所迷惑和挫败的人，他们不能预见到随之而来的痛苦和麻烦; 和同样的责任属于那些通过意志薄弱而失败的人，这与通过勉强和痛苦的说法是一样的。 这些情况是非常简单和容易区分。 在一个自由的时间，当我们的选择权力没有受到限制，当没有什么阻止我们能够做我们最喜欢做的事情，每一个快乐是欢迎，每一个疼痛避免。 但是在某些情况下，由于义务的索赔或商业的义务，经常发生的是，乐趣必须被拒绝和烦恼被接受。 聪明人因此在这些事情上总是坚持这种选择原则：他拒绝快乐，以确保其他更大的快乐，或者他忍受痛苦，以避免更糟的疼痛")]
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
