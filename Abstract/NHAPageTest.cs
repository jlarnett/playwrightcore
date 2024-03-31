using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightCore.NHA_Social.Configuration;

namespace PlaywrightCore.Abstract
{
    public class NhaPageTest : PageTest
    {
        public string siteEnv => TestConfig.GetVarFor<string>("NHA_ENV", "prod")!;
        public string baseUrl;


        /// <summary>
        /// initializes baseUrl for all classes that derive from NhaPageTest
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            baseUrl = TestConfig.NHA_Social_Url.SetBaseUrl(siteEnv);
        }

        [SetUp]
        public async Task ClassSetup()
        {
            await Page.GotoAsync(baseUrl);
        }
    }
}
