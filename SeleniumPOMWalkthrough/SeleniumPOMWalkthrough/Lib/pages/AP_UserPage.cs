using OpenQA.Selenium;
using System.Threading;
using SeleniumPOMWalkthrough.Utils;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_UserPage
    {
        private string _userPageUrl = AppConfigReader.UserPageURL;
        private IWebDriver _seleniumDriver;
        private string _signInPageUrl = AppConfigReader.UserPageURL;


        private IWebElement _emailField => this._seleniumDriver.FindElement(By.Id("email"));
        private IWebElement _passwordField => this._seleniumDriver.FindElement(By.Id("passwd"));
        private IWebElement _signinButton => this._seleniumDriver.FindElement(By.Id("SubmitLogin"));
        private IWebElement _signinAlert => this._seleniumDriver.FindElement(By.ClassName("alert"));
        private IWebElement _forgotPasswordLink => this._seleniumDriver.FindElement(By.LinkText("Forgot your password?"));
        private IWebElement _createAccountAlert => this._seleniumDriver.FindElement(By.Id("create_account_error"));
        private IWebElement _createAccountButton => this._seleniumDriver.FindElement(By.Name("SubmitCreate"));
        private IWebElement _createAccountFormField => this._seleniumDriver.FindElement(By.Name("email_create"));

        private IWebElement _shoppingCartButton => _seleniumDriver.FindElement(By.Id("shopping_cart_container"));
        private IWebElement _header => _seleniumDriver.FindElement(By.Id("header_container"));


        private IWebElement _itemSelectionBackPack => _seleniumDriver.FindElement(By.Id("item_4_img_link"));
        private IWebElement _addToCartBackPack => _seleniumDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));



        public AP_UserPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        public void GoToUserPage() => _seleniumDriver.Navigate().GoToUrl(_userPageUrl);
        public void VisitSignInPage() => _seleniumDriver.Navigate().GoToUrl(_signInPageUrl);
        public void InputEmailLogin(string email) => _emailField.SendKeys(email);
        public void InputPasswordLogin(string password) => _passwordField.SendKeys(password);
        public void ClickSignin() => _signinButton.Click();
        public string GetAltertText() => _signinAlert.Text;
        public void ClickCreateEmailField() => _createAccountFormField.Click();
        public void InputEmailToCreateAccount(string email) => _createAccountFormField.SendKeys(email);
        public void ClickCreateAccountButton() => _createAccountButton.Click();
        public void ClickForgotPasswordLink() => _forgotPasswordLink.Click();


        public string GetHeaderText() => _header.Text;
        public void ClickShoppingCartButton() => _shoppingCartButton.Click();
        public void ClickItemToView() => _itemSelectionBackPack.Click();
        public string GetPageUrl() => _seleniumDriver.Url.ToString();


        public void ClickAddToCartBackPack() => _addToCartBackPack.Click();

        public void InputSigninCredentials(Credentials credentials)
        {
            _emailField.SendKeys(credentials.Email);
            _passwordField.SendKeys(credentials.Password);
        }

        public string GetAlertTextCreateAccount()
        {
            Thread.Sleep(5000);
            return _createAccountAlert.Text;
        }
    }
}
