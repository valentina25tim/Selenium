using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Selenium_test
{
    public class BaseTest
    {
        private static readonly TimeSpan _timeSpan = TimeSpan.FromSeconds(5);
        public enum Browser
        {
            Chrome,
            Firefox
        }
        private IWebDriver _driver;
        private ChromeOptions _chromeOptions;

        private FirefoxOptions _firefoxOptions;
        public WebDriverWait Wait;

        public BaseTest()
        {
            _chromeOptions = new ChromeOptions { AcceptInsecureCertificates = true};
            _firefoxOptions = new FirefoxOptions { AcceptInsecureCertificates = true};

            _chromeOptions.AddArgument("no-sandbox");
            _firefoxOptions.AddArgument("no-sandbox");

            _chromeOptions.AddUserProfilePreference("download.default_directory", Directory.GetCurrentDirectory());
            _chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads",1);
            _chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            _chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            _driver = new ChromeDriver(Directory.GetCurrentDirectory(), _chromeOptions);
            Wait = new WebDriverWait(_driver, _timeSpan);
        }

        public void SetupTest (Browser browser, string url)
        {
            var currentDir = Directory.GetCurrentDirectory();

            _driver = browser switch
            {
                Browser.Chrome => new ChromeDriver(currentDir, _chromeOptions),
                Browser.Firefox => new FirefoxDriver(currentDir, _firefoxOptions),
                _ => new ChromeDriver(currentDir, _chromeOptions)
            };

            _driver.Manage().Window.Maximize();
            _driver?.Navigate().GoToUrl(url);
            _driver.Manage().Timeouts().ImplicitWait = _timeSpan;

            Wait = new WebDriverWait(_driver, _timeSpan);
        }
        [TearDown]
        public void OnExit()
        {
            _driver.Dispose();
        }









        //protected void GoToUrl (string url)
        //{
        //    _driver.Navigate().GoToUrl(url);
        //}
        //public void Init ()
        //{
        //    //_driver = new ChromeDriver(Directory.GetCurrentDirectory(), _chromeOptions);
        //    //Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

        //    //_driver.Navigate().GoToUrl("https://google.com");
        //    //_driver.FindElement(By.XPath($"//*[text()='Войти']")).Click();
        //    //_driver.Dispose();
        //}

    }
}
