using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightCore.Abstract
{
    public class NHAPageTest : BrowserTest
    {
        public string siteEnv => TestConfig.GetVarFor<string>("NHA_ENV", "prod");
        public IBrowserContext _browserContext;

        /// <summary>
        /// Creates the logged in & logged out storage states. To be used, by almost all tests. 
        /// </summary>
        /// <returns></returns>
        []
        public async Task CreateLoginState()
        {
            var user = TestConfig.GetVarFor<string>("NHA_ADMIN_USER");
            var password = TestConfig.GetVarFor<string>("NHA_ADMIN_PASS");

            string baseUrl = TestConfig.NHA_Social_Url.SetBaseUrl(TestConfig.GetVarFor<string>("NHA_ENV", "PRD"));

            var result = Playwright.Devices;
            var page = await (await NewContext()).NewPageAsync();

            await page.GotoAsync(baseUrl);

            await page.Context.StorageStateAsync(new()
            {
                Path = "basicState.json"
            });

            await page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
            await page.GetByLabel("Email").FillAsync(user);
            await page.GetByLabel("Password").FillAsync(password);
            await page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

            await Expect(page.Locator("#MainPostTextboxContainer")).ToBeVisibleAsync(new () {Timeout = 15_000});
        
            await page.Context.StorageStateAsync(new()
            {
                Path = "loggedInState.json"
            });
        }

        public async Task<IPage> LoadLoggedInBrowserAsync()
        {
            _browserContext = await NewContext(new() { StorageState = "loggedInState.json" });
            return await _browserContext.NewPageAsync();
        }
    }
}
