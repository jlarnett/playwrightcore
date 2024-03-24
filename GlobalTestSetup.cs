using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void InitializeLoggedInState()
    {
    }


}
