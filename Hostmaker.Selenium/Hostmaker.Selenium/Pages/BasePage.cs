using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Hostmaker.Selenium.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}