using Hostmaker.Selenium.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hostmaker.Selenium.Steps
{
    [Binding]
    public class WhatYouCanGetCalculationTestsSteps : ScenarioContextBinding
    {
        private readonly IHomePage _homePage;

        [Given(@"I go to Hostmaker\.co")]
        public void GivenIGoToHostmaker_Co()
        {
            _homePage.GoTo();
        }

        [When(@"I enter my postcode '(.*)'")]
        public void WhenIEnterMyPostcode(string postcode)
        {
            _homePage.WhatYouCouldEarn.EnterPostcode(postcode);
        }

        [When(@"I select '(.*)' as my address")]
        public void WhenISelectAsMyAddress(string address)
        {
            _homePage.WhatYouCouldEarn.SelectPropertyAddress(address);
        }

        [When(@"I select (.*) bedroom from the number of bedrooms option")]
        public void WhenISelectBedroomFromTheNumberOfBedroomsOption(int bedroomNumber)
        {
            _homePage.WhatYouCouldEarn.SelectBedrooms(bedroomNumber);
        }

        [When(@"I enter email address as '(.*)'")]
        public void WhenIEnterEmailAddressAs(string email)
        {
            _homePage.WhatYouCouldEarn.EnterEmail(email);
        }

        [When(@"I click calculate")]
        public void WhenIClickCalculate()
        {
            _homePage.WhatYouCouldEarn.CalculateIncome();
        }

        [Then(@"I should see the estimate we can make between (.*) and (.*)")]
        public void ThenIShouldSeeTheEstimateWeCanMakeBetweenAnd(int fromValue, int toValue)
        {
            var value = _homePage.WhatYouCouldEarnEstimate.GetEstimate();
            Assert.Greater(value, fromValue, $"{value} should be greater than {fromValue}");
            Assert.Less(value, toValue, $"{value} should be less than {toValue}");
        }

        public WhatYouCanGetCalculationTestsSteps(IHomePage homePage,
            ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _homePage = homePage;
        }
    }
}