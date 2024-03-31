using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightCore.Abstract
{
    public class NHAPageTest : PageTest
    {
        public string siteEnv => TestConfig.GetVarFor<string>("NHA_ENV", "prod");


        public async Task<IBrowserContext> LoadLoggedInBrowserAsync()
        {
            var browser = await Browser.NewContextAsync(new() { StorageStatePath = "loggedInState.json" });
            return browser;
        }
    }
}
