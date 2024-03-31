using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightCore.Abstract;
using PlaywrightCore.Helpers;

namespace PlaywrightCore;

public class UserLoginTests : NHAPageTest
{
    private string baseUrl;

    [OneTimeSetUp]
    public void Setup()
    {
        baseUrl = TestConfig.NHA_Social_Url.SetBaseUrl(siteEnv);
    }

    [Test]
    public async Task Login()
    {
        var user = TestConfig.GetVarFor<string>("NHA_ADMIN_USER");
        var password = TestConfig.GetVarFor<string>("NHA_ADMIN_PASS");
        await Page.LoginAsync(user!, password!);
        await Expect(Page.Locator("#BasicPostForm")).ToBeVisibleAsync();
    }

    [Test]
    public async Task CreatePost()
    {
        var user = TestConfig.GetVarFor<string>("NHA_ADMIN_USER");
        var password = TestConfig.GetVarFor<string>("NHA_ADMIN_PASS");
        await Page.LoginAsync(user!, password!);
        var postTextBox = Page.Locator("#MainPostTextboxContainer .note-editable");

        var currentDateTime = DateTime.UtcNow;

        await postTextBox.FillAsync($"Playwright Test Post - {currentDateTime}");
        await Page.Locator("#SubmitBtn").ClickAsync(new () {Timeout = 10_000});
        await Expect(Page.Locator("#ContentFeed")).ToContainTextAsync($"Playwright Test Post - {currentDateTime}", new() {Timeout = 10_000});
    }
}