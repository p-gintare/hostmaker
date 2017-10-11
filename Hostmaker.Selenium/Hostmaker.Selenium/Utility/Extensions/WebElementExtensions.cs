using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Hostmaker.Selenium.Utility.Extensions
{
    public static class WebElementExtensions
    {
        public static void WaitUntilNotVisible(this IWebElement element, IWebDriver driver)
        {
            driver.RemoveImplicitWait();
            new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until((d) =>
            {
                try
                {
                    return !element.Enabled && !element.Displayed;
                }
                catch (Exception)
                {
                    return true;
                }
            });
            driver.SetDefaultImplicitWait();
        }

        public static void WaitUntilVisible(this IWebElement element, IWebDriver driver, int seconds = 50)
        {
            driver.RemoveImplicitWait();
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until((d) =>
            {
                try
                {
                    return element.Enabled && element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            driver.SetDefaultImplicitWait();
        }
    }
}