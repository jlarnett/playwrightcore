using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightCore.Abstract
{
    public static class PlaywrightAuthenticationStateHandler
    {
        public static async Task<IBrowserContext> LoadLoggedInState()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync();

            var context = await browser.NewContextAsync(new()
            {
                StorageStatePath = "loggedInState.json"
            });

            return context;
        }
    }
}
