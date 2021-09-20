using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumPOMWalkthrough.Lib.driver_config;


namespace SeleniumPOMWalkthrough.Lib.pages
{
    // superClass - essentially a service object for all pages
    public class AP_Website<T> where T : IWebDriver, new()
    {
        #region
        // properties - accessing POs and selenium driver
        public IWebDriver SeleniumDriver { get; set; }
        public AP_HomePage AP_HomePage { get; set; }
        public AP_UserPage AP_UserPage { get; set; }
        public AP_UserPage AP_ItemPage { get; set; }
        #endregion


        // constructor for driver and config for this service
        public AP_Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10)
        {
            // instantiate driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs).Driver;

            // instantiate object with the selenium driver
            AP_HomePage = new AP_HomePage(SeleniumDriver);
            AP_UserPage = new AP_UserPage(SeleniumDriver);
        }


        // delete cookies 
        public void DeleteCookies() => SeleniumDriver.Manage().Cookies.DeleteAllCookies();


    }


}
