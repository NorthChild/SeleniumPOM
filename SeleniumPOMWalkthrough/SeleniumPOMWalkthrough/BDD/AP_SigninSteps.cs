using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough;
using SeleniumPOMWalkthrough.Lib.pages;
using TechTalk.SpecFlow;
using SeleniumPOMWalkthrough.Utils;
using SeleniumPOMWalkthrough.Lib;
using TechTalk.SpecFlow.Assist;


namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    public class AP_SigninSteps
    {

        public AP_Website<ChromeDriver> AP_Website { get; } = new AP_Website<ChromeDriver>();

        private Credentials _credentials;


        [Given(@"I am on the signin page")]
        public void GivenIAmOnTheSigninPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();

        }

        [Given(@"I have entered the email ""(.*)""")]
        public void GivenIHaveEnteredTheEmail(string email)
        {
            AP_Website.AP_HomePage.InputUserName(email.Trim());
        }

        [Given(@"I have entered the password (.*)")]
        public void GivenIHaveEnteredThePassword(string password)
        {
            AP_Website.AP_HomePage.InputPassword(password.Trim());
        }


        [When(@"I click the signin button")]
        public void WhenIClickTheSigninButton()
        {
            AP_Website.AP_HomePage.ClickLoginButton();
            
        }

        [When(@"i move to user page")]
        public void WhenIMoveToUserPage()
        {
            AP_Website.AP_UserPage.GoToUserPage();
        }


        [When(@"I click on the backPack item")]
        public void WhenIClickOnTheBackPackItem()
        {
            AP_Website.AP_UserPage.ClickItemToView();
        }


        [Then(@"I should be in the item page containing the Url ""(.*)""")]
        public void ThenIShouldBeInTheItemPageContainingTheUrl(string expected)
        {
            Assert.That(AP_Website.AP_UserPage.GetPageUrl(), Is.EqualTo(expected));
        }

        [Then(@"I should see an alert containing the error message ""(.*)""")]
        public void ThenIShouldSeeAnAlertContainingTheErrorMessage(string expected)
        {
            
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(), Does.Contain(expected));
        }

        



        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }

    }
}
