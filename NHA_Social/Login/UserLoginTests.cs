using PlaywrightCore.Abstract;
using PlaywrightCore.Helpers;
using PlaywrightCore.NHA_Social.Configuration;

namespace PlaywrightCore.NHA_Social.Login;

[TestFixture]
public class UserLoginTests : NhaPageTest
{
    private string baseUrl;

    /// <summary>
    /// Checks that users can successfully log into NHA Social. Verifies the basic post form is present after logging in.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task Login()
    {
        //Get user information from env file. 
        var user = TestConfig.GetVarFor<string>("NHA_ADMIN_USER");
        var password = TestConfig.GetVarFor<string>("NHA_ADMIN_PASS");

        //Login
        await Page.LoginAsync(user!, password!);

        //Verify Post form is present
        await Expect(Page.Locator("#BasicPostForm")).ToBeVisibleAsync();
    }


}