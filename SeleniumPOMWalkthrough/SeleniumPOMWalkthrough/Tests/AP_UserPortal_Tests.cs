using SeleniumPOMWalkthrough.Lib.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace SeleniumPOMWalkthrough.Tests
{
    public class AP_UserPortal_Tests
    {

        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();


        [Test]
        public void WhenImOnTheInventoryPage_WhenIclickTheBasketIcon_ThenIShouldBeAbleToViewMyCart()
        {

            // navigate to api homepage
            AP_Website.AP_HomePage.VisitHomePage();
            // login
            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();

            // navigate to userPage
            AP_Website.AP_UserPage.GoToUserPage();
            AP_Website.AP_UserPage.ClickShoppingCartButton();

            var result = AP_Website.AP_UserPage.GetHeaderText();

            Assert.That(result, Does.Contain("YOUR CART"));
            
        }















        [OneTimeTearDown]
        public void CleanUp()
        {
            // quits driver and all associated windows
            AP_Website.SeleniumDriver.Quit();

            // release and manage resources
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
