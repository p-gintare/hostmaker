using System.Text.RegularExpressions;
using Hostmaker.Selenium.Utility.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Hostmaker.Selenium.Pages.Sections
{
    public interface IWhatYouCouldGetEstimateResultSection
    {
        decimal GetEstimate();
    }

    public class WhatYouCouldGetEstimateResultSection : BasePage, IWhatYouCouldGetEstimateResultSection
    {
        [FindsBy(How = How.CssSelector, Using = "h1.pricing-hero-unit_price-heading")]
        protected IWebElement EstimateResultElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "h1.pricing-hero-unit_price-heading div.loading")]
        protected IWebElement LoadingEstimateElement { get; set; }

        public WhatYouCouldGetEstimateResultSection(IWebDriver driver) : base(driver)
        {
        }

        public decimal GetEstimate()
        {
            EstimateResultElement.WaitUntilVisible(Driver);
            LoadingEstimateElement.WaitUntilNotVisible(Driver);

            var text = EstimateResultElement.Text;
            var regex = new Regex(@"[\p{Sc}a-zA-Z""\/]");
            var value = regex.Replace(text, string.Empty);
            return decimal.Parse(value);
        }
    }
}