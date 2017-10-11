using System;
using System.IO;
using OpenQA.Selenium;

namespace Hostmaker.Selenium.Utility.Extensions
{
    public static class WebDriverExtensions
    {
        public static void RemoveImplicitWait(this IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public static void SetDefaultImplicitWait(this IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void TakeScreenshot(IWebDriver driver, string name)
        {
            var dir =
                $@"{Directory.GetCurrentDirectory()}\Screenshots";

            Directory.CreateDirectory(dir);
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile($@"{dir}\{name}.jpg", ScreenshotImageFormat.Jpeg);
        }
    }
}