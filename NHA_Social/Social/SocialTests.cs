using PlaywrightCore.Abstract;
using PlaywrightCore.Helpers;
using PlaywrightCore.NHA_Social.Configuration;

namespace PlaywrightCore.NHA_Social.Social
{
    [TestFixture]
    public class SocialTests : NhaPageTest
    {
        /// <summary>
        /// This test creates a basic social post & verifies it was added to ContentFeed
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreatePost()
        {
            //Get user information from env file
            var user = TestConfig.GetVarFor<string>("NHA_ADMIN_USER");
            var password = TestConfig.GetVarFor<string>("NHA_ADMIN_PASS");

            //Login
            await Page.LoginAsync(user!, password!);

            //Create new basic post
            var currentDateTime = DateTime.UtcNow;
            var postTextBox = Page.Locator("#MainPostTextboxContainer .note-editable");
            await postTextBox.FillAsync($"Playwright Test Post - {currentDateTime}");
            await Page.Locator("#SubmitBtn").ClickAsync(new() { Timeout = 10_000 });

            //Verify new post is present in content feed
            await Expect(Page.Locator("#ContentFeed")).ToContainTextAsync($"Playwright Test Post - {currentDateTime}", new() { Timeout = 10_000 });
        }
    }
}
