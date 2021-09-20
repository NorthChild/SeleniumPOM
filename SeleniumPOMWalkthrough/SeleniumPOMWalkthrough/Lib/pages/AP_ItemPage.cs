using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.Lib.pages
{
    public class AP_ItemPage
    {
        private IWebDriver _seleniumDriver;
        // set homepageurl
        private string _userPageUrl = AppConfigReader.UserPageURL;


        private IWebElement _itemSelection => _seleniumDriver.FindElement(By.Id("item_4_img_link"));

        public AP_ItemPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;


        public void GoToUserPage() => _seleniumDriver.Navigate().GoToUrl(_userPageUrl);
        
        public void ClickItemToView() => _itemSelection.Click();



    }
}
