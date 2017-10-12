using BoDi;
using Hostmaker.Selenium.Pages;
using Hostmaker.Selenium.Tests.Steps;
using Hostmaker.Selenium.Utility.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Hostmaker.Selenium.Utility
{
    [Binding]
    public sealed class Bootstrapper : ScenarioContextBinding
    {
        private readonly IObjectContainer _container;
        private IWebDriver _driver;

        public Bootstrapper(IObjectContainer container, ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverFactory.Create();
            ImplementDependecies(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.TestError != null)
            {
                _driver.TakeScreenshot(ScenarioContext.ScenarioInfo.Title);
            }
            _driver.Dispose();
        }

        private void ImplementDependecies(IWebDriver driver)
        {
            _container.RegisterInstanceAs(new HomePage(driver), typeof(IHomePage));
        }
    }
}