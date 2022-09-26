using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_test
{
    public static class Selector
    {
        public static By ByAnyCheckBox = By.XPath("//input[@type='checkbox']");
        public static By ByText(string text)
        {
            return By.XPath($"//*[text()='{text}']");
        }
        public static By ByNormalizeText(string text)
        {
            return By.XPath($"//*[normalize-space(text()) = '{text}']");
        }
        public static By ByCSS(string css)
        {
            return By.XPath($"//*[contains(@class, '{css}')]");
        }
        public static By ByType(string type)
        {
            return By.XPath($"//input[@type='{type}']");
        }

        public static By ByAnyAttribute(string attributeName, string attributeValue)
        {
            return By.XPath($"//*[@{attributeName}='{attributeValue}']");
        }
        public static By ByClassContains(string attributeValue)
        {
            return By.XPath($"//*[contains(@class, {attributeValue})]");
        }
        public static void ClearInputAndSendKeys(this IWebElement element, string value)
        {

        }
    } 
}
