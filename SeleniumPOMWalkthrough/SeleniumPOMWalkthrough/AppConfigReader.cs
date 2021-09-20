using System;
using System.Configuration;

namespace SeleniumPOMWalkthrough
{
    // this class is created to be a global reader for the app.config attributes
    public static class AppConfigReader
    {
        public static readonly string BaseURL = ConfigurationManager.AppSettings["base_url"];
        public static readonly string SignInPageURL = ConfigurationManager.AppSettings["signinpage_url"];


    }
}
