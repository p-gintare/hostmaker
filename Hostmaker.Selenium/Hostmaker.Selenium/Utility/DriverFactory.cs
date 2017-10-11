using System;
using Hostmaker.Selenium.Utility.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Hostmaker.Selenium.Utility
{
    public static class WebDriverFactory
    {
        private static readonly string DriverPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                                                    "\\Utility\\Drivers";

        public static IWebDriver Create()
        {
            IWebDriver driver = null;

            switch (GetBrowser())
            {
                case Browser.Chrome:
                    driver = new ChromeDriver(DriverPath, DefaultChromeOptions());
                    break;

                case Browser.Firefox:
                    var ffds = FirefoxDriverService.CreateDefaultService(DriverPath, "geckodriver.exe");
                    driver = new FirefoxDriver(ffds);
                    MaximizeWindow(driver);
                    break;

                case Browser.Edge:
                    var edgeDriverService = EdgeDriverService.CreateDefaultService(DriverPath, "MicrosoftWebDriver.exe");
                    driver = new EdgeDriver(edgeDriverService);
                    MaximizeWindow(driver);
                    break;

                case Browser.Ie11:
                    var ie11DriverService = InternetExplorerDriverService.CreateDefaultService(DriverPath,
                        "IEDriverServer.exe");
                    driver = new InternetExplorerDriver(ie11DriverService, DefaultIe11Options());
                    MaximizeWindow(driver);
                    break;

                case Browser.RemoteChrome:
                    driver = RemoteWebDriver(DefaultChromeOptions().ToCapabilities());
                    break;

                case Browser.RemoteFirefox:
                    driver = RemoteWebDriver(new FirefoxOptions().ToCapabilities());
                    MaximizeWindow(driver);
                    break;

                case Browser.RemoteEdge:
                    var edgeCapabilities = new EdgeOptions();
                    driver = RemoteWebDriver(edgeCapabilities.ToCapabilities());
                    MaximizeWindow(driver);
                    break;

                case Browser.RemoteIe11:
                    driver = RemoteWebDriver(DefaultIe11Options().ToCapabilities());
                    MaximizeWindow(driver);
                    break;

                default:
                    Assert.Inconclusive($"Browser: {GetBrowser()} is not supported");
                    break;
            }

            driver.SetDefaultImplicitWait();

            return driver;
        }

        private static void MaximizeWindow(IWebDriver driver)
        {
            try
            {
                driver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {
                driver.Dispose();
                Assert.Fail($"Exception in maximizing window: {e.Message} {e.StackTrace}");
            }
        }

        private static ChromeOptions DefaultChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArguments(
                "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            return options;
        }

        private static InternetExplorerOptions DefaultIe11Options()
        {
            var options = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnsureCleanSession = true,
                BrowserAttachTimeout = TimeSpan.FromSeconds(120)
            };
            return options;
        }

        private static IWebDriver RemoteWebDriver(ICapabilities capabilities)
        {
            return new RemoteWebDriver(new Uri(HostmakerEnvironmentManager.SeleniumGridHubUrl), capabilities);
        }

        private static Browser GetBrowser()
        {
            var browser = (Browser)Enum.Parse(typeof(Browser), HostmakerEnvironmentManager.Browser, true);
            return browser;
        }
    }
}