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

        /// <summary>
        /// Logs the user into NHA Social. Uses the supplied user and password
        /// </summary>
        /// <param name="page"></param>
        /// <param name="username">Email address of the user you want to log in with</param>
        /// <param name="password">User password</param>
        /// <returns></returns>
        public static async Task<IPage> LoginAsync(this IPage page, string username, string password)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
            await page.GetByLabel("Email").FillAsync(username);
            await page.GetByLabel("Password").FillAsync(password);
            await page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

            return page;
        }

        /// <summary>
        /// Navigates user to NHA home page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task<IPage> GoToHomeAsync(this IPage page)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Home" }).ClickAsync();
            return page;
        }

        /// <summary>
        /// Navigates user to NHA Anime
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task<IPage> GoToAnimeAsync(this IPage page)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Anime Wiki" }).ClickAsync();
            return page;
        }

        /// <summary>
        /// Navigates user to NHA Forums
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task<IPage> GoToForumsAsync(this IPage page)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Forums" }).ClickAsync();
            return page;
        }

        /// <summary>
        /// Navigates user to NHA Crypto
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task<IPage> GoToCryptoAsync(this IPage page)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Crypto Stats" }).ClickAsync();
            return page;
        }

    }
}
