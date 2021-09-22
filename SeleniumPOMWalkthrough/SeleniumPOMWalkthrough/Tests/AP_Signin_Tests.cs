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
    public class AP_Signin_Tests
    {

        // instantiate out pages in out tests
        // these classes will include the functions for the page.
        // NO USING STATEMENTS

        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();


        /// <summary>
        /// HAPPY PATHS
        /// </summary>

        [Test]
        public void GiveIAmOnTheHomePage_WhenISignIn_WithAValidCredentials_ThenIShouldAppearInTheCustomerPortal()
        {
            // navigate to api homepage
            AP_Website.AP_HomePage.VisitHomePage();

            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();  


            // navigate to api signin page
            //AP_Website.AP_HomePage.VisitSignInPage();

            // assert that title is correct
            Assert.That(AP_Website.SeleniumDriver.Url, Does.Contain("inventory"));
        }




        /// <summary>
        /// SAD PATHS
        /// </summary>
        

        [Test]
        public void GiveIAmOnTheHomePage_WhenISignIn_WithAInValidPassword_ThenIShouldReceiveErrorMessage()
        {
            // navigate to api homepage
            AP_Website.AP_HomePage.VisitHomePage();

            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputPassword("");
            AP_Website.AP_HomePage.ClickLoginButton();


            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(), Is.EqualTo("Epic sadface: Password is required"));
        }

        [Test]
        public void GiveIAmOnTheHomePage_WhenISignIn_WithAInValidCredentials_ThenIShouldReceiveErrorMessage()
        {
            // navigate to api homepage
            AP_Website.AP_HomePage.VisitHomePage();

            AP_Website.AP_HomePage.InputUserName("");
            AP_Website.AP_HomePage.InputPassword("");
            AP_Website.AP_HomePage.ClickLoginButton();


            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(), Is.EqualTo("Epic sadface: Username is required"));
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
