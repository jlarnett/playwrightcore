using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightCore.Helpers
{
    public static class Navigation
    {
        public static string siteEnv => TestConfig.GetVarFor<string>("NHA_ENV", "prod");
        public static string _baseUrl => TestConfig.NHA_Social_Url.SetBaseUrl(siteEnv);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<IPage> LoginAsync(this IPage page, string username, string password)
        {
            await page.GotoAsync(_baseUrl);
            await page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
            await page.GetByLabel("Email").FillAsync(username);
            await page.GetByLabel("Password").FillAsync(password);
            await page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

            return page;
        }
    }
}
