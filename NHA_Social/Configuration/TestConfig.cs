namespace PlaywrightCore.NHA_Social.Configuration;

public static class TestConfig
{
    public static string NHA_Social_Url = "https://nhaindustries.--env--azurewebsites.net/";

    /// <summary>
    /// String extension method. Takes in NHA URL and converts it to the correct environment. 
    /// </summary>
    /// <param name="thisUrl"></param>
    /// <param name="env"></param>
    /// <returns></returns>
    public static string SetBaseUrl(this string thisUrl, string env = "uat")
    {
        var localEnv = Environment.GetEnvironmentVariable("NHA_ENV") ?? env;
        return thisUrl.Replace("--env--", localEnv == "prod" ? "" : localEnv);
    }


    /// <summary>
    /// Gets the value of environment variable and converts it to the correct type. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns>value in type of T</returns>
    public static T? GetVarFor<T>(string key, T? defaultValue = default)
    {
        var value = Environment.GetEnvironmentVariable(key);

        if (string.IsNullOrEmpty(value))
        {
            return defaultValue;
        }

        return value is T t ? t : (T)Convert.ChangeType(value, typeof(T));
    }
}
