using System.Text.RegularExpressions;
using PlaywrightCore.Abstract;
using PlaywrightCore.Helpers;

namespace PlaywrightCore.NHA_Social.Navigation
{
    [TestFixture(Description = "Navigation Tests")]
    public class NavigationTests : NhaPageTest
    {
        /// <summary>
        /// Checks that users can use the crypto navbar link. Verifies the URL has Crypto at the end.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task NavigateToCrypto()
        {
            await Page.GoToCryptoAsync();
            await Expect(Page).ToHaveURLAsync(new Regex(".+/Crypto$"));
        }

        /// <summary>
        /// Checks that users can use the Anime navbar link. Verifies the URL has Anime at the end.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task NavigateToAnime()
        {
            await Page.GoToAnimeAsync();
            await Expect(Page).ToHaveURLAsync(new Regex(".+/Anime$"));
        }
    }
}
