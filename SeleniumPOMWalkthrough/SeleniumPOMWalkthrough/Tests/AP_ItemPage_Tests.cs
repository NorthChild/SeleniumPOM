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
    public class AP_ItemPage_Tests
    {

        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();


        [Test]
        public void WhenImOnTheInventoryPage_WhenIclickOnAnItem_ThenIShouldBeAbleToViewTheItem()
        {

            // navigate to api homepage
            AP_Website.AP_HomePage.VisitHomePage();
            // login
            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();

            // navigate to userPage
            AP_Website.AP_UserPage.GoToUserPage();
            AP_Website.AP_UserPage.ClickItemToView();

            Assert.That(AP_Website.AP_UserPage.GetPageUrl(), Is.EqualTo("https://www.saucedemo.com/inventory-item.html?id=4"));

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
