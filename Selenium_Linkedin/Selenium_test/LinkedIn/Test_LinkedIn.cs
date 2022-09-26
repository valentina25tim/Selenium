using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace Selenium_test.LinkedIn
{
    public class Test_LinkedIn : BaseTest
    {
        private readonly string _emailForLogin = "EMAIL@gmail.com";
        private readonly string _passwordForLogin = "PASSWORD";
        private readonly string _searchPeople= "LITO";

        [Test]
        public async Task LoginTest()
        {
            SetupTest(Browser.Chrome, "https://www.linkedin.com/home");
            
            Login();
            SearchPeople();
            await TimeHolder.LongDelay();
           
        }

        private void Login ()
        {
            Wait.Until(_ => _.FindElement(By.Name("session_key"))).SendKeys(_emailForLogin);
            Wait.Until(_ => _.FindElement(By.Name("session_password"))).SendKeys(_passwordForLogin);
            Wait.Until(_ => _.FindElement(Selector.ByNormalizeText("Войти"))).Click();

            Wait.Until(_ => _.FindElement(By.Name("session_key"))).SendKeys(_emailForLogin);
            Wait.Until(_ => _.FindElement(By.Name("session_password"))).SendKeys(_passwordForLogin);
            Wait.Until(_ => _.FindElement(Selector.ByCSS("login__form_action_container"))).Click();
        }

        private void SearchPeople ()
        {
            Wait.Until(_ => _.FindElement(Selector.ByCSS("search-global-typeahead__input always-show-placeholder"))).SendKeys($"{_searchPeople}\n");
        }
    }
}



