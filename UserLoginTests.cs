using Microsoft.Playwright;
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

        await Page.GotoAsync(baseUrl);
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Page.GetByLabel("Email").FillAsync(user);
        await Page.GetByLabel("Password").FillAsync(password);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

        await Expect(Page.Locator("#BasicPostForm")).ToBeVisibleAsync();
    }
}