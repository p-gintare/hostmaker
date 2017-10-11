using TechTalk.SpecFlow;

namespace Hostmaker.Selenium.Steps
{
    [Binding]
    public class WhatYouCanGetCalculationTestsSteps
    {
        [Given(@"I go to Hostmaker\.co")]
        public void GivenIGoToHostmaker_Co()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter my postcode '(.*)'")]
        public void WhenIEnterMyPostcode(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select '(.*)' as my address")]
        public void WhenISelectAsMyAddress(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select (.*) bedroom from the number of bedrooms option")]
        public void WhenISelectBedroomFromTheNumberOfBedroomsOption(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter email address as '(.*)'")]
        public void WhenIEnterEmailAddressAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click calculate")]
        public void WhenIClickCalculate()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the estimate we can make between (.*) and (.*)")]
        public void ThenIShouldSeeTheEstimateWeCanMakeBetweenAnd(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}