using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightCore.Abstract
{
    public class NHAPageTest : PageTest
    {
        public string siteEnv => TestConfig.GetVarFor<string>("NHA_ENV", "PRD");
    }
}
