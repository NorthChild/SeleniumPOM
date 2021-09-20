using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.Lib.driver_config
{
    public class SerleniumDriverConfig
    {
        public class SeleniumDriverConfig<T> where T : IWebDriver, new()
        {
            public IWebDriver Driver { get; set; }

            // constructor which calls a method to set up the driver depending on the browser we want
            public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSec)
            {
                Driver = new T();

                DriverSetUp(pageLoadInSecs, implicitWaitInSec);
            }

            public void DriverSetUp(int pageLoadInSecs, int implicitWaitInSec)
            {
                // this is the time the driver will wait for the page to lead
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);

                // this is the time the driver waits for the element before test fails
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSec);

            }



            public void SetHeadlessChromeBrowser()
            {
                Driver = new ChromeDriver();
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("headless");
            }
        }
    }
}
