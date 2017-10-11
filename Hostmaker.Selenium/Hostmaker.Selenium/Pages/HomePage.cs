using System;
using Hostmaker.Selenium.Utility.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Hostmaker.Selenium.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "calculator-street-address")]
        protected IWebElement PropertyAddressElement { get; set; }

        [FindsBy(How = How.Id, Using = "calculator-bedrooms")]
        protected IWebElement BedroomSelecionElement { get; set; }

        [FindsBy(How = How.Id, Using = "calculator-email")]
        protected IWebElement EmailElement { get; set; }

        [FindsBy(How = How.Id, Using = "calculate-income")]
        protected IWebElement CalculateIncomeButtonElement { get; set; }

        protected string ResultPropertyAddressXPath = "//[@class='pac-item-query' and text() *= '{0}']";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage EnterPostcode(string postcode)
        {
            PropertyAddressElement.SendKeys(postcode);
            return this;
        }

        public HomePage SelectPropertyAddress(string address)
        {
            var result = Driver.FindElement(By.XPath(string.Format(ResultPropertyAddressXPath, address)));
            result.WaitUntilVisible(Driver);
            result.Click();
            return this;
        }

        public HomePage SelectBedrooms(int bedroomCount)
        {
            var selection = new SelectElement(BedroomSelecionElement);
            if (selection.SelectedOption.GetValue() == Convert.ToString(bedroomCount))
            {
                return this;
            }

            selection.SelectByValue(Convert.ToString(bedroomCount));
            return this;
        }

        public HomePage EnterEmail(string email)
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