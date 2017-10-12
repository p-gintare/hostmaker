using Hostmaker.Selenium.Pages.Sections;
using Hostmaker.Selenium.Utility;
using OpenQA.Selenium;

namespace Hostmaker.Selenium.Pages
{
    public interface IHomePage
    {
        IWhatYouCouldEarnSection WhatYouCouldEarn { get; set; }
        IWhatYouCouldGetEstimateResultSection WhatYouCouldEarnEstimate { get; set; }

        void GoTo();
    }

    public class HomePage : BasePage, IHomePage
    {
        public IWhatYouCouldEarnSection WhatYouCouldEarn { get; set; }
        public IWhatYouCouldGetEstimateResultSection WhatYouCouldEarnEstimate { get; set; }

        public void GoTo()
        {
            Driver.Url = HostmakerEnvironmentManager.WebUrl;
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
            WhatYouCouldEarn = new WhatYouCouldEarnSection(driver);
            WhatYouCouldEarnEstimate = new WhatYouCouldGetEstimateResultSection(driver);
        }
    }
}