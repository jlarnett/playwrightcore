using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightCore.Abstract;
namespace PlaywrightCore;

public class UserLoginTests : NHAPageTest
{
    private string baseUrl;

    [SetUp]
    public void Setup()
    {
        baseUrl = TestConfig.NHA_Social_Url.SetBaseUrl(siteEnv);
    }

    [Test]
    public async Task Login()
    {
        var user = TestConfig.GetVarFor<string>("NHA_ADMIN_USER");
        var password = TestConfig.GetVarFor<string>("NHA_ADMIN_PASS");

        var page = await Browser.NewPageAsync();
        await page.GotoAsync(baseUrl);
        await page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await page.GetByLabel("Email").FillAsync(user);
        await page.GetByLabel("Password").FillAsync(password);
        await page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

        await Expect(page.Locator("#BasicPostForm")).ToBeVisibleAsync();
    }

    [Test]
    public async Task CreatePost()
    {
        var page = await LoadLoggedInBrowserAsync();
        await page.Locator("../html/body/div[2]/div/main/div[1]/div[1]/div/div[2]/form/div/div/div[3]/div[3]/p").ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Upload Post" }).ClickAsync();
        await Expect(page.Locator("#HomeContentFeed")).ToContainTextAsync(
            "TESTING AUTOMATION TESTING AUTOMATION TESTING AUTOMATION TESTING AUTOMATION TESTING AUTOMATION TESTING");
    }
}