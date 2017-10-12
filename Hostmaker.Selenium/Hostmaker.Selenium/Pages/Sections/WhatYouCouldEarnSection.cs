using System;
using Hostmaker.Selenium.Utility.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Hostmaker.Selenium.Pages.Sections
{
    public interface IWhatYouCouldEarnSection
    {
        WhatYouCouldEarnSection EnterPostcode(string postcode);

        WhatYouCouldEarnSection SelectPropertyAddress(string address);

        WhatYouCouldEarnSection SelectBedrooms(int bedroomCount);

        WhatYouCouldEarnSection EnterEmail(string email);

        void CalculateIncome();
    }

    public class WhatYouCouldEarnSection : BasePage, IWhatYouCouldEarnSection
    {
        protected string ResultPropertyAddressXPath = "//span[@class='pac-item-query' and text()='{0}']";

        public WhatYouCouldEarnSection(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "calculator-street-address")]
        protected IWebElement PropertyAddressElement { get; set; }

        [FindsBy(How = How.Id, Using = "calculator-bedrooms")]
        protected IWebElement BedroomSelecionElement { get; set; }

        [FindsBy(How = How.Id, Using = "calculator-email")]
        protected IWebElement EmailElement { get; set; }

        [FindsBy(How = How.Id, Using = "calculate-income")]
        protected IWebElement CalculateIncomeButtonElement { get; set; }

        public WhatYouCouldEarnSection EnterPostcode(string postcode)
        {
            PropertyAddressElement.SendKeys(postcode);
            return this;
        }

        public WhatYouCouldEarnSection SelectPropertyAddress(string address)
        {
            var result = Driver.FindElement(By.XPath(string.Format(ResultPropertyAddressXPath, address)));
            result.WaitUntilVisible(Driver);
            result.Click();
            return this;
        }

        public WhatYouCouldEarnSection SelectBedrooms(int bedroomCount)
        {
            var selection = new SelectElement(BedroomSelecionElement);
            selection.SelectByValue(Convert.ToString(bedroomCount));
            return this;
        }

        public WhatYouCouldEarnSection EnterEmail(string email)
        {
            EmailElement.SendKeys(email);
            return this;
        }

        public void CalculateIncome()
        {
            CalculateIncomeButtonElement.Click();
        }
    }
}