using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightCore;

[SetUpFixture]
public class GlobalTestSetup
{
    [OneTimeSetUp]
    public void InitializeEnvironment()
    {
        //string env = Environment.GetEnvironmentVariable("NHA_ENV");
        
        //Loads the .env environment variable file.  
        DotNetEnv.Env
            .TraversePath()
            .Load();

    }
}
