using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.Lib.pages
{
    public class AP_UserPage
    {
        private IWebDriver _seleniumDriver;
        // set homepageurl
        private string _userPageUrl = AppConfigReader.UserPageURL;

        private IWebElement _shoppingCartButton => _seleniumDriver.FindElement(By.Id("shopping_cart_container"));
        private IWebElement _header => _seleniumDriver.FindElement(By.Id("header_container"));
        private IWebElement _itemSelection => _seleniumDriver.FindElement(By.Id("item_4_img_link"));
        



        public AP_UserPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        public void GoToUserPage() => _seleniumDriver.Navigate().GoToUrl(_userPageUrl);
        public void ClickShoppingCartButton() => _shoppingCartButton.Click();
        public string GetHeaderText() => _header.Text;

        public void ClickItemToView() => _itemSelection.Click();

        public string GetPageUrl() => _seleniumDriver.Url.ToString();


    }
}
